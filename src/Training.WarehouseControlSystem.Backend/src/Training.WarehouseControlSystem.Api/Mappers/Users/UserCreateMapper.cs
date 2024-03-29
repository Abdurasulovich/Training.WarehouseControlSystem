using AutoMapper;
using Training.WarehouseControlSystem.Api.Dto;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Mappers.Users;

public class UserCreateMapper : Profile
{
    public UserCreateMapper()
    {
        CreateMap<User, UserCreateDto>().ReverseMap();
    }
}