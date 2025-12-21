using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Services;
using ShoppingCart.Domain.ShoppingCart;
using ShoppingCart.Domain.Clients;
using ShoppingCart.API.DTOs;

namespace ShoppingCart.API.Controllers
{
    

    [ApiController]
    [Route("api/cart")]
    public class ShoppingCartController : ControllerBase
    {
        private readonly CartTotalService _service;

        public ShoppingCartController(CartTotalService service)
        {
            _service = service;
        }

        [HttpPost("individual/total")]
        public async Task<IActionResult> CalculateForIndividual([FromBody] IndividualCartRequestDto request)
        {
            if (request == null)
                return BadRequest("Request body is required.");

            if (request.Client == null)
                return BadRequest("Client information is required.");

            var client = new IndividualClient(
                request.Client.ClientId,
                request.Client.FirstName,
                request.Client.LastName);

            var items = request.Items.Select(i =>
                new CartItem(i.ProductType, i.Quantity));

            var total = await _service.CalculateTotalAsync(client, items);
            
            return Ok(total);
        }

        [HttpPost("professional/total")]
        public async Task<IActionResult> CalculateForProfessional([FromBody] ProfessionalCartRequestDto request)
        {
            if (request == null)
                return BadRequest("Request body is required.");

            if (request.Client == null)
                return BadRequest("Client information is required.");

            var client = new ProfessionalClient(
                request.Client.ClientId,
                request.Client.CompanyName,
                request.Client.AnnualRevenue);

            var items = request.Items.Select(i =>
                new CartItem(i.ProductType, i.Quantity));

            var total = await _service.CalculateTotalAsync(client, items);
            
            return Ok(total);
        }
    }
}
