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
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            //return "List of products";

            return await _repo.GetProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _repo.GetProductsByIdAsync(id);

        }

        // [HttpGet("Brands")]
        // public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        // {
        //     //return "List of products";

        //     return await _context.ProductBrands.ToListAsync();
        // }

        // [HttpGet("Types")]
        // public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        // {
        //     //return "List of products";

        //     return await _context.ProductTypes.ToListAsync();
        // }
    }
}