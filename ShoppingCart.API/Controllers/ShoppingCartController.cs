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
        public IActionResult CalculateForIndividual(
            [FromBody] IndividualCartRequestDto request)
        {
            var client = new IndividualClient(
                request.Client.ClientId,
                request.Client.FirstName,
                request.Client.LastName);

            var items = request.Items.Select(i =>
                new CartItem(i.ProductType, i.Quantity));

            var total = _service.CalculateTotal(client, items);

            return Ok(total);
        }

        [HttpPost("professional/total")]
        public IActionResult CalculateForProfessional(
            [FromBody] ProfessionalCartRequestDto request)
        {
            var client = new ProfessionalClient(
                request.Client.ClientId,
                request.Client.CompanyName,
                request.Client.AnnualRevenue);

            var items = request.Items.Select(i =>
                new CartItem(i.ProductType, i.Quantity));

            var total = _service.CalculateTotal(client, items);

            return Ok(total);
        }
    }
}
