namespace CSharpLearnTracker.Inheritance;

public class InheritanceLesson
{
    public InheritanceLesson()
    {
        Console.WriteLine("3. Inheritance, Casting, Virtual");
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
