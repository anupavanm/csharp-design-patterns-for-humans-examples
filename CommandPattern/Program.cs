using System;

namespace CommandPattern
{
  class Program
  {
    // Receiver
    class Bulb
    {
      public void TurnOn()
      {
        Console.WriteLine("Bulb has been lit");
      }

      public void TurnOff()
      {
        Console.WriteLine("Darkness!");
      }
    }

    interface ICommand
    {
      void Execute();
      void Undo();
      void Redo();
    }

    // Command
    class TurnOn : ICommand
    {
      private Bulb mBulb;

      public TurnOn(Bulb bulb)
      {
        mBulb = bulb ?? throw new ArgumentNullException("Bulb", "Bulb cannot be null");
      }

      public void Execute()
      {
        mBulb.TurnOn();
      }

      public void Undo()
      {
        mBulb.TurnOff();
      }

      public void Redo()
      {
        Execute();
      }
    }

    class TurnOff : ICommand
    {
      private Bulb mBulb;

      public TurnOff(Bulb bulb)
      {
        mBulb = bulb ?? throw new ArgumentNullException("Bulb", "Bulb cannot be null");
      }

      public void Execute()
      {
        mBulb.TurnOff();
      }

      public void Undo()
      {
        mBulb.TurnOn();
      }

      public void Redo()
      {
        Execute();
      }
    }

    // Invoker
    class RemoteControl
    {
      public void Submit(ICommand command)
      {
        command.Execute();
      }
    }

    static void Main(string[] args)
    {
      var bulb = new Bulb();

      var turnOn = new TurnOn(bulb);
      var turnOff = new TurnOff(bulb);

      var remote = new RemoteControl();
      remote.Submit(turnOn); // Bulb has been lit!
      remote.Submit(turnOff); // Darkness!

      Console.ReadLine();
    }
  }
}
