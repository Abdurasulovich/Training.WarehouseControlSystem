using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Training.WarehouseControlSystem.Api.Dto.Products;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Mappers.Products;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductDto, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductCreateDto>().ReverseMap();
    }
}