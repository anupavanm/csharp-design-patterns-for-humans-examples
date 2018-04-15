using System;

namespace PrototypePattern
{
class Sheep
{
  public string Name { get; set; }

  public string Category { get; set; }

  public Sheep(string name, string category)
  {
    Name = name;
    Category = category;
  }

  public Sheep Clone()
  {
    return MemberwiseClone() as Sheep;
  }
}

  class Program
  {
    static void Main(string[] args)
    {
      var original = new Sheep("Jolly", "Mountain Sheep");
      Console.WriteLine(original.Name); // Jolly
      Console.WriteLine(original.Category); // Mountain Sheep

      var cloned = original.Clone();
      cloned.Name = "Dolly";
      Console.WriteLine(cloned.Name); // Dolly
      Console.WriteLine(cloned.Category); // Mountain Sheep
      Console.WriteLine(original.Name); // Dolly

      Console.ReadLine();
    }
  }
}
