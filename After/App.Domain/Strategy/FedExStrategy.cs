using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Strategy
{
    public class FedExStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return order.Weight > 300 ? 5.00d * 1.1 : 5.00d;
        }
    }
}
