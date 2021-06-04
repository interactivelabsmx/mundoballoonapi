using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Middleware
{
    public class EntitiesMappingProfile : Profile
    {
        public EntitiesMappingProfile()
        {
            // PRODUCTS
            CreateMap<Product, DTOs.Models.Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ProductCategory))
                .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductVariants));
            CreateMap<ProductCategory, DTOs.Models.ProductCategory>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductCategoryName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductCategoryDescription));
            CreateMap<ProductVariant, DTOs.Models.ProductVariant>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductVariantName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductVariantDescription))
                .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.VariantValue))
                .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.ProductVariantMedia));
            CreateMap<VariantValue, DTOs.Models.VariantValue>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.VariantValue1));
            CreateMap<ProductVariantMedium, DTOs.Models.ProductVariantMedium>();
            CreateMap<Variant, DTOs.Models.Variant>();
            // USER
            CreateMap<Claim, DTOs.Models.Claim>();
            CreateMap<User, DTOs.Models.User>()
                .ForMember(dest => dest.Profile, opt => opt.MapFrom(src => src.UserProfile))
                .ForMember(dest => dest.Addreses, opt => opt.MapFrom(src => src.UserAddreses))
                .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.UserCarts))
                .ForMember(dest => dest.Occasions, opt => opt.MapFrom(src => src.UserOccasions))
                .ForMember(dest => dest.UserClaims, opt => opt.MapFrom(src => src.UserClaims));
            CreateMap<UserProfile, DTOs.Models.UserProfile>();
            CreateMap<UserAddrese, DTOs.Models.UserAddrese>();
            CreateMap<UserClaim, DTOs.Models.UserClaim>()
                .ForMember(dest => dest.Claim, opt => opt.MapFrom(src => src.Claim));
            // SAVED CARTS
            CreateMap<UserCart, DTOs.Models.UserCart>()
                .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.ProductVariant));
            CreateMap<UserOccasion, DTOs.Models.UserOccasion>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OccasionName))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.OccasionDate))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.OccasionDetails))
                .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.OccasionCarts));
            CreateMap<OccasionCart, DTOs.Models.OccasionCart>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.OccasionCartDescription))
                .ForMember(dest => dest.CartDetails, opt => opt.MapFrom(src => src.OcassionCartDetails));
            CreateMap<OcassionCartDetail, DTOs.Models.OcassionCartDetail>()
                .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.ProductVariant));
        }
    }
}