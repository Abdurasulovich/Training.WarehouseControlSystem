﻿using Training.WarehouseControlSystem.Domain.Common.Entities;

namespace Training.WarehouseControlSystem.Domain.Entities;

public class AccessToken : Entity
{
    public AccessToken()
    {
    }

    public AccessToken(Guid id, Guid userId, string token, DateTimeOffset expiryTime, bool isRevoked)
    {
        Id = id;
        UserId = userId;
        Token = token;
        ExpiryTime = expiryTime;
        IsRevoked = isRevoked;
    }
    
    public Guid UserId { get; set; }
    
    public string Token { get; set; }
    
    public DateTimeOffset ExpiryTime { get; set; }

    public bool IsRevoked { get; set; }
}