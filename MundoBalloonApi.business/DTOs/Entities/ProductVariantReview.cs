namespace MundoBalloonApi.business.DTOs.Entities;

public class ProductVariantReview : BaseDto
{
    public int ProductVariantReviewId { get; init; }
    public int ProductVariantId { get; init; }
    public string UserId { get; init; } = string.Empty;
    public int Rating { get; init; }
    public string? Comments { get; init; }

    public ProductVariant? ProductVariant { get; set; }
    public User? User { get; set; }
}