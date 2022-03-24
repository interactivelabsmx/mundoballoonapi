namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariant : BaseEntity
{
    public ProductVariant()
    {
        OcassionCartDetailProductVariants = new HashSet<OcassionCartDetail>();
        OcassionCartDetailSkuNavigations = new HashSet<OcassionCartDetail>();
        ProductVariantMedia = new HashSet<ProductVariantMedium>();
        ProductVariantMedia = new HashSet<ProductVariantMedium>();
        ProductVariantValues = new HashSet<ProductVariantValue>();
        UserCartProductVariants = new HashSet<UserCart>();
        UserCartSkuNavigations = new HashSet<UserCart>();
    }

    public int ProductVariantId { get; set; }
    public string? Sku { get; set; }
    public int ProductId { get; set; }
    public string? ProductVariantName { get; set; }
    public string? ProductVariantDescription { get; set; }
    public double Price { get; set; }
    public virtual Product? Product { get; set; }
    public virtual ICollection<OcassionCartDetail> OcassionCartDetailProductVariants { get; set; }
    public virtual ICollection<OcassionCartDetail> OcassionCartDetailSkuNavigations { get; set; }
    public virtual ICollection<ProductVariantMedium> ProductVariantMedia { get; set; }
    public virtual ICollection<ProductVariantValue> ProductVariantValues { get; set; }
    public virtual ICollection<UserCart> UserCartProductVariants { get; set; }
    public virtual ICollection<UserCart> UserCartSkuNavigations { get; set; }
}