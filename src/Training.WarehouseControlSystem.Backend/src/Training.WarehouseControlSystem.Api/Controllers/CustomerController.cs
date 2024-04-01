using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Api.Dto.Customers;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await customerService.Get(asNoTracking: false).ToListAsync();

        return result.Any() ? Ok(mapper.Map<List<CustomerDto>>(result)) : NoContent();
    }

    [HttpGet("id")]
    public async ValueTask<IActionResult> GetByIdAsync(
        [FromHeader] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await customerService.GetByIdAsync(id, false, cancellationToken);

        return result is not null ? Ok(mapper.Map<CustomerDto>(result)) : NoContent();
    }

    [HttpGet("givenId")]
    public async ValueTask<IActionResult> GetBySpecialIdAsync(
        [FromHeader] int customerSpecialId,
        CancellationToken cancellationToken = default)
    {
        var result = await customerService.GetBySpecialIdAsync(customerSpecialId, false, cancellationToken);

        return result is not null ? Ok(mapper.Map<CustomerDto>(result)) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(
        [FromBody] CustomerCreateDto customerCreateDto,
        CancellationToken cancellationToken = default)
    {
        var customerMap = mapper.Map<Customer>(customerCreateDto);
        var result = await customerService.CreateAsync(customerMap, true, cancellationToken);

        return Ok(mapper.Map<CustomerDto>(result));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(
        [FromBody] CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var customerMap = mapper.Map<Customer>(customerUpdateDto);
        var result = await customerService.UpdateAsync(customerMap, true, cancellationToken);

        return result is not null ? Ok(mapper.Map<CustomerDto>(result)) : NoContent();
    }

    [HttpDelete("id")]
    public async ValueTask<IActionResult> DeleteByIdAsync(
        [FromHeader] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await customerService.DeleteByIdAsync(id, true, cancellationToken);

        return result is not null ? Ok(mapper.Map<CustomerDto>(result)) : NoContent();
    }
    
}