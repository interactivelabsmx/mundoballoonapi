namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariant : BaseEntity
{
    public int ProductVariantId { get; set; }

    public string Sku { get; set; } = null!;

    public int ProductId { get; set; }

    public string? ProductVariantName { get; set; }

    public string? ProductVariantDescription { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<EventCartDetail> EventCartDetails { get; } = new List<EventCartDetail>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductVariantMedium> ProductVariantMedia { get; } = new List<ProductVariantMedium>();

    public virtual ICollection<ProductVariantReview> ProductVariantReviews { get; } = new List<ProductVariantReview>();

    public virtual ICollection<ProductVariantValue> ProductVariantValues { get; } = new List<ProductVariantValue>();

    public virtual ICollection<UserCart> UserCartProductVariants { get; } = new List<UserCart>();
}