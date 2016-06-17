using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Strategy
{
    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
}
