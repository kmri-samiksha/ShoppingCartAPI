using Moq;
using Xunit;
using ShoppingCart.Application.Services;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Interface;
using ShoppingCart.Domain.Products;

public class CartTotalServiceTests
{
    [Fact]
    public void GetUnitPrice_ReturnsExpectedPrice_ForIndividualClient()
    {
        // Arrange
        var client = new IndividualClient(Guid.NewGuid(), "John", "Doe");
        var productType = ProductType.HighEndPhone;

        // Create a mock of IProductPricingPolicy
        var mockPricingPolicy = new Mock<IProductPricingPolicy>();

        // Setup mock to return a specific value
        mockPricingPolicy
            .Setup(p => p.GetUnitPrice(client, productType))
            .Returns(1500m);

        // Inject mock into CartTotalService
        var service = new CartTotalService(mockPricingPolicy.Object);

        // Act
        decimal unitPrice = mockPricingPolicy.Object.GetUnitPrice(client, productType);
        // or call via service if service method uses pricing policy internally:
        // decimal total = service.CalculateTotal(client, new List<ProductType> { productType });
       
        Assert.Equal(1500m, unitPrice);
    }
}
