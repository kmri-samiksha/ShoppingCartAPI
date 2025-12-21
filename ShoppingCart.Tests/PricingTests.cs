using Microsoft.Extensions.Options;
using Moq;
using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;
using ShoppingCart.Infrastructure.Service;
using ShoppingCart.Tests.Fixture;

namespace ShoppingCart.Tests
{ 
        public class PricingTests: IClassFixture<PricingCalculator_TestCase_Fixture>
    {
        private readonly PricingCalculator_TestCase_Fixture _fixture;

        public PricingTests(PricingCalculator_TestCase_Fixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [MemberData(nameof(PricingCalculator_TestCase_Fixture.IndividualClientTestData), MemberType = typeof(PricingCalculator_TestCase_Fixture))]
        public void GetUnitPrice_IndividualClient_ReturnsCorrectPriceOne(IndividualClient client, ProductType productType, decimal expectedPrice)
        {
            var price = _fixture.PricingPolicyIndividual.GetUnitPrice(client, productType);
            Assert.Equal(expectedPrice, price);
        }

        [Theory]
        [MemberData(nameof(PricingCalculator_TestCase_Fixture.ProfessionalClientTestData), MemberType = typeof(PricingCalculator_TestCase_Fixture))]
        public void GetUnitPrice_ProfessionalClient_ReturnsCorrectPriceOne(ProfessionalClient client, ProductType productType, decimal expectedPrice)
        {
            var price = _fixture.PricingPolicyProfessional.GetUnitPrice(client, productType);
            Assert.Equal(expectedPrice, price);
        }

    }
}
