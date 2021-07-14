namespace MundoBalloonApi.business.DataObjects.Requests
{
    public class CreateProductVariantRequest
    {
        public string? Sku { get; set; }
        public int VariantValueId { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? CompareAtPrice { get; set; }
        public decimal? Weight { get; set; }
        public bool? Taxable { get; set; }
        public bool? StoreOnly { get; set; }
        public bool? IsBundle { get; set; }
    }
}