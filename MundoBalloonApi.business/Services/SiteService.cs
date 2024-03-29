using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
using MundoBalloonApi.business.DTOs.SiteService;
using MundoBalloonApi.infrastructure.Data.Contracts;

namespace MundoBalloonApi.business.Services;

public class SiteService : ISiteService
{
    private readonly IMapper _mapper;
    private readonly IProductsRepository _productsRepository;

    public SiteService(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyDictionary<string, List<Product>>> GetHomepageProducts(
        bool includeBestSellingProducts,
        bool includeNewestProducts, CancellationToken cancellationToken)
    {
        var homepageProducts = new Dictionary<string, List<Product>>();

        var products = await _productsRepository.GetProducts().ToListAsync(cancellationToken);
        var productsDto = _mapper.Map<List<infrastructure.Data.Models.Product>, List<Product>>(products);
        homepageProducts.Add("Featured", productsDto);

        if (includeBestSellingProducts)
        {
            products = await _productsRepository.GetProducts().ToListAsync(cancellationToken);
            productsDto = _mapper.Map<List<infrastructure.Data.Models.Product>, List<Product>>(products);
            homepageProducts.Add("Best Selling", productsDto);
        }

        if (!includeNewestProducts) return homepageProducts;
        products = await _productsRepository.GetProducts().ToListAsync(cancellationToken);
        productsDto = _mapper.Map<List<infrastructure.Data.Models.Product>, List<Product>>(products);
        homepageProducts.Add("Newest", productsDto);

        return homepageProducts;
    }

    public List<NavOption> GetNavOptions(string language)
    {
        if (language == "es")
            return new List<NavOption>
            {
                new()
                {
                    Order = 1,
                    Name = "Ofertas", Options = new[]
                    {
                        new NavCategory
                        {
                            Order = 1,
                            Href = "/search?cat=new",
                            Name = "Nuevos Productos",
                            ImageSrc =
                                "https://tailwindui.com/img/ecommerce-images/mega-menu-category-01.jpg",
                            ImageAlt =
                                "Descripcion de la fotografia"
                        },
                        new NavCategory
                        {
                            Order = 2,
                            Href = "/search?cat=new",
                            Name = "Playeras",
                            ImageSrc =
                                "https://tailwindui.com/img/ecommerce-images/mega-menu-category-02.jpg",
                            ImageAlt =
                                "Descripcion de la fotografia"
                        },
                        new NavCategory
                        {
                            Order = 3,
                            Href = "/search?cat=new",
                            Name = "Accesorios",
                            ImageSrc =
                                "https://tailwindui.com/img/ecommerce-images/mega-menu-category-03.jpg",
                            ImageAlt =
                                "Descripcion de la fotografia"
                        },
                        new NavCategory
                        {
                            Order = 4,
                            Href = "/search?cat=new",
                            Name = "Bolsas",
                            ImageSrc =
                                "https://tailwindui.com/img/ecommerce-images/mega-menu-category-04.jpg",
                            ImageAlt =
                                "Descripcion de la fotografia"
                        }
                    }
                },
                new()
                {
                    Order = 2,
                    Name = "Productos",
                    Href = "/search"
                },
                new()
                {
                    Order = 3,
                    Name = "Contacto",
                    Href = "/contact"
                }
            };
        return new List<NavOption>
        {
            new()
            {
                Order = 1,
                Name = "Featured", Options = new[]
                {
                    new NavCategory
                    {
                        Order = 1,
                        Href = "/search?cat=new",
                        Name = "New Arrivals",
                        ImageSrc =
                            "https://tailwindui.com/img/ecommerce-images/mega-menu-category-01.jpg",
                        ImageAlt =
                            "Models sitting back to back, wearing Basic Tee in black and bone."
                    },
                    new NavCategory
                    {
                        Order = 2,
                        Href = "/search?cat=new",
                        Name = "Basic Tees",
                        ImageSrc =
                            "https://tailwindui.com/img/ecommerce-images/mega-menu-category-02.jpg",
                        ImageAlt =
                            "Models sitting back to back, wearing Basic Tee in black and bone."
                    },
                    new NavCategory
                    {
                        Order = 3,
                        Href = "/search?cat=new",
                        Name = "Accessories",
                        ImageSrc =
                            "https://tailwindui.com/img/ecommerce-images/mega-menu-category-03.jpg",
                        ImageAlt =
                            "Models sitting back to back, wearing Basic Tee in black and bone."
                    },
                    new NavCategory
                    {
                        Order = 4,
                        Href = "/search?cat=new",
                        Name = "Carry",
                        ImageSrc =
                            "https://tailwindui.com/img/ecommerce-images/mega-menu-category-04.jpg",
                        ImageAlt =
                            "Models sitting back to back, wearing Basic Tee in black and bone."
                    }
                }
            },
            new()
            {
                Order = 2,
                Name = "Shop",
                Href = "/search"
            },
            new()
            {
                Order = 3,
                Name = "Contact",
                Href = "/contact"
            }
        };
    }
}