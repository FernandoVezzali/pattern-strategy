using System;
using App.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests
{
    [TestClass]
    public class ShippingCalculatorTest
    {
        [TestMethod]
        public void When_Shipping_Via_FedEx_The_Cost_Is_5()
        {
            // Arrange
            var order = new Order(ShippingOptions.FedEx);

            // Act
            var cost = new ShippingCalculator().CalculateCost(order);

            Assert.AreEqual(5.00d, cost);
        }

        [TestMethod]
        public void When_Shipping_Heavier_Product_Via_FedEx_The_Cost_Is_55()
        {
            // Arrange
            var order = new Order(ShippingOptions.FedEx, 310);

            // Act
            var cost = new ShippingCalculator().CalculateCost(order);

            Assert.AreEqual(5.5d, cost);
        }

        [TestMethod]
        public void When_Shipping_Via_UPS_The_Shipping_Cost_Is_425()
        {
            // Arrange
            var order = new Order(ShippingOptions.UPS);

            // Act
            var cost = new ShippingCalculator().CalculateCost(order);

            Assert.AreEqual(4.25d, cost);
        }

        [TestMethod]
        public void When_Shipping_Heavier_Product_Via_UPS_The_Cost_Is_4675()
        {
            // Arrange
            var order = new Order(ShippingOptions.UPS, 410);

            // Act
            var cost = new ShippingCalculator().CalculateCost(order);

            Assert.AreEqual(4.675d, Math.Round(cost, 3));
        }

        [TestMethod]
        public void When_Shipping_Via_USPS_The_Cost_Is_300()
        {
            // Arrange
            var order = new Order(ShippingOptions.USPS);

            // Act
            var cost = new ShippingCalculator().CalculateCost(order);

            Assert.AreEqual(3.00d, cost);
        }

        [TestMethod]
        public void When_Shipping_Book_Via_USPS_The_Cost_is_27()
        {
            // Arrange
            var order = new Order(ShippingOptions.USPS, 0d, ProductType.Book);

            // Act
            var cost = new ShippingCalculator().CalculateCost(order);

            Assert.AreEqual(2.7d, cost);
        }
    }
}
