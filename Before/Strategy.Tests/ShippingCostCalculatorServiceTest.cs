using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategy.Domain;
using System;

namespace Strategy.Tests
{
    [TestClass]
    public class ShippingCostCalculatorServiceTest
    {
        private ShippingCostCalculatorService _shippingCalculatorService;

        [TestInitialize]
        public void TestInitialize()
        {
            _shippingCalculatorService = new ShippingCostCalculatorService();
        }

        [TestMethod]
        public void When_shipping_via_FedEx_The_shipping_cost_is_5()
        {
            // Arrange
            var order = new Order(ShippingOptions.FedEx);

            // Act
            var cost = _shippingCalculatorService.CalculateShippingCost(order);

            Assert.AreEqual(5.00d, cost);
        }

        [TestMethod]
        public void When_shipping_heavier_product_via_FedEx_The_shipping_cost_is_5()
        {
            // Arrange
            var order = new Order(ShippingOptions.FedEx, 310);

            // Act
            var cost = _shippingCalculatorService.CalculateShippingCost(order);

            Assert.AreEqual(5.5d, cost);
        }

        [TestMethod]
        public void When_shipping_via_UPS_The_shipping_cost_is_425()
        {
            // Arrange
            var order = new Order(ShippingOptions.UPS);

            // Act
            var cost = _shippingCalculatorService.CalculateShippingCost(order);

            Assert.AreEqual(4.25d, cost);
        }

        [TestMethod]
        public void When_shipping_heavier_product_via_UPS_The_shipping_cost_is_4675()
        {
            // Arrange
            var order = new Order(ShippingOptions.UPS, 410);

            // Act
            var cost = _shippingCalculatorService.CalculateShippingCost(order);

            Assert.AreEqual(4.675d, Math.Round(cost, 3));
        }

        [TestMethod]
        public void When_shipping_via_USPS_The_shipping_cost_is_300()
        {
            // Arrange
            var order = new Order(ShippingOptions.USPS);

            // Act
            var cost = _shippingCalculatorService.CalculateShippingCost(order);

            Assert.AreEqual(3.00d, cost);
        }

        [TestMethod]
        public void When_shipping_book_via_USPS_The_shipping_cost_is_27()
        {
            // Arrange
            var order = new Order(ShippingOptions.USPS, 0d, ProductType.Book);

            // Act
            var cost = _shippingCalculatorService.CalculateShippingCost(order);

            Assert.AreEqual(2.7d, cost);
        }
    }
}
