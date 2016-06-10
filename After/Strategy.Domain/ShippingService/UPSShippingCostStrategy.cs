namespace Strategy.Domain
{
    public class UPSShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 4.25d;
        }
    }
}