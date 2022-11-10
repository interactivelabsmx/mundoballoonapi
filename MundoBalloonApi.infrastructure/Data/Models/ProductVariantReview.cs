namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariantReview : BaseEntity
{
    public int ProductVariantReviewId { get; set; }

    public int ProductVariantId { get; set; }

    public string? UserId { get; set; }

    public short Rating { get; set; }

    public string? Comments { get; set; }

    public virtual ProductVariant ProductVariant { get; set; } = null!;

    public virtual User? User { get; set; }
}