namespace CSharpLearnTracker.Generics;

public class GenericsLesson : Lesson
{
    public GenericsLesson(int id) : base(id)
    {
        Console.WriteLine($"{id}. Generics");
        Person<int> person = new(1, "Int Id Person");
        Person<string> person1 = new("6648392ab75c8de", "String Id Person");
        Person<Guid> person2 = new(new Guid(), "Guid Id person");

        Console.WriteLine(person.Id);
        Console.WriteLine(person1.Id);
        Console.WriteLine(person2.Id);
        Console.WriteLine();

        int a = 3;
        int b = 7;
        Console.WriteLine($"a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine();

        EmailMessage emailMessage = new("Email message");
        SmsMessage smsMessage = new("Sms message");
        SendMessage(emailMessage);
        SendMessage(smsMessage);
        Console.WriteLine();
    }

    void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }

    void SendMessage<T>(T message) where T : Message =>
        Console.WriteLine($"Message: {message.Text}");
}
