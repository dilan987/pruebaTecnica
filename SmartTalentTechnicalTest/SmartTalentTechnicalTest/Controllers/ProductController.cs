using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTalentTechnicalTest.ApplicationServices;
using SmartTalentTechnicalTest.Commands;
using System.Security.Claims;

namespace SmartTalentTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _productServices;
        public ProductController(ProductServices productServices) { 

            this._productServices = productServices;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand createProductCommand)
        {
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1")
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }
            await _productServices.HandleCommand(createProductCommand);
            return Ok(createProductCommand);
        }

        [Authorize]
        [HttpGet("/all")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productServices.GetProducts();
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProductById(Guid id)
        {
           
            var response = await _productServices.GetProduct(id);
            return Ok(response);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand updateProductCommand)
        {
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1")
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }

            await _productServices.HandleCommand(updateProductCommand);
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1")
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }
            await _productServices.DeleteProduct(id);
            return NoContent();
        }
    }
}
