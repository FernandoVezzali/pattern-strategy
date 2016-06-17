# The Strategy Pattern 

Simple exercise where we are going to apply The Strategy Pattern in a small C# application. 

Our case study will be the ShippingCostCalculator class, we will redesign this class, improving it by applying the strategy patter. 

Folder Structure:

```
  
  └── Before
      ├── App.Tests
      ├── App.Web
      └── App.Domain
          └── ShippingCalculator.cs 
      
  └── After
      ├── App.Tests
      ├── App.Web
      └── App.Domain
          ├── ShippingCalculator.cs 	  
          └── Strategy
              ├── IShippingCostStrategy.cs
              ├── FedExStrategy.cs
              ├── UPSStrategy.cs
              └── USPSStrategy.cs
              
``` 

Let's start by opening the class [ShippingCalculator.cs](https://github.com/FernandoVezzali/pattern-strategy/blob/master/Before/App.Domain/ShippingCalculator.cs):

    public class ShippingCalculator
    {
        public double CalculateCost(Order order)
        {
            switch (order.ShippingMethod)
            {
                case ShippingOptions.FedEx:
                    return CalculateForFedEx(order);

                case ShippingOptions.UPS:
                    return CalculateForUPS(order);

                case ShippingOptions.USPS:
                    return CalculateForUSPS(order);

                default:
                    throw new UnknownOrderShippingMethodException();

            }
        }

        double CalculateForUSPS(Order order)
        {
            return order.Product == ProductType.Book ? 3.00d * 0.9 : 3.00d;
        }

        double CalculateForUPS(Order order)
        {
            return order.Weight > 400 ? 4.25d * 1.1 : 4.25d;
        }

        double CalculateForFedEx(Order order)
        {
            return order.Weight > 300 ? 5.00d * 1.1 : 5.00d;
        }
    }

Mind the class above, at first glance it looks good, the unit tests are passing and it works in run-time, but from a design perspective, it is bad. 

## Single Responsibility Principle:

A class should have only a single responsibility, the ShippingCostCalculator class has more than one responsibility, it should calculate shipping costs without knowing the different carriers, as if in the future we need to add a new carrier, we would have to change this class and that would violate the Single Responsibility Principle (SRP).

> In the context of the Single Responsibility Principle (SRP) we define a responsibility to be “a reason for change.” If you can think of more than one motive for changing a class, then that class has more than one responsibility. - Bob Martin

## Creating an abstraction

So the problem is, how do we make this class calculate shipping costs without knowing carrier details ? All the three carriers share two things in common: They take an order as a parameter and return a double. We can now create an interface with the same signature:

    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
    
## Creating the strategies
	
The second step is to remove the three methods responsible for the cost calculation and create 3 classes (3 strategies) and make each of them implement our interface: 

    public class FedExStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return order.Weight > 300 ? 5.00d * 1.1 : 5.00d;
        }
    }
    
    public class USPSStrategy: IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return order.Product == ProductType.Book ? 3.00d * 0.9 : 3.00d;
        }
    }
    
    public class UpsStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return order.Weight > 400 ? 4.25d * 1.1 : 4.25d;
        }
    }

## Last step

 Now that we have everything we need, it's just a matter of getting rid of the switch statement and inject the strategies by the constructor:

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

Now the class depends on an abstraction, instead of three concrete classes ! 

If you are still not convinced, let's check the metrics for the class:

| Metric                         | Before     | After     | 
| ------------------------------ |:----------:|:----------:
| Maintainability Index          | 82         | 85        |
| Cyclomatic Complexity          | 11         | 2         |
| Depth of Inheritance           | 1          | 1         |
| Class Coupling                 | 3          | 2         |
| Lines of Code                  | 13         | 4         |

You can compare the class code [before](https://github.com/FernandoVezzali/pattern-strategy/blob/master/Before/App.Domain/ShippingCalculator.cs) and [after](https://github.com/FernandoVezzali/pattern-strategy/blob/master/After/App.Domain/ShippingCalculator.cs) the refactoring process.
