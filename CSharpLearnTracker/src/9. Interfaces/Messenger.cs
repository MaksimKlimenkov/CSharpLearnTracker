namespace CSharpLearnTracker.Interfaces;

public interface IMessage
{
    string Text { get; }
}

public interface IPrintable
{
    void Print();
}
public class Messenger<T> where T : IMessage, IPrintable
{
    public void Send(T message)
    {
        Console.WriteLine("Отправка сообщения:");
        message.Print();
    }
}
