using System.Net.Http.Json;
using ShoppingCart.Domain.Products;
using Microsoft.AspNetCore.Mvc.Testing;
using ShoppingCart.API.DTOs;
using Xunit;
using ShoppingCart.Domain.Clients;

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
                  new(ProductType.HighEndPhone, 2),
    new(ProductType.MidRangePhone, 3),
    new(ProductType.Laptop, 1)
                }
            );

            var response = await _client.PostAsJsonAsync(
                "/api/cart/individual/total",
                request);

            response.EnsureSuccessStatusCode();

            var total = await response.Content.ReadFromJsonAsync<decimal>();

            Assert.Equal(6600, total);
        }

        [Fact]
        public async Task Professional_Cart_Total_Returns_Correct_Value_Above10M()
        {
            var request = new ProfessionalCartRequestDto(
                new ProfessionalClientDto(
                    Guid.NewGuid(),
                    "Acme Corp",
                    15_000_000),
                new List<CartItemDto>
                {
                  new(ProductType.HighEndPhone, 2),
    new(ProductType.MidRangePhone, 3),
    new(ProductType.Laptop, 1)
                }
            );

            var response = await _client.PostAsJsonAsync(
                "/api/cart/professional/total",
                request);

            response.EnsureSuccessStatusCode();

            var total = await response.Content.ReadFromJsonAsync<decimal>();

            Assert.Equal(4550, total);
        }

        [Fact]
        public async Task Professional_Cart_Total_Returns_Correct_Value_Below10M()
        {
            var request = new ProfessionalCartRequestDto(
                new ProfessionalClientDto(
                    Guid.NewGuid(),
                    "Acme Corp",
                    9_000_000),
                new List<CartItemDto>
                {
                  new(ProductType.HighEndPhone, 2),
    new(ProductType.MidRangePhone, 3),
    new(ProductType.Laptop, 1)
                }
            );

            var response = await _client.PostAsJsonAsync(
                "/api/cart/professional/total",
                request);

            response.EnsureSuccessStatusCode();

            var total = await response.Content.ReadFromJsonAsync<decimal>();

            Assert.Equal(5100, total);
        }
    }
}





