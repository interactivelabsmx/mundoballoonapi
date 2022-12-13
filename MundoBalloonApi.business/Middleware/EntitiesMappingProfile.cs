using AutoMapper;
using MundoBalloonApi.business.DTOs.Entities;
using EventCartDetail = MundoBalloonApi.infrastructure.Data.Models.EventCartDetail;
using Product = MundoBalloonApi.infrastructure.Data.Models.Product;
using ProductCategory = MundoBalloonApi.infrastructure.Data.Models.ProductCategory;
using ProductVariant = MundoBalloonApi.infrastructure.Data.Models.ProductVariant;
using ProductVariantMedium = MundoBalloonApi.infrastructure.Data.Models.ProductVariantMedium;
using ProductVariantReview = MundoBalloonApi.infrastructure.Data.Models.ProductVariantReview;
using ProductVariantValue = MundoBalloonApi.infrastructure.Data.Models.ProductVariantValue;
using UiRegistry = MundoBalloonApi.infrastructure.Data.Models.UiRegistry;
using User = MundoBalloonApi.infrastructure.Data.Models.User;
using UserProfile = MundoBalloonApi.infrastructure.Data.Models.UserProfile;
using UserAddresses = MundoBalloonApi.infrastructure.Data.Models.UserAddresses;
using Orders = MundoBalloonApi.infrastructure.Data.Models.Orders;
using UserCart = MundoBalloonApi.infrastructure.Data.Models.UserCart;
using UserEvent = MundoBalloonApi.infrastructure.Data.Models.UserEvent;
using UserPaymentProfile = MundoBalloonApi.infrastructure.Data.Models.UserPaymentProfile;
using Variant = MundoBalloonApi.infrastructure.Data.Models.Variant;
using VariantValue = MundoBalloonApi.infrastructure.Data.Models.VariantValue;
using OrderDetails = MundoBalloonApi.infrastructure.Data.Models.OrderDetails;

namespace MundoBalloonApi.business.Middleware;

public class EntitiesMappingProfile : Profile
{
    public EntitiesMappingProfile()
    {
        // PRODUCTS
        CreateMap<Product, DTOs.Entities.Product>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.ProductCategory))
            .ForMember(dest => dest.Variants, opt => opt.MapFrom(src => src.ProductVariants));
        CreateMap<Product, ProductEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductDescription));
        CreateMap<ProductCategory, DTOs.Entities.ProductCategory>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductCategoryName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductCategoryDescription));
        CreateMap<ProductVariant, DTOs.Entities.ProductVariant>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductVariantName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductVariantDescription))
            .ForMember(dest => dest.Media, opt => opt.MapFrom(src => src.ProductVariantMedia))
            .ForMember(dest => dest.VariantValues, opt => opt.MapFrom(src => src.ProductVariantValues))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.ProductVariantReviews));
        CreateMap<ProductVariant, ProductVariantEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductVariantName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProductVariantDescription));
        CreateMap<VariantValue, DTOs.Entities.VariantValue>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.VariantValue1));
        CreateMap<ProductVariantMedium, DTOs.Entities.ProductVariantMedium>();
        CreateMap<ProductVariantReview, DTOs.Entities.ProductVariantReview>();
        CreateMap<ProductVariantValue, DTOs.Entities.ProductVariantValue>();
        CreateMap<Variant, DTOs.Entities.Variant>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Variant1))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.VariantType));
        CreateMap<UiRegistry, DTOs.Entities.UiRegistry>();
        // USER
        CreateMap<User, DTOs.Entities.User>()
            .ForMember(dest => dest.PaymentProfiles, opt => opt.MapFrom(src => src.UserPaymentProfiles))
            .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.UserCarts))
            .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.UserEvents));
        CreateMap<User, FirebaseUser>()
            .ForMember(dest => dest.PaymentProfiles, opt => opt.MapFrom(src => src.UserPaymentProfiles))
            .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.UserCarts))
            .ForMember(dest => dest.Events, opt => opt.MapFrom(src => src.UserEvents));
        CreateMap<UserPaymentProfile, DTOs.Entities.UserPaymentProfile>();
        CreateMap<UserEvent, DTOs.Entities.UserEvent>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EventName))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.EventDate))
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.EventDetails))
            .ForMember(dest => dest.Carts, opt => opt.MapFrom(src => src.EventCartDetails));
        CreateMap<UserAddresses, DTOs.Entities.UserAddresses>()
            .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address1))
            .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address2))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            .ForMember(dest => dest.Zipcode, opt => opt.MapFrom(src => src.Zipcode));
        CreateMap<UserProfile, DTOs.Entities.UserProfile>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
        CreateMap<Orders, DTOs.Entities.Orders>();
        CreateMap<OrderDetails,DTOs.Entities.OrderDetails>();
        // SAVED CARTS
        CreateMap<UserCart, DTOs.Entities.UserCart>()
            .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.ProductVariant));
        CreateMap<EventCartDetail, DTOs.Entities.EventCartDetail>()
            .ForMember(dest => dest.Variant, opt => opt.MapFrom(src => src.ProductVariant));
    }
}