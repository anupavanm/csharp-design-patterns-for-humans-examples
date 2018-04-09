using System;

namespace FactoryPattern
{
  public interface IDoor
  {
    int GetHeight();
    int GetWidth();
  }

  public class WoodenDoor : IDoor
  {
    private int Height { get; set; }
    private int Width { get; set; }

    public WoodenDoor(int height, int width)
    {
      this.Height = height;
      this.Width = width;
    }

    public int GetHeight()
    {
      return this.Height;
    }
    public int GetWidth()
    {
      return this.Width;
    }
  }

  public static class DoorFactory
  {
    public static IDoor MakeDoor(int height, int width)
    {
      return new WoodenDoor(height, width);
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var door = DoorFactory.MakeDoor(80, 30);
      Console.WriteLine("Height of Door : {0}", door.GetHeight());
      Console.WriteLine("Width of Door : {0}", door.GetWidth());
      Console.ReadLine();
    }
  }
}
