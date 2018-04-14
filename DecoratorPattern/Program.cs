using System;

namespace DecoratorPattern
{
interface ICoffee
{
  int GetCost();
  string GetDescription();
}

class SimpleCoffee : ICoffee
{
  public int GetCost()
  {
    return 5;
  }

  public string GetDescription()
  {
    return "Simple Coffee";
  }
}

class MilkCoffee : ICoffee
{
  private readonly ICoffee mCoffee;

  public MilkCoffee(ICoffee coffee)
  {
    mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
  }
  public int GetCost()
  {
    return mCoffee.GetCost() + 1;
  }

  public string GetDescription()
  {
    return String.Concat(mCoffee.GetDescription(), ", milk");
  }
}

class WhipCoffee : ICoffee
{
  private readonly ICoffee mCoffee;

  public WhipCoffee(ICoffee coffee)
  {
    mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
  }
  public int GetCost()
  {
    return mCoffee.GetCost() + 1;
  }

  public string GetDescription()
  {
    return String.Concat(mCoffee.GetDescription(), ", whip");
  }
}

class VanillaCoffee : ICoffee
{
  private readonly ICoffee mCoffee;

  public VanillaCoffee(ICoffee coffee)
  {
    mCoffee = coffee ?? throw new ArgumentNullException("coffee", "coffee should not be null");
  }
  public int GetCost()
  {
    return mCoffee.GetCost() + 1;
  }

  public string GetDescription()
  {
    return String.Concat(mCoffee.GetDescription(), ", vanilla");
  }
}
  class Program
  {
    static void Main(string[] args)
    {
      var myCoffee = new SimpleCoffee();
      Console.WriteLine("{0:c}",myCoffee.GetCost()); // $ 5.00
      Console.WriteLine("{0}", myCoffee.GetDescription()); // Simple Coffee

      var milkCoffee = new MilkCoffee(myCoffee);
      Console.WriteLine("{0:c}", milkCoffee.GetCost()); // $ 6.00
      Console.WriteLine("{0}", milkCoffee.GetDescription()); // Simple Coffee, milk

      var whipCoffee = new WhipCoffee(milkCoffee);
      Console.WriteLine("{0:c}", whipCoffee.GetCost()); // $ 7.00
      Console.WriteLine("{0}", whipCoffee.GetDescription()); // Simple Coffee, milk, whip

      var vanillaCoffee = new VanillaCoffee(whipCoffee);
      Console.WriteLine("{0:c}", vanillaCoffee.GetCost()); // $ 8.00
      Console.WriteLine("{0}", vanillaCoffee.GetDescription()); // Simple Coffee, milk, whip
      Console.ReadLine();
    }
  }
}
