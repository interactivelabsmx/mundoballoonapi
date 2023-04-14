namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariant : BaseEntity
{
    public int ProductVariantId { get; init; }
    public string? Sku { get; init; }
    public int ProductId { get; init; }
    public string? ProductVariantName { get; init; }
    public string? ProductVariantDescription { get; init; }
    public double Price { get; init; }
    public Product? Product { get; set; }

    public ICollection<UserEventCartDetail> UserEventCartDetailUserProductVariants { get; set; } =
        new HashSet<UserEventCartDetail>();

    public ICollection<OrderProductsDetails> OrderProductsDetailsProductVariants { get; set; } =
        new HashSet<OrderProductsDetails>();

    public ICollection<ProductVariantMedium> ProductVariantMedia { get; set; } = new HashSet<ProductVariantMedium>();
    public ICollection<ProductVariantValue> ProductVariantValues { get; set; } = new HashSet<ProductVariantValue>();
    public ICollection<UserCartProduct> UserCartProductVariants { get; set; } = new HashSet<UserCartProduct>();
    public ICollection<ProductVariantReview> ProductVariantReviews { get; set; } = new HashSet<ProductVariantReview>();
}