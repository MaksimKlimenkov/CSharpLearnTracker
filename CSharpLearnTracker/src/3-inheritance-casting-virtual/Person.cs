namespace CSharpLearnTracker.Inheritance;

public class Person
{
    private string _name = "";
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public virtual int Age
    {
        get => Age;
        set
        {
            if (value > 0 && value < 110) Age = value;
        }
    }

    public Person(string name)
    {
        Name = name;
    }

    public virtual void VirtualPrint()
    {
        Console.WriteLine($"Person {_name}");
    }

    public void Print()
    {
        Console.WriteLine($"Person {_name}");
    }
}
