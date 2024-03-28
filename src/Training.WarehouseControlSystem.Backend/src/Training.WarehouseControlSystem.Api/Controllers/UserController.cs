using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Application.Services;

namespace Training.WarehouseControlSystem.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await userService.Get(asNoTracking: true).ToListAsync();

        return result.Any() ? Ok(result) : NoContent();
    }
}