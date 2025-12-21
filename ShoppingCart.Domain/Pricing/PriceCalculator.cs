using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;

namespace ShoppingCart.Domain.Pricing
{
    public static class PriceCalculator
    {
        public static decimal GetUnitPrice(Client client, ProductType productType)
        {
            return client switch
            {
                IndividualClient => productType switch
                {
                    ProductType.HighEndPhone => 1500,
                    ProductType.MidRangePhone => 800,
                    ProductType.Laptop => 1200,
                    _ => throw new ArgumentOutOfRangeException()
                },

                ProfessionalClient professional => GetProfessionalPrice(professional, productType),

                _ => throw new InvalidOperationException("Unknown client type")
            };
        }

        private static decimal GetProfessionalPrice(ProfessionalClient client, ProductType productType)
        {
            bool highRevenue = client.AnnualRevenue > 10_000_000;

            return (highRevenue, productType) switch
            {
                (true, ProductType.HighEndPhone) => 1000,
                (true, ProductType.MidRangePhone) => 550,
                (true, ProductType.Laptop) => 900,

                (false, ProductType.HighEndPhone) => 1150,
                (false, ProductType.MidRangePhone) => 600,
                (false, ProductType.Laptop) => 1000,

                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
