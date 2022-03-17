using cu.ApiBasics.Lesvoorbeeld.Avond.Api.DTOs.Products;
using cu.ApiBAsics.Lesvoorbeeld.Avond.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            var productResponseDto = products.Items.Select(p =>
                new ProductsResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name,
                    Price = p.Price,
                    Properties = p.Properties.Select(p => p.Name)                }
                );
               
            return Ok(productResponseDto);
        }
    }
}
