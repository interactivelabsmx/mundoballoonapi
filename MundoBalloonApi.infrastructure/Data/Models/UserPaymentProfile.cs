﻿namespace MundoBalloonApi.infrastructure.Data.Models;

public class UserPaymentProfile : BaseEntity
{
    public int UserProfileId { get; init; }
    public int? UserId { get; init; }
    public string? ProcessorId { get; init; }

    public User? User { get; set; }
}