using System;

namespace StatePattern
{
interface IWritingState {

  void Write(string words);

}

class UpperCase : IWritingState
{
  public void Write(string words)
  {
    Console.WriteLine(words.ToUpper());
  }
}

class LowerCase : IWritingState
{
  public void Write(string words)
  {
    Console.WriteLine(words.ToLower());
  }
}

class DefaultText : IWritingState
{
  public void Write(string words)
  {
    Console.WriteLine(words);
  }
}

class TextEditor {

  private IWritingState mState;

  public TextEditor()
  {
    mState = new DefaultText();
  }

  public void SetState(IWritingState state)
  {
    mState = state;
  }

  public void Type(string words)
  {
    mState.Write(words);
  }

}

  class Program
  {
    static void Main(string[] args)
    {
      var editor = new TextEditor();

      editor.Type("First line");

      editor.SetState(new UpperCase());

      editor.Type("Second Line");
      editor.Type("Third Line");

      editor.SetState(new LowerCase());

      editor.Type("Fourth Line");
      editor.Type("Fifthe Line");

      // Output:
      // First line
      // SECOND LINE
      // THIRD LINE
      // fourth line
      // fifth line

      Console.ReadLine();
    }
  }
}
