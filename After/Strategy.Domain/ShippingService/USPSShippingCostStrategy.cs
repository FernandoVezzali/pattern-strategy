namespace Strategy.Domain
{
    public class USPSShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 3.00d;
        }
    }
}