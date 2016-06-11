# The Strategy Pattern 

Simple exercise where we are going to implement The Strategy Pattern in a small MVC application.

You can compare the application's code [before](https://github.com/FernandoVezzali/pattern-strategy/tree/master/Before) and [after](https://github.com/FernandoVezzali/pattern-strategy/tree/master/After) the refactoring process.

Folder Structure:

```
  
  └── Before
      ├── Strategy.Tests
      ├── Strategy.Web
      └── Strategy.Domain
          └── ShippingCostCalculatorService.cs 
      
  └── After
      ├── Strategy.Tests
      ├── Strategy.Web
      └── Strategy.Domain
          └── ShippingService
              ├── ShippingCostCalculatorService.cs
              ├── IShippingCostStrategy.cs
              ├── FedExShippingCostStrategy.cs
              ├── UPSShippingCostStrategy.cs
              └── USPSShippingCostStrategy.cs
              
``` 

Let's start by opening the class [ShippingCostCalculatorService.cs](https://github.com/FernandoVezzali/pattern-strategy/blob/master/Before/Strategy.Domain/ShippingCostCalculatorService.cs):

    public class ShippingCostCalculatorService
    {
        public double CalculateShippingCost(Order order)
        {
            switch (order.ShippingMethod)
            {
              case Order.ShippingOptions.FedEx:
                  return CalculateForFedEx(order);
    
              case Order.ShippingOptions.UPS:
                  return CalculateForUPS(order);
    
              case Order.ShippingOptions.USPS:
                  return CalculateForUSPS(order);
    
              default:
                  throw new UnknownOrderShippingMethodException();
            }
        }
        
        double CalculateForUSPS(Order order)
        {
            return 3.00d;
        }

        double CalculateForUPS(Order order)
        {
            return 4.25d;
        }

        double CalculateForFedEx(Order order)
        {
            return 5.00d;
        }        
    }  

The only responsability of the class above is to calculate shipping costs, at the moment only 3 diffrent carriers are supported: FedEx, UPS and USPS. In terms of design, there's a few flaws: 

1. If in the future we need to add a new carrier, let's say DHL, we would have to modify the implementation of this class and that violates the open/closed principle, that states: A class should be open for extension not for modification.

2. In a real world scenario the three methods: CalculateForUSPS, CalculateForUPS and CalculateForFedEx would have an algoritham and ideally they should be kept isolated from each other as any interference wouldn't be desireble.

3. If this class gets an order that contains an unknown carrier, an exception will br thrown and that's an undesireble side effect.

This class is doing too many things, let's start by extracting the three methods responsible for the cost calculation. These methods are very similar, they take an order as an argument and return a double. With that said the let's create the following interface:

    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
    
Now we can create 3 classes, implementing the interface we've just created:

    public class FedExShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 5.00d;
        }
    }
    
    public class UPSShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 4.25d;
        }
    }
    
    public class USPSShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 3.00d;
        }
    }
    
The last step is go back to the ShippingCostCalculatorService class and create a new constructor:

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

Now our class does only one thing, it calculates the shipping cost and even better, it doesn't need to know what's the carrier and there's no risk of throwing exceptions.

Now let's check the metrics for the ShippingCostCalculatorService class:

| Metric                         | Before     | After     | 
| ------------------------------ |:----------:|:----------:
| Maintainability Index          | 84         | 85        |
| Cyclomatic Complexity          | 8          | 2         |
| Depth of Inheritance           | 1          | 1         |
| Class Coupling                 | 3          | 2         |
| Lines of Code                  | 13         | 4         |
