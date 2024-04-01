using AutoMapper;
using Training.WarehouseControlSystem.Api.Dto.Customers;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Mappers.Customers;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerCreateDto>().ReverseMap();
        CreateMap<CustomerDto, CustomerCreateDto>().ReverseMap();
        CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
        CreateMap<CustomerDto, CustomerUpdateDto>().ReverseMap();
    }
}