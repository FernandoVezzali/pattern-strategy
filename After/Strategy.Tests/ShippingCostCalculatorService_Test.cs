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
        public void When_shipping_via_UPS_The_shipping_cost_is_425()
        {
            var strategy = new UPSShippingCostStrategy();
            var shippingCalculatorService = new ShippingCostCalculatorService(strategy);
            var order = Mother.CreateOrder_UPS();
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(4.25d, cost);
        }

        [TestMethod]
        public void When_shipping_via_USPS_The_shipping_cost_is_300()
        {
            var strategy = new USPSShippingCostStrategy();
            var shippingCalculatorService = new ShippingCostCalculatorService(strategy);
            var order = Mother.CreateOrder_USPS();
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(3.00d, cost);
        }

        [TestMethod]
        public void When_shipping_via_FedEx_The_shipping_cost_is_5()
        {
            var strategy = new FedExShippingCostStrategy();
            var shippingCalculatorService = new ShippingCostCalculatorService(strategy);
            var order = Mother.CreateOrder_FedEx();
            var cost = shippingCalculatorService.CalculateShippingCost(order);
            Assert.AreEqual(5.00d, cost);
        }
    }
}
