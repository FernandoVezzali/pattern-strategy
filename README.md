# The Strategy Pattern 

Simple exercise where we are going to apply The Strategy Pattern in a small C# application. 

Disclaimer: This is not about MVC, we will be focused in the domain layer. 

Our case study will be the ShippingCostCalculator class, we will redesign this class, improving it by applying the strategy patter. 

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

Mind the class above, at first glance it looks good, the unit tests are passing and it works in run-time, but from a design perspective, it is bad. 

Single Responsibility Principle:

A class should have only a single responsibility, the ShippingCostCalculator class has more than one responsibility, it should calculate shipping costs without knowing the different carriers, as if in the future we need to add a new carrier, we would have to change this class and that would violate the Single Responsibility Principle (SRP).

> In the context of the Single Responsibility Principle (SRP) we define a responsibility to be “a reason for change.” If you can think of more than one motive for changing a class, then that class has more than one responsibility. - Bob Martin

So the question is, how do we make this class calculate shipping costs without knowing the carriers ? The answer is simple, we just need to create add an abstraction:

    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
	
The second step is to extract the three methods responsible for the cost calculation and make them implement our new interface: 

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
	
Last step is to get rid of the switch statement replacing it by a constructor that will receive an instance of any class that implements the interface:

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

Only one responsibility:

> Now our class does only one thing, it calculates the shipping costs. Most importantly, it permorns the calculation without knowing the carriers neither their algorithams.

Now let's check the metrics before and after for the [ShippingCostCalculatorService](https://github.com/FernandoVezzali/pattern-strategy/blob/master/After/Strategy.Domain/ShippingService/ShippingCostCalculatorService.cs) class:

| Metric                         | Before     | After     | 
| ------------------------------ |:----------:|:----------:
| Maintainability Index          | 84         | 85        |
| Cyclomatic Complexity          | 8          | 2         |
| Depth of Inheritance           | 1          | 1         |
| Class Coupling                 | 3          | 2         |
| Lines of Code                  | 13         | 4         |

You can compare the application's code [before](https://github.com/FernandoVezzali/pattern-strategy/tree/master/Before) and [after](https://github.com/FernandoVezzali/pattern-strategy/tree/master/After) the refactoring process.
