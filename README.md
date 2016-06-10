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
              └── FedExShippingCostStrategy.cs
              └── IShippingCostStrategy.cs
              └── ShippingCostCalculatorService.cs
              └── UPSShippingCostStrategy.cs
              └── USPSShippingCostStrategy.cs
              
``` 

It's a shipping calculator written in C# to demonstrate the benefits of the pattern:

The code below violates the open/closed principal and needs to be refactored: 

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

The code above [can be find here](https://github.com/FernandoVezzali/pattern-strategy/blob/master/Before/Strategy.Domain/ShippingCostCalculatorService.cs)
