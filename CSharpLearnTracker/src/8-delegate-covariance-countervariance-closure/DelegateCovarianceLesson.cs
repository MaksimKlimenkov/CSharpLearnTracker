namespace CSharpLearnTracker.DelegateCovariance;

public class DelegateCovarianceLesson : Lesson
{
    public DelegateCovarianceLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        // Covariance
        MessageBuilder messageBuilder;
        messageBuilder = (text) => new EmailMessage(text);
        Message message = messageBuilder("First message");
        message.Print();

        // Countervariance
        EmailReceive emailReceive;
        emailReceive = MessageReceive;
        // emailReceive(new SmsMessage("Dont work"));
        // emailReceive(messageBuilder("Also dont work")); 
        emailReceive(new EmailMessage("Second message"));

        // With Generics
        // Covariance
        GMessageBuilder<EmailMessage> emailBuilder = (text) => new EmailMessage(text);
        GMessageBuilder<Message> gMessageBuilder = emailBuilder;
        Message emailMessage = gMessageBuilder("Third message");
        emailMessage.Print();

        // Countervariance
        MessageReceiver<Message> messageReceiver = MessageReceive;
        MessageReceiver<EmailMessage> emailReceiver = messageReceiver;

        // emailReceiver(emailMessage); Dont work
        messageReceiver(new SmsMessage("Fourth message"));
        messageReceiver(new EmailMessage("Fifth message"));

        // Closure
        var factorialIterator = FactorialIterator();
        Console.WriteLine("Factorial iterator by closure:");
        Console.WriteLine(factorialIterator());
        Console.WriteLine(factorialIterator());
        Console.WriteLine(factorialIterator());
        Console.WriteLine(factorialIterator());
        Console.WriteLine(factorialIterator());

        Console.WriteLine();
    }

    public void MessageReceive(Message message) => message.Print(); // Countervariance

    delegate void EmailReceive(EmailMessage message); // Countervariance

    public delegate Message MessageBuilder(string text); // Covariance

    //Generics
    public delegate T GMessageBuilder<out T>(string text) where T : Message; // Covariance

    public delegate void MessageReceiver<in T>(T message) where T : Message; // Countervariance

    public Func<int> FactorialIterator() // Closure
    {
        int x = 0;
        int last = 1;
        return int () =>
        {
            x++;
            last *= x;
            return last;
        };
    }
}
