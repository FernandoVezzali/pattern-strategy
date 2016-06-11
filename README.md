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

1 - If in the future we need to add a new carrier, let's say DHL, we would have to modify the implementation of this class and that violates the open/closed principle, that states: A class should be open for extension not for modification.

2 - In a real world scenario the three methods: CalculateForUSPS, CalculateForUPS and CalculateForFedEx would have an algoritham and ideally they should be kept isolated from each other as any interference wouldn't be desireble.

3 - If this class gets an order that containing an unknown carrier, it will throw an exception that adds antoher undesireble side effect to this class.

This class is doing too many things.

