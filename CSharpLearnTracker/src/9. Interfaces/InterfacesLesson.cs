namespace CSharpLearnTracker.Interfaces;

public class InterfacesLesson : Lesson
{
    public InterfacesLesson(int id) : base(id)
    {
        Console.WriteLine($"{id}. Interfaces");
        Person person = new("Andrey");
        Car car = new("Skoda", 150);
        Driver driver = new("Egor");
        car.MoveEvent += (message) => Console.WriteLine($"Handled Move event with message: {message}");
        DoMove(person);
        DoMove(car);
        DoMove(driver);
        Console.WriteLine("Person MaxSpeed: " + ((IMovable)person).MaxSpeed);
        Console.WriteLine("Driver MaxSpeed: " + driver.MaxSpeed);

        IMessenger<Message, EmailMessage> messenger = new SimpleMessenger();
        EmailMessage message = messenger.WriteMessage("Hello World 1");
        messenger.SendMessage(message);

        IMessenger<EmailMessage, Message> outlook = new SimpleMessenger();
        Message simpleMessage = messenger.WriteMessage("Hello World 2");
        messenger.SendMessage(simpleMessage);

        Console.WriteLine();

    }

    public void DoMove(IMovable movable) => movable.Move();
}
