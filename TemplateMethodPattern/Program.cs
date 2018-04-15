using System;

namespace TemplateMethodPattern
{
  abstract class Builder
  {
    // Template method
    public void Build()
    {
      Test();
      Lint();
      Assemble();
      Deploy();
    }

    abstract public void Test();
    abstract public void Lint();
    abstract public void Assemble();
    abstract public void Deploy();
  }

  class AndroidBuilder : Builder
  {
    public override void Assemble()
    {
      Console.WriteLine("Assembling the android build");
    }

    public override void Deploy()
    {
      Console.WriteLine("Deploying android build to server");
    }

    public override void Lint()
    {
      Console.WriteLine("Linting the android code");
    }

    public override void Test()
    {
      Console.WriteLine("Running android tests");
    }
  }


  class IosBuilder : Builder
  {
    public override void Assemble()
    {
      Console.WriteLine("Assembling the ios build");
    }

    public override void Deploy()
    {
      Console.WriteLine("Deploying ios build to server");
    }

    public override void Lint()
    {
      Console.WriteLine("Linting the ios code");
    }

    public override void Test()
    {
      Console.WriteLine("Running ios tests");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var androidBuilder = new AndroidBuilder();
      androidBuilder.Build();

      // Output:
      // Running android tests
      // Linting the android code
      // Assembling the android build
      // Deploying android build to server

      var iosBuilder = new IosBuilder();
      iosBuilder.Build();

      // Output:
      // Running ios tests
      // Linting the ios code
      // Assembling the ios build
      // Deploying ios build to server

      Console.ReadLine();
    }
  }
}
