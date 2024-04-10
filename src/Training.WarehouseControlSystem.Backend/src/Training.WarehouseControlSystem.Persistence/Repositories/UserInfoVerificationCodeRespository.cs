using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Persistence.Caching.Brokers;
using Training.WarehouseControlSystem.Persistence.DataContext;
using Training.WarehouseControlSystem.Persistence.Repositories.Interfaces;

namespace Training.WarehouseControlSystem.Persistence.Repositories;

public class UserInfoVerificationCodeRespository(AppDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserInfoVerificationCode, AppDbContext>(dbContext, cacheBroker),
    IUserInfoVerificationCodeRepository
{
    IQueryable<UserInfoVerificationCode> IUserInfoVerificationCodeRepository.Get(Expression<Func<UserInfoVerificationCode, bool>>? predicate, bool asNoTracking)
    =>base.Get(predicate, asNoTracking);

    ValueTask<UserInfoVerificationCode?> IUserInfoVerificationCodeRepository.GetByIdAsync(Guid codeId, bool asNoTracking, CancellationToken cancellationToken)
    =>base.GetByIdAsync(codeId, asNoTracking, cancellationToken);

    async ValueTask<UserInfoVerificationCode> IUserInfoVerificationCodeRepository.CreateAsync(UserInfoVerificationCode userInfoVerificationCode, bool saveChanges, CancellationToken cancellationToken)
    {
        await DbContext.UserInfoVerificationCodes
            .Where(code => code.Id == userInfoVerificationCode.Id && code.Type == userInfoVerificationCode.Type)
            .ExecuteUpdateAsync(setter => setter.SetProperty(code => code.IsActive, false), cancellationToken);

        return await base.CreateAsync(userInfoVerificationCode, saveChanges, cancellationToken);
    }

    public async ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await DbContext.UserInfoVerificationCodes.Where(code=>code.Id == codeId)
            .ExecuteUpdateAsync(setter=>setter.SetProperty(code=>code.IsActive, false), cancellationToken);

        if(saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);
    }

}
