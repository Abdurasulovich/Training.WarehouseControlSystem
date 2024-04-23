using System.Net.Http.Json;
using System.Text;
using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Training.WarehouseControlSystem.Application.Common.Serializers;
using Training.WarehouseControlSystem.Infrastructure.Common.Settings;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.Caching.Models;

namespace Training.WarehouseControlSystem.Infrastructure.Common.Caching;

public class RedisDistributedCacheBroker(
    IOptions<CacheSettings> cacheSettings,
    IDistributedCache distributedCache,
    IJsonSerializationSettingsProvider jsonSerializationSettingsProvider
    ) : ICacheBroker
{
    private readonly DistributedCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };
    public async ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var value = await distributedCache.GetAsync(key, cancellationToken);
        return value is not null
            ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value), jsonSerializationSettingsProvider.Get())
            : default;
    }

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value, CancellationToken cancellationToken = default)
    {
        var foundEntry = distributedCache.GetString(key);

        if (foundEntry is not null)
        {
            value = JsonConvert.DeserializeObject<T>(foundEntry, jsonSerializationSettingsProvider.Get());
            return ValueTask.FromResult(true);
        }

        value = default;
        return ValueTask.FromResult(false);
    }

    public async ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default)
    {
        var cachedValue = await distributedCache.GetStringAsync(key, cancellationToken);
        if (cachedValue is not null)
            return JsonConvert.DeserializeObject<T>(cachedValue, jsonSerializationSettingsProvider.Get());

        var value = await valueFactory();
        await SetAsync(key, await valueFactory(), entryOptions, cancellationToken);
        
        return value;
    }

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default)
    {
        await distributedCache.SetStringAsync(
            key,
            JsonConvert.SerializeObject(value, jsonSerializationSettingsProvider.Get()),
            GetCacheEntryOptions(entryOptions),
            cancellationToken
            );
    }

    public ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default)
    {
        distributedCache.Refresh(key);
        return ValueTask.CompletedTask;
    }

    public DistributedCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (entryOptions == default || (!entryOptions.AbsoluteExpirationRelativeToNow.HasValue &&
                                        !entryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();
        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.AbsoluteExpirationRelativeToNow;
        currentEntryOptions.SlidingExpiration = entryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}