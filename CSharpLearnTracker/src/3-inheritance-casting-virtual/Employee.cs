namespace CSharpLearnTracker.Inheritance;

public class Employee : Person
{
    public string Company { get; set; }
    public override int Age
    {
        get => Age;
        set
        {
            if (value > 17 && value < 110) Age = value;
        }
    }

    public Employee(string name, string company) : base(name)
    {
        Company = company;
    }

    public override void VirtualPrint()
    {
        Console.WriteLine($"Person {Name} works in {Company}");
    }

    public new void Print()
    {
        Console.WriteLine($"Person {Name} works in {Company}");
    }
}
