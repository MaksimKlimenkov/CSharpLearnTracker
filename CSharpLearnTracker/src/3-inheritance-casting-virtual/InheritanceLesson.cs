namespace CSharpLearnTracker.Inheritance;

public class InheritanceLesson : Lesson
{
    public InheritanceLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        Person person = new("Andrey");

        // Upcasting
        Person employee = new Employee("Maksim", "Tinkoff");
        Person client = new Client("Anna");

        person.Print();
        employee.Print();
        client.Print();

        person.VirtualPrint();
        employee.VirtualPrint();
        client.VirtualPrint();

        //Downcasting
        if (employee is Employee emp) emp.Print();
        Console.WriteLine();
    }
}
