namespace App.Domain
{
    public class ShippingCalculator
    {
        public double CalculateCost(Order order)
        {
            switch (order.ShippingMethod)
            {
                case ShippingOptions.FedEx:
                    return CalculateForFedEx(order);

                case ShippingOptions.UPS:
                    return CalculateForUPS(order);

                case ShippingOptions.USPS:
                    return CalculateForUSPS(order);

                default:
                    throw new UnknownOrderShippingMethodException();

            }
        }

        double CalculateForUSPS(Order order)
        {
            return order.Product == ProductType.Book ? 3.00d * 0.9 : 3.00d;
        }

        double CalculateForUPS(Order order)
        {
            return order.Weight > 400 ? 4.25d * 1.1 : 4.25d;
        }

        double CalculateForFedEx(Order order)
        {
            return order.Weight > 300 ? 5.00d * 1.1 : 5.00d;
        }
    }
}
