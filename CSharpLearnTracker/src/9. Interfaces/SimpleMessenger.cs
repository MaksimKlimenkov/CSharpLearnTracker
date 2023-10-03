namespace CSharpLearnTracker.Interfaces;

interface IMessenger<in T, out K>
{
    void SendMessage(T message);
    K WriteMessage(string text);
}

class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
}

public class Message
{
    public string Text { get; set; }
    public Message(string text) => Text = text;
}

class SimpleMessenger : IMessenger<Message, EmailMessage>
{
    public void SendMessage(Message message) => Console.WriteLine($"Отправляется сообщение: {message.Text}");
    public EmailMessage WriteMessage(string text) => new($"Email: {text}");
}
