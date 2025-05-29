using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DataTrancfareObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // BaseURl/api/Products
    public class ProductsController(IServiceManager _serviceManager) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<PaginationResult<ProductDto>>> GetAllProduct([FromQuery]ProductQueryParams queryParams)
        {
            var products = await _serviceManager.ProductService.GetAllProductAsync(queryParams);
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var products = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(products);
        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllType()
        {
            var TypeProduct = await _serviceManager.ProductService.GetAllTypeAsync();
            return Ok(TypeProduct);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrand()
        {
            var Brandproducts = await _serviceManager.ProductService.GetAllBrandAsync();
            return Ok(Brandproducts);
        }

    }
}
