using App.Domain.Strategy;

namespace App.Domain
{
    public class ShippingCalculator
    {
        readonly IShippingCostStrategy _shippingCostStrategy;

        public ShippingCalculator(IShippingCostStrategy shippingCostStrategy)
        {
            this._shippingCostStrategy = shippingCostStrategy;
        }

        public double CalculateCost(Order order)
        {
            return _shippingCostStrategy.Calculate(order);
        }
    }
}
