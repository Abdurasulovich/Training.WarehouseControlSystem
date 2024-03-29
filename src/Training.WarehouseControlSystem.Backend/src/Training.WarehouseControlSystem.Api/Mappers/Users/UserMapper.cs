﻿using AutoMapper;
using Training.WarehouseControlSystem.Api.Dto;
using Training.WarehouseControlSystem.Domain.Entities;

namespace Training.WarehouseControlSystem.Api.Mappers.Users;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}