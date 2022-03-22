﻿namespace MundoBalloonApi.business.DataObjects.Entities;

public class OccasionCart
{
    public int? OccasionCartId { get; set; } = 0;
    public int UserOccasionId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string DropOffStage { get; set; } = string.Empty;

    public ICollection<OcassionCartDetail>? CartDetails { get; set; }
}