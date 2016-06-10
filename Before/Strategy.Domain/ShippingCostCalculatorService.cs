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
            return 3.00d;
        }

        double CalculateForUPS(Order order)
        {
            return 4.25d;
        }

        double CalculateForFedEx(Order order)
        {
            return 5.00d;
        }
    }
}
