namespace Strategy.Domain
{
    public class ShippingCostCalculatorService
    {
        readonly IShippingCostStrategy shippingCostStrategy;

        public ShippingCostCalculatorService(IShippingCostStrategy shippingCostStrategy)
        {
            this.shippingCostStrategy = shippingCostStrategy;
        }

        public double CalculateShippingCost(Order order)
        {
           return shippingCostStrategy.Calculate(order);
        }
    }
}
