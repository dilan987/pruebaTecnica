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
    public class OrderController : ControllerBase
    {
        private readonly OrderServices _orderServices;
        public OrderController(OrderServices orderServices) { 

            this._orderServices = orderServices;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderCommand createOrderCommand)
        {
            var userEmail = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Guid guidValue = Guid.Parse(userId);
            var subject = " Order verification";
            await _orderServices.HandleCommand(guidValue, createOrderCommand);
            await _orderServices.SendEmailAsync(userEmail, subject);
            return Ok(createOrderCommand);
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAllOrders()
        {
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1")
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }
            var response = await _orderServices.GetAllOrders();
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult>GetOrderById(Guid id)
        {
           
            var response = await _orderServices.GetOrder(id);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetOrderByUserId(Guid id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1" && userId != id.ToString())
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }
            var response = await _orderServices.GetAllOrdersByUserId(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand updateOrderCommand)
        {
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1")
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }

            await _orderServices.HandleCommand(updateOrderCommand);
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var userType = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (userType == "1")
            {
                throw new UnauthorizedAccessException("you do not have permission for this action");
            }
            await _orderServices.DeleteOrder(id);
            return NoContent();
        }
    }
}
