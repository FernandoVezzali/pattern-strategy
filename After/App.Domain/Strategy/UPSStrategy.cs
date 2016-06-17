using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Strategy
{
    public class UpsStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return order.Weight > 400 ? 4.25d * 1.1 : 4.25d;
        }
    }
}
