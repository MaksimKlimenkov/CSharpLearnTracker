namespace CSharpLearnTracker.DelegateCovariance;

public class Message
{
    public string Text { get; }
    public Message(string text) => Text = text;
    public virtual void Print() => Console.WriteLine($"Message: {Text}");
}

public class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
    public override void Print() => Console.WriteLine($"Email: {Text}");
}

public class SmsMessage : Message
{
    public SmsMessage(string text) : base(text) { }
    public override void Print() => Console.WriteLine($"Sms: {Text}");
}