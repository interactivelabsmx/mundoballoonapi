namespace MundoBalloonApi.business.DTOs.Product;

public record ProductQuickView
{
    public Entities.Product Product { get; init; }
    public IQueryable<Entities.VariantValue> VariantValues { get; init; }
}