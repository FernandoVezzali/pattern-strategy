using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Tests
{
    [TestClass]
    public class ShippingCostCalculatorService_Test
    {
        [TestMethod]
        public void When_shipping_via_FedEx_The_shipping_cost_is_5()
        {
            var shippingCalculatorService = new ShippingCostCalculatorService();
            var order = Mother.CreateOrder_FedEx();
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(5.00d, cost);
        }

        [TestMethod]
        public void When_shipping_via_UPS_The_shipping_cost_is_425()
        {
            var shippingCalculatorService = new ShippingCostCalculatorService();
            var order = Mother.CreateOrder_UPS(200);
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(4.25d, cost);
        }

        [TestMethod]
        public void When_shipping_heavier_product_via_UPS_The_shipping_cost_is_4675()
        {
            var shippingCalculatorService = new ShippingCostCalculatorService();
            var order = Mother.CreateOrder_UPS(500);
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(4.675d, Math.Round(cost, 3));
        }

        [TestMethod]
        public void When_shipping_via_USPS_The_shipping_cost_is_300()
        {
            var shippingCalculatorService = new ShippingCostCalculatorService();
            var order = Mother.CreateOrder_USPS(Order.ProductType.Electronic);
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(3.00d, cost);
        }

        [TestMethod]
        public void When_shipping_book_via_USPS_The_shipping_cost_is_27()
        {
            var shippingCalculatorService = new ShippingCostCalculatorService();
            var order = Mother.CreateOrder_USPS(Order.ProductType.Book);
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(2.7d, cost);
        }
    }
}
