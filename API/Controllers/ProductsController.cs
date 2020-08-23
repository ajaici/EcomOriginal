using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            //return "List of products";

            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);

        }

        [HttpGet("Brands")]
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            //return "List of products";

            return await _context.ProductBrands.ToListAsync();
        }

        [HttpGet("Types")]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            //return "List of products";

            return await _context.ProductTypes.ToListAsync();
        }
    }
}