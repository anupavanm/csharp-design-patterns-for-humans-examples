using System;
using System.Text;

namespace BuilderPattern
{
  class Program
  {
    class Burger
    {
      private int mSize;
      private bool mCheese;
      private bool mPepperoni;
      private bool mLettuce;
      private bool mTomato;

      public Burger(BurgerBuilder builder)
      {
        this.mSize = builder.Size;
        this.mCheese = builder.Cheese;
        this.mPepperoni = builder.Pepperoni;
        this.mLettuce = builder.Lettuce;
        this.mTomato = builder.Tomato;
      }

      public string GetDescription()
      {
        var sb = new StringBuilder();
        sb.Append(String.Format("This is {0} inch Burger. ", this.mSize));
        return sb.ToString();
      }
    }

    class BurgerBuilder {
      public int Size;
      public bool Cheese;
      public bool Pepperoni;
      public bool Lettuce;
      public bool Tomato;

      public BurgerBuilder(int size)
      {
        this.Size = size;
      }

      public BurgerBuilder AddCheese()
      {
        this.Cheese = true;
        return this;
      }

      public BurgerBuilder AddPepperoni()
      {
        this.Pepperoni = true;
        return this;
      }

      public BurgerBuilder AddLettuce()
      {
        this.Lettuce = true;
        return this;
      }

      public BurgerBuilder AddTomato()
      {
        this.Tomato = true;
        return this;
      }

      public Burger Build()
      {
        return new Burger(this);
      }
    }

    static void Main(string[] args)
    {
      var burger = new BurgerBuilder(4).AddCheese()
                                        .AddPepperoni()
                                        .AddLettuce()
                                        .AddTomato()
                                        .Build();
      Console.WriteLine(burger.GetDescription());
      Console.ReadLine();
    }
  }
}
