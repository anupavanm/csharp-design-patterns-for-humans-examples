using System;

namespace ProxyPattern
{
  interface IDoor
  {
    void Open();
    void Close();
  }

  class LabDoor : IDoor
  {
    public void Close()
    {
      Console.WriteLine("Closing lab door");
    }

    public void Open()
    {
      Console.WriteLine("Opening lab door");
    }
  }

  class SecuredDoor
  {
    private IDoor mDoor;

    public SecuredDoor(IDoor door)
    {
      mDoor = door ?? throw new ArgumentNullException("door", "door can not be null");
    }

    public void Open(string password)
    {
      if (Authenticate(password))
      {
        mDoor.Open();
      }
      else
      {
        Console.WriteLine("Big no! It ain't possible.");
      }
    }

    private bool Authenticate(string password)
    {
      return password == "$ecr@t" ? true : false;
    }

    public void Close()
    {
      mDoor.Close();
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var door = new SecuredDoor(new LabDoor());
      door.Open("invalid"); // Big no! It ain't possible.

      door.Open("$ecr@t"); // Opening lab door
      door.Close(); // Closing lab door

      Console.ReadLine();
    }
  }
}
