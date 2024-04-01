using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Api.Dto.Users;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await userService.Get(asNoTracking: true).ToListAsync();

        return result.Any() ? Ok(mapper.Map<List<UserDto>>(result)) : NoContent();
    }

    [HttpGet("id")]
    public async ValueTask<IActionResult> GetByIdAsync(
        [FromHeader] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await userService.GetByIdAsync(id, asNoTracking: true, cancellationToken);

        return Ok(mapper.Map<UserDto>(result));
    }

    [HttpGet("email")]
    public async ValueTask<IActionResult> GetByEmailAddressAsync(
        [FromHeader] string emailAddress,
        CancellationToken cancellationToken = default)
    {
        var result = await userService.GetByEmailAddressAsync(emailAddress, true, cancellationToken);

        return Ok(mapper.Map<UserDto>(result));
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(
        [FromBody] UserCreateDto userCreateDto,
        CancellationToken cancellationToken = default)
    {
        var user = mapper.Map<User>(userCreateDto);
        var result = await userService.CreateAsync(user, true, cancellationToken);
        return Ok(mapper.Map<UserCreateDto>(result));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(
        [FromBody] UserUpdateDto userUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var user = mapper.Map<User>(userUpdateDto);
        var result = await userService.UpdateAsync(user, true, cancellationToken);

        return Ok(mapper.Map<UserUpdateDto>(result));
    }

    [HttpDelete]
    public async ValueTask<IActionResult> DeleteByIdAsync(
        [FromHeader] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var result = await userService.DeleteByIdAsync(userId, true, cancellationToken);

        return result is not null ? Ok(result) : NoContent();
    }

}