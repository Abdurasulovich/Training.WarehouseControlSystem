using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.WarehouseControlSystem.Api.Dto.Products;
using Training.WarehouseControlSystem.Application.Services;
using Training.WarehouseControlSystem.Domain.Entities;
using Training.WarehouseControlSystem.Infrastructure.Validators;

namespace Training.WarehouseControlSystem.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var result = await productService.Get(asNoTracking: false).ToListAsync();

        return result.Any() ? Ok(mapper.Map<List<ProductDto>>(result)) : NoContent();
    }

    [HttpGet("id")]
    public async ValueTask<IActionResult> GetByIdAsync(
        [FromHeader] Guid id,
        CancellationToken cancellationToken = default)
    {
        var result = await productService.GetByIdAsync(id, false, cancellationToken);

        return result is not null ? Ok(mapper.Map<ProductDto>(result)) : NoContent();
    }

    [HttpGet("userId")]
    public async ValueTask<IActionResult> GetProductByUserIdAsync(
        [FromHeader] Guid userId,
        CancellationToken cancellationToken = default)
    {
        var result = await 
            productService.GetByRegisteredUserIdAsync(userId, false, cancellationToken);

        return result.Any() ? Ok(mapper.Map<List<ProductDto>>(result)) : NoContent();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync(
        [FromBody] ProductCreateDto productCreateDto,
        CancellationToken cancellationToken = default)
    {
        var productMap = mapper.Map<Product>(productCreateDto);

        var result = await productService.CreateAsync(productMap, true, cancellationToken);

        return Ok(mapper.Map<ProductDto>(result));
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateAsync(
        [FromBody] ProductCreateDto productCreateDto,
        CancellationToken cancellationToken = default)
    {
        var productMap = mapper.Map<Product>(productCreateDto);

        var result = await productService.UpdateAsync(productMap, true, cancellationToken);

        return result is not null ? Ok(mapper.Map<ProductDto>(result)) : NoContent();
    }
}