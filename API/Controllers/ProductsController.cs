using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<Product> _product;

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> product, IGenericRepository<ProductBrand> productBrand,
         IGenericRepository<ProductType> productType,
         IProductRepository productRepository, IMapper mapper
         )
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _product = product;
            _productBrand = productBrand;
            _productType = productType;
        }

        [HttpGet]
        public async Task<IReadOnlyList<ProductToReturnDto>> GetProducts()
        {
            //return "List of products";

            // return await _productRepository.GetProductsAsync();
            var spec = new ProductsWithTypesAndBrandsSpecification();

            //return await _product.ListAsync(spec);
            var products = await _product.ListAsync(spec);

            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);

            // return products.Select(product => new ProductToReturnDto
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     PictureUrl = product.PictureUrl,
            //     Description = product.Description,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name
            // }).ToList();


        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _product.GetEntityWithSpec(spec);

            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            // return new ProductToReturnDto
            // {
            //     Id = product.Id,
            //     Name = product.Name,
            //     Description = product.Description,
            //     PictureUrl = product.PictureUrl,
            //     ProductBrand = product.ProductBrand.Name,
            //     ProductType = product.ProductType.Name

            // };

            return _mapper.Map<Product, ProductToReturnDto>(product);

            // return await _product.GetEntityWithSpec(spec);

            //return await _productRepository.GetProductByIdAsync(id);

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