using System;
using App.Domain;
using App.Domain.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests
{
    [TestClass]
    public class ShippingCalculatorTest
    {
        [TestMethod]
        public void When_shipping_via_FedEx_The_shipping_cost_is_5()
        {
            // Arrange
            var shippingCalculator = new ShippingCalculator(new FedExStrategy());
            var order = new Order(ShippingOptions.FedEx);

            // Act
            var cost = shippingCalculator. CalculateCost(order);

            Assert.AreEqual(5.00d, cost);
        }

        [TestMethod]
        public void When_shipping_heavier_product_via_FedEx_The_shipping_cost_is_5()
        {
            // Arrange
            var shippingCalculator = new ShippingCalculator(new FedExStrategy());
            var order = new Order(ShippingOptions.FedEx, 310);

            // Act
            var cost = shippingCalculator.CalculateCost(order);

            Assert.AreEqual(5.5d, cost);
        }

        [TestMethod]
        public void When_shipping_via_UPS_The_shipping_cost_is_425()
        {
            // Arrange
            var shippingCalculator = new ShippingCalculator(new UpsStrategy());
            var order = new Order(ShippingOptions.UPS);

            // Act
            var cost = shippingCalculator.CalculateCost(order);

            Assert.AreEqual(4.25d, cost);
        }

        [TestMethod]
        public void When_shipping_heavier_product_via_UPS_The_shipping_cost_is_4675()
        {
            // Arrange
            var shippingCalculator = new ShippingCalculator(new UpsStrategy());
            var order = new Order(ShippingOptions.UPS, 410);

            // Act
            var cost = shippingCalculator.CalculateCost(order);

            Assert.AreEqual(4.675d, Math.Round(cost, 3));
        }

        [TestMethod]
        public void When_shipping_via_USPS_The_shipping_cost_is_300()
        {
            // Arrange
            var shippingCalculator = new ShippingCalculator(new USPSStrategy());
            var order = new Order(ShippingOptions.USPS);

            // Act
            var cost = shippingCalculator.CalculateCost(order);

            Assert.AreEqual(3.00d, cost);
        }

        [TestMethod]
        public void When_shipping_book_via_USPS_The_shipping_cost_is_27()
        {
            // Arrange
            var shippingCalculator = new ShippingCalculator(new USPSStrategy());
            var order = new Order(ShippingOptions.USPS, 0d, ProductType.Book);

            // Act
            var cost = shippingCalculator.CalculateCost(order);

            Assert.AreEqual(2.7d, cost);
        }
    }
}
