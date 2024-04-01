using AutoMapper;
using Training.WarehouseControlSystem.Api.Dto.Users;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Mappers.Users;

public class UserUpdateMapper : Profile
{
    public UserUpdateMapper()
    {
        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<UserDto, UserUpdateDto>().ReverseMap();
    }
}