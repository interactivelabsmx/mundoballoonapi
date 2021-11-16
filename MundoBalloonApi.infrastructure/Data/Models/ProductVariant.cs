namespace MundoBalloonApi.infrastructure.Data.Models;

public class ProductVariant : BaseEntity
{
    public ProductVariant()
    {
        OcassionCartDetailProductVariants = new HashSet<OcassionCartDetail>();
        OcassionCartDetailSkuNavigations = new HashSet<OcassionCartDetail>();
        ProductVariantMedia = new HashSet<ProductVariantMedium>();
        UserCartProductVariants = new HashSet<UserCart>();
        UserCartSkuNavigations = new HashSet<UserCart>();
    }

    public int ProductVariantId { get; set; }
    public string? Sku { get; set; }
    public int VariantValueId { get; set; }
    public int ProductId { get; set; }
    public string? ProductVariantName { get; set; }
    public string? ProductVariantDescription { get; set; }
    public decimal Price { get; set; }
    public decimal? CompareAtPrice { get; set; }
    public decimal? Weight { get; set; }
    public bool? Taxable { get; set; }
    public bool? StoreOnly { get; set; }
    public bool? IsBundle { get; set; }

    public virtual Product? Product { get; set; }
    public virtual VariantValue? VariantValue { get; set; }
    public virtual ICollection<OcassionCartDetail> OcassionCartDetailProductVariants { get; set; }
    public virtual ICollection<OcassionCartDetail> OcassionCartDetailSkuNavigations { get; set; }
    public virtual ICollection<ProductVariantMedium> ProductVariantMedia { get; set; }
    public virtual ICollection<UserCart> UserCartProductVariants { get; set; }
    public virtual ICollection<UserCart> UserCartSkuNavigations { get; set; }
}