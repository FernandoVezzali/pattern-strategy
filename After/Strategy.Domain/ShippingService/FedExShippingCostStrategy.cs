namespace Strategy.Domain
{
    public class FedExShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 5.00d;
        }
    }
}