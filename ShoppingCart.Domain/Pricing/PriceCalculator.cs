using ShoppingCart.Domain.Clients;
using ShoppingCart.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    ProductType.HighEndPhone => 2000,
                    ProductType.MidRangePhone => 1300,
                    ProductType.Laptop => 1700,
                    _ => throw new ArgumentOutOfRangeException()
                },

                ProfessionalClient professional => GetProfessionalPrice(professional, productType),

                _ => throw new InvalidOperationException("Unknown client type")
            };
        }

        private static decimal GetProfessionalPrice(ProfessionalClient client, ProductType productType)
        {
            bool highRevenue = client.AnnualRevenue > 15_000_000;

            return (highRevenue, productType) switch
            {
                (true, ProductType.HighEndPhone) => 1500,
                (true, ProductType.MidRangePhone) => 1050,
                (true, ProductType.Laptop) => 1400,

                (false, ProductType.HighEndPhone) => 1650,
                (false, ProductType.MidRangePhone) => 1100,
                (false, ProductType.Laptop) => 1500,

                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
