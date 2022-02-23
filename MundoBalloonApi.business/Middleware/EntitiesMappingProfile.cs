using AutoMapper;
using MundoBalloonApi.business.DataObjects.Entities;
using Claim = MundoBalloonApi.infrastructure.Data.Models.Claim;
using OcassionCartDetail = MundoBalloonApi.infrastructure.Data.Models.OcassionCartDetail;
using OccasionCart = MundoBalloonApi.infrastructure.Data.Models.OccasionCart;
using Product = MundoBalloonApi.infrastructure.Data.Models.Product;
using ProductCategory = MundoBalloonApi.infrastructure.Data.Models.ProductCategory;
using ProductVariant = MundoBalloonApi.infrastructure.Data.Models.ProductVariant;
using ProductVariantMedium = MundoBalloonApi.infrastructure.Data.Models.ProductVariantMedium;
using User = MundoBalloonApi.infrastructure.Data.Models.User;
using UserAddrese = MundoBalloonApi.infrastructure.Data.Models.UserAddrese;
using UserCart = MundoBalloonApi.infrastructure.Data.Models.UserCart;
using UserClaim = MundoBalloonApi.infrastructure.Data.Models.UserClaim;
using UserOccasion = MundoBalloonApi.infrastructure.Data.Models.UserOccasion;
using UserProfile = MundoBalloonApi.infrastructure.Data.Models.UserProfile;
using Variant = MundoBalloonApi.infrastructure.Data.Models.Variant;
using VariantValue = MundoBalloonApi.infrastructure.Data.Models.VariantValue;

namespace MundoBalloonApi.business.Middleware;

public class EntitiesMappingProfile : Profile
{
    public EntitiesMappingProfile()
    {
        // PRODUCTS
        CreateMap<Product, DataObjects.Entities.Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ProductCategory))
            .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductVariants));
        CreateMap<Product, ProductEntity>()
            .IgnoreAllPropertiesWithAnInaccessibleSetter()
            .IgnoreAllSourcePropertiesWithAnInaccessibleSetter()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription));
        CreateMap<ProductCategory, DataObjects.Entities.ProductCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductCategoryName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductCategoryDescription));
        CreateMap<ProductVariant, DataObjects.Entities.ProductVariant>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductVariantName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductVariantDescription))
            .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.VariantValue))
            .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.ProductVariantMedia));
        CreateMap<VariantValue, DataObjects.Entities.VariantValue>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.VariantValue1));
        CreateMap<ProductVariantMedium, DataObjects.Entities.ProductVariantMedium>();
        CreateMap<Variant, DataObjects.Entities.Variant>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Variant1))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.VariantType));
        // USER
        CreateMap<Claim, DataObjects.Entities.Claim>();
        CreateMap<User, DataObjects.Entities.User>()
            .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.UserProfile))
            .ForMember(dest => dest.Addreses, opt => opt.MapFrom(src => src.UserAddreses))
            .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.UserCarts))
            .ForMember(dest => dest.Occasions, opt => opt.MapFrom(src => src.UserOccasions))
            .ForMember(dest => dest.UserClaims, opt => opt.MapFrom(src => src.UserClaims));
        CreateMap<UserProfile, DataObjects.Entities.UserProfile>();
        CreateMap<UserAddrese, DataObjects.Entities.UserAddrese>();
        CreateMap<UserClaim, DataObjects.Entities.UserClaim>()
            .ForMember(dest => dest.Claim, opt => opt.MapFrom(src => src.Claim));
        // SAVED CARTS
        CreateMap<UserCart, DataObjects.Entities.UserCart>()
            .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.ProductVariant));
        CreateMap<UserOccasion, DataObjects.Entities.UserOccasion>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OccasionName))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.OccasionDate))
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.OccasionDetails))
            .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.OccasionCarts));
        CreateMap<OccasionCart, DataObjects.Entities.OccasionCart>()
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.OccasionCartDescription))
            .ForMember(dest => dest.CartDetails, opt => opt.MapFrom(src => src.OcassionCartDetails));
        CreateMap<OcassionCartDetail, DataObjects.Entities.OcassionCartDetail>()
            .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.ProductVariant));
    }
}