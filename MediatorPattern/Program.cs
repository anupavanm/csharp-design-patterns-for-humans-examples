using System;

namespace MediatorPattern
{
interface IChatRoomMediator
{
  void ShowMessage(User user, string message);
}

//Mediator
class ChatRoom : IChatRoomMediator
{
  public void ShowMessage(User user, string message)
  {
    Console.WriteLine("{0} [{1}]:{2}", DateTime.Now.ToString("MMMM dd, H:mm"), user.GetName(), message);
  }
}

class User
{
  private string mName;
  private IChatRoomMediator mChatRoom;

  public User(string name, IChatRoomMediator chatroom)
  {
    mChatRoom = chatroom;
    mName = name;
  }

  public string GetName()
  {
    return mName;
  }

  public void Send(string message)
  {
    mChatRoom.ShowMessage(this, message);
  }
}


  class Program
  {
    static void Main(string[] args)
    {
      var mediator = new ChatRoom();

      var john = new User("John", mediator);
      var jane = new User("Jane", mediator);

      john.Send("Hi there!");
      jane.Send("Hey!");

      //April 14, 20:05[John]:Hi there!
      //April 14, 20:05[Jane]:Hey!

      Console.ReadLine();
    }
  }
}
