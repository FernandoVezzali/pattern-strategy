using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Strategy
{
    public class USPSStrategy: IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return order.Product == ProductType.Book ? 3.00d * 0.9 : 3.00d;
        }
    }
}
