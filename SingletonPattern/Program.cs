using System;

namespace SingletonPattern
{
  public class President
  {
    static President instance;
    // Private constructor
    private President()
    {
      //Hiding the Constructor
    }

    // Public constructor
    public static President get_instance()
    {
      if (instance == null) {
        instance = new President();
      }
      return instance;
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      President a = President.get_instance();
      President b = President.get_instance();

      Console.WriteLine((a==b).ToString());
      Console.ReadLine();
    }
  }
}
