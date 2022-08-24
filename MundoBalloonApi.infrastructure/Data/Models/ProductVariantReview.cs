namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariantReview : BaseEntity
{
    public int ProductVariantReviewId { get; init; }
    public int ProductVariantId { get; init; }
    public int UserId { get; init; }
    public int Rating { get; init; }
    public string? Comments { get; init; }

    public ProductVariant? ProductVariant { get; set; }
    public User? User { get; set; }
}