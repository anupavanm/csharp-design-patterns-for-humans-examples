using System;

namespace BridgePattern
{
class Program
{
interface IWebPage
{
  string GetContent();
}

class About : IWebPage
{
  protected ITheme theme;

  public About(ITheme theme)
  {
    this.theme = theme;
  }

  public string GetContent()
  {
    return String.Format("About page in {0}",theme.GetColor());
  }
}

class Careers : IWebPage
{
  protected ITheme theme;

  public Careers(ITheme theme)
  {
    this.theme = theme;
  }

  public string GetContent()
  {
    return String.Format("Careers page in {0}",theme.GetColor());
  }
}

interface ITheme
{
  string GetColor();
}

class DarkTheme : ITheme
{
  public string GetColor()
  {
    return "Dark Black";
  }
}

class LightTheme : ITheme
{
  public string GetColor()
  {
    return "Off White";
  }
}

class AquaTheme : ITheme
{
  public string GetColor()
  {
    return "Light blue";
  }
}
static void Main(string[] args)
{
  var darkTheme = new DarkTheme();

  var about= new About(darkTheme);
  var careers = new Careers(darkTheme);

  Console.WriteLine(about.GetContent());
  Console.WriteLine(careers.GetContent());
  Console.ReadLine();
}
}
}
