using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;
using ProductCategory = MundoBalloonApi.business.DataObjects.Entities.ProductCategory;
using Variant = MundoBalloonApi.business.DataObjects.Entities.Variant;
using VariantValue = MundoBalloonApi.business.DataObjects.Entities.VariantValue;

namespace MundoBalloonApi.graphql.Collections;

[ExtendObjectType(Name = "Query")]
public partial class CollectionQueries
{
}