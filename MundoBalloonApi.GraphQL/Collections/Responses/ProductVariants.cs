using MundoBalloonApi.business.DTOs.Entities;

namespace MundoBalloonApi.graphql.Collections.Responses;

public class ProductVariants
{
    public IEnumerable<Variant>? Variants { get; init; }
    public IEnumerable<VariantValue>? VariantValues { get; init; }
}