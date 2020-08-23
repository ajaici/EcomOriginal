using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<Product> _product;
        public ProductsController(IGenericRepository<Product> product, IGenericRepository<ProductBrand> productBrand, IGenericRepository<ProductType> productType)
        {
            _product = product;
            _productBrand = productBrand;
            _productType = productType;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            //return "List of products";

            //return await _repo.GetProductsAsync();


            return await _product.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _product.GetByIdAsync(id);

        }

         [HttpGet("Brands")]
         public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
         {
             //return "List of products";

             return await _productBrand.GetAllAsync();
         }

         [HttpGet("Types")]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
         {
            //return "List of products";

           return await _productType.GetAllAsync();
         }
    }
}