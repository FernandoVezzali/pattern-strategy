namespace Strategy.Domain
{
    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
}
