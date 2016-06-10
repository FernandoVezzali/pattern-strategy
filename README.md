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
              └── ShippingCostCalculatorService.cs
              └── IShippingCostStrategy.cs
              └── FedExShippingCostStrategy.cs
              └── UPSShippingCostStrategy.cs
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
    }  

This class calculates the shipping costs for 3 diffrent carriers (FedEx, UPS and USPS). It does the job, but it violates the open/closed principle.

Second problem, this class creates the change of throwing an exception.

