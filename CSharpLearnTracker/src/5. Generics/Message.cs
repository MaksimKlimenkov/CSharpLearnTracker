namespace CSharpLearnTracker;

public class Message
{
    public string Text { get; }
    public Message(string text) => Text = text;
}

public class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
}

public class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
}
