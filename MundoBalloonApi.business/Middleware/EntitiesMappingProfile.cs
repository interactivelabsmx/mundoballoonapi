using AutoMapper;
using MundoBalloonApi.infrastructure.Data.Models;

namespace MundoBalloonApi.business.Middleware
{
    public class EntitiesMappingProfile : Profile
    {
        public EntitiesMappingProfile()
        {
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
        }
    }
}