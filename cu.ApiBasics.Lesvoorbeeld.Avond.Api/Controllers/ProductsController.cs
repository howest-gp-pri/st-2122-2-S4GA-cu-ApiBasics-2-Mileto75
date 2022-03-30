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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //get the product
            var product = await _productService.GetByIdAsync(id);
            if(!product.IsSuccess)
            {
                return BadRequest(product.ValidationErrors);
            }
            ProductResponseDto productsResponseDto = new ProductResponseDto
            {
                Name = product.Items.First().Name,
                Category = product.Items.First().Category.Name,
                Properties = product.Items.First().Properties
                .Select(pr => pr.Name)

            };
            return Ok(productsResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            var productResponseDto = products.Items.Select(p =>
                new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Category = p.Category.Name,
                    Price = p.Price,
                    Properties = p.Properties.Select(p => p.Name)
                });
               
            return Ok(productResponseDto);
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddRequestDto
            productAddRequestDto)
        {
            //check for model errors
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //check for database errors
            var result = await _productService.Add(
                productAddRequestDto.Name,
                productAddRequestDto.CategoryId,
                productAddRequestDto.Price,
                productAddRequestDto.Properties
                );
            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            //a Ok
            return Ok("Product added!");
        }
        //put to update
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateRequestDto
            productUpdateRequestDto)
        {
            //check for validation errors
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _productService.UpdateAsync(
                productUpdateRequestDto.Id,
                productUpdateRequestDto.Product.Name,
                productUpdateRequestDto.Product.CategoryId,
                productUpdateRequestDto.Product.Price,
                productUpdateRequestDto.Product.Properties
                );
            //check for database errors
            if(!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            //A ok
            return Ok("Product updated!");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _productService.DeleteAsync(id))
            {
                return Ok("Product deleted!");
            }
            return BadRequest("Something went wrong! please try again!");
        }
    }
}
