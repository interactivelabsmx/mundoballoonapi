using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DataObjects.Entities;
using MundoBalloonApi.infrastructure.Data.Contracts;
using Product = MundoBalloonApi.infrastructure.Data.Models.Product;

namespace MundoBalloonApi.business.Services
{
    public class SiteService : ISiteService
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        public SiteService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task<Site> GetSite(bool includeProducts, bool includeFeaturedProducts,
            bool includeBestSellingProducts,
            bool includeNewestProducts)
        {
            var site = new Site();
            if (includeProducts)
            {
                var products = await _productsRepository.GetProducts().ToListAsync();
                site.Products = _mapper.Map<List<Product>, List<DataObjects.Entities.Product>>(products);
            }

            if (includeFeaturedProducts)
            {
                var products = await _productsRepository.GetProducts().ToListAsync();
                site.FeaturedProducts = _mapper.Map<List<Product>, List<DataObjects.Entities.Product>>(products);
            }

            if (includeBestSellingProducts)
            {
                var products = await _productsRepository.GetProducts().ToListAsync();
                site.BestSellingProducts = _mapper.Map<List<Product>, List<DataObjects.Entities.Product>>(products);
            }

            if (includeNewestProducts)
            {
                var products = await _productsRepository.GetProducts().ToListAsync();
                site.NewestProducts = _mapper.Map<List<Product>, List<DataObjects.Entities.Product>>(products);
            }

            return site;
        }
    }
}