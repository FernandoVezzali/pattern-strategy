namespace App.Domain
{
    public enum ShippingOptions
    {
        UPS = 100,
        FedEx = 200,
        USPS = 300,
    };

    public enum ProductType
    {
        Book = 1,
        Electronic = 2
    };

    public class Order
    {
        public Order(ShippingOptions shippingMethod, double weight = 0d, ProductType product = ProductType.Electronic)
        {
            ShippingMethod = shippingMethod;
            Product = product;
            Weight = weight;
        }

        public ShippingOptions ShippingMethod { get; }
        public ProductType Product { get; }
        public double Weight { get; }
    }
}
