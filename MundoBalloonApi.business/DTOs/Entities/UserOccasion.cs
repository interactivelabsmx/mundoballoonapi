﻿namespace MundoBalloonApi.business.DTOs.Entities;

public class UserOccasion
{
    public int? UserOccasionId { get; set; } = 0;
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? Date { get; set; }
    public string Details { get; set; } = string.Empty;

    public ICollection<OccasionCart>? Carts { get; set; }
}