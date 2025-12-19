using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ShoppingCart.Domain.Products;


using Microsoft.AspNetCore.Mvc.Testing;
using ShoppingCart.API.DTOs;
using Xunit;

namespace ShoppingCart.Tests
{
    public class CartApiTests
    : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CartApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Individual_Cart_Total_Returns_Correct_Value()
        {
            var request = new IndividualCartRequestDto(
                new IndividualClientDto(
                    Guid.NewGuid(),
                    "John",
                    "Doe"),
                new List<CartItemDto>
                {
                  new(ProductType.HighEndPhone, 1),
    new(ProductType.MidRangePhone, 2),

                }
            );

            var response = await _client.PostAsJsonAsync(
                "/api/cart/individual/total",
                request);

            response.EnsureSuccessStatusCode();

            var total = await response.Content.ReadFromJsonAsync<decimal>();

            Assert.Equal(4600, total);
        }
    }
}





