using System;

namespace AbstractFactoryPattern
{
  interface IDoor
  {

    void GetDescription();

  }
  class WoodenDoor : IDoor
  {
    public void GetDescription()
    {
      Console.WriteLine("I am a wooden door");
    }
  }

  class IronDoor : IDoor
  {
    public void GetDescription()
    {
      Console.WriteLine("I am a iron door");
    }
  }

  interface IDoorFittingExpert
  {
    void GetDescription();
  }

  class Welder : IDoorFittingExpert
  {
    public void GetDescription()
    {
      Console.WriteLine("I can only fit iron doors");
    }
  }

  class Carpenter : IDoorFittingExpert
  {
    public void GetDescription()
    {
      Console.WriteLine("I can only fit wooden doors");
    }
  }

  interface IDoorFactory
  {
    IDoor MakeDoor();
    IDoorFittingExpert MakeFittingExpert();
  }

  // Wooden factory to return carpenter and wooden door
  class WoodenDoorFactory : IDoorFactory
  {
    public IDoor MakeDoor()
    {
      return new WoodenDoor();
    }
    // Iron door factory to get iron door and the relevant fitting expert
    public IDoorFittingExpert MakeFittingExpert()
    {
      return new Carpenter();
    }
  }

  class IronDoorFactory : IDoorFactory
  {
    public IDoor MakeDoor()
    {
      return new IronDoor();
    }

    public IDoorFittingExpert MakeFittingExpert()
    {
      return new Welder();
    }
  }


  class Program
  {
    static void Main(string[] args)
    {
      var woodenDoorFactory = new WoodenDoorFactory();
      var woodenDoor = woodenDoorFactory.MakeDoor();
      var woodenDoorFittingExpert = woodenDoorFactory.MakeFittingExpert();

      woodenDoor.GetDescription(); //Output : I am a wooden door
      woodenDoorFittingExpert.GetDescription();//Output : I can only fit woooden doors

      var ironDoorFactory = new IronDoorFactory();
      var ironDoor = ironDoorFactory.MakeDoor();
      var ironDoorFittingExpert = ironDoorFactory.MakeFittingExpert();

      ironDoor.GetDescription();//Output : I am a iron door
      ironDoorFittingExpert.GetDescription();//Output : I can only fit iron doors

      Console.ReadLine();
    }
  }
}
