using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
  class Program
  {
    // Anything that will be cached is flyweight.
    // Types of tea here will be flyweights.
    class KarakTea
    {
    }

    // Acts as a factory and saves the tea
    class TeaMaker
    {
      private Dictionary<string, KarakTea> mAvailableTea = new Dictionary<string, KarakTea>();

      public KarakTea Make(string preference)
      {
        if (!mAvailableTea.ContainsKey(preference))
        {
          mAvailableTea[preference] = new KarakTea();
        }

        return mAvailableTea[preference];
      }
    }

    class TeaShop
    {
      private Dictionary<int, KarakTea> mOrders = new Dictionary<int, KarakTea>();
      private readonly TeaMaker mTeaMaker;

      public TeaShop(TeaMaker teaMaker)
      {
        mTeaMaker = teaMaker ?? throw new ArgumentNullException("teaMaker", "teaMaker cannot be null");
      }

      public void TakeOrder(string teaType, int table)
      {
        mOrders[table] = mTeaMaker.Make(teaType);
      }

      public void Serve()
      {
        foreach (var table in mOrders.Keys)
        {
          Console.WriteLine("Serving Tea to table # {0}", table);
        }
      }
    }
    static void Main(string[] args)
    {
      var teaMaker = new TeaMaker();
      var teaShop = new TeaShop(teaMaker);

      teaShop.TakeOrder("less sugar", 1);
      teaShop.TakeOrder("more milk", 2);
      teaShop.TakeOrder("without sugar", 5);

      teaShop.Serve();
      Console.ReadLine();
    }
  }
}
