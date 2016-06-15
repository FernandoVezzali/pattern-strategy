using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain
{
    public class ShippingCostCalculatorService
    {
        public double CalculateShippingCost(Order order)
        {
            switch (order.ShippingMethod)
            {
                case Order.ShippingOptions.FedEx:
                    return CalculateForFedEx(order);

                case Order.ShippingOptions.UPS:
                    return CalculateForUPS(order);

                case Order.ShippingOptions.USPS:
                    return CalculateForUSPS(order);

                default:
                    throw new UnknownOrderShippingMethodException();

            }
        }

        double CalculateForUSPS(Order order)
        {
            double baseFee = 3.00d;
            if (order.Product == Order.ProductType.Book)
            {
                return baseFee * 0.9;
            }
            return baseFee;
        }

        double CalculateForUPS(Order order)
        {
            double baseFee = 4.25d;
            if (order.Weight > 400)
            {
                return baseFee * 1.1;
            }
            return baseFee;
        }

        double CalculateForFedEx(Order order)
        {
            return 5.00d;
        }
    }
}
