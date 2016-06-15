using Strategy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Strategy.Domain.Order;

namespace Strategy.Tests
{
    public static class Mother
    {
        public static Order CreateOrder_FedEx()
        {
            return new Order()
            {
                ShippingMethod = Order.ShippingOptions.FedEx,
                Destination = Mother.CreateAddress_Destination(),
                Origin = Mother.CreateAddress_Origin()
            };
        }

        public static Order CreateOrder_USPS(ProductType productType)
        {
            return new Order()
            {
                Product = productType,
                ShippingMethod = Order.ShippingOptions.USPS,
                Destination = Mother.CreateAddress_Destination(),
                Origin = Mother.CreateAddress_Origin()
            };
        }

        public static Order CreateOrder_UPS(double Weight = 0d)
        {
            return new Order()
            {
                ShippingMethod = Order.ShippingOptions.UPS,
                Destination = Mother.CreateAddress_Destination(),
                Origin = Mother.CreateAddress_Origin(),
                Weight = Weight
            };
        }

        public static Address CreateAddress_Origin()
        {
            return new Address()
            {
                ContactName = "David Starr",

                AddressLine1 = "185 Lincoln St.",
                AddressLine2 = "Suite 305",
                AddressLine3 = null,
                City = "Hingham",
                Country = "U.S.",
                Region = "MA",
                PostalCode = "02043-1741"
            };
        }

        public static Address CreateAddress_Destination()
        {
            return new Address()
            {
                ContactName = "Homer Simpson",

                AddressLine1 = "123 Elm",
                AddressLine2 = null,
                AddressLine3 = null,
                City = "Springfield",
                Country = "U.S.",
                Region = "Iowa",
                PostalCode = "11111"
            };
        }
    }
}
