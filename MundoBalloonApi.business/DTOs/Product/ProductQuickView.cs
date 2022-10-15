using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.business.DTOs.Product;

public record ProductQuickView
{
    public Entities.Product? Product { get; init; }
    public IEnumerable<Variant>? Variants { get; init; }
    public IEnumerable<VariantValue>? VariantValues { get; init; }
}