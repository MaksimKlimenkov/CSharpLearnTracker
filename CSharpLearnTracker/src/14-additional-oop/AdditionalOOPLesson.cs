namespace CSharpLearnTracker.AdditionalOOP;

public class AdditionalOOPLesson : Lesson
{
    public AdditionalOOPLesson(string name) : base(name)
    { }

    protected override void StartLesson()
    {
        Console.WriteLine();
        var c1 = new Counter { Value = 15 };
        var c2 = new Counter { Value = 27 };
        Console.WriteLine($"Counter {c1.Value} greater than Counter {c2.Value}? = {c1 > c2}");
        Console.WriteLine($"Counter {c1.Value} + Counter {c2.Value} = Counter {(c1 + c2).Value}");
        int value = c1;
        Console.WriteLine($"Counter1 implict int value: {value}");
        Console.WriteLine($"Exlplict string: {(string)c1}\n");

        Console.WriteLine("Var references");
        int x = 5;
        Console.WriteLine($"X = {x}");
        ref int refX = ref x;
        refX = 10; // x = 10;
        multiply(ref x, 10);
        Console.WriteLine($"X = {x}\n");

        Console.WriteLine("Extensions:");
        string hello = "Hello World";
        Console.WriteLine($"Char l in string {hello} - {hello.CharCount('l')}\n");

        Console.WriteLine("Partial Classes:");
        PartClass partClass = new();
        Console.WriteLine();


        Console.WriteLine("Anonymous Types:");
        var tom = new { Name = "Tom", Language = "C#" };
        Console.WriteLine($"tom object = {{Name = {tom.Name}, Language = {tom.Language}}}\n");


        Console.WriteLine("Tuples:");
        var tuple = (180.5f, "tom", count: 15);
        Console.WriteLine(tuple);
        int a = 10, b = 1;
        Console.WriteLine($"a = {a}, b = {b}");
        (a, b) = swap(a, b);
        Console.WriteLine($"After swap a = {a}, b = {b}\n");

        Console.WriteLine("Records:");
        Person sam = new Person("Sam"); // Immutable
        // sam.Name = "1234"; Dont work
        StructPerson bob = new StructPerson("Bob", 18);
        ClassPerson john = new ClassPerson("John", 18, 185); // Also immutable

        Console.WriteLine(sam);
        Console.WriteLine(bob);
        Console.WriteLine(john);

        bob.Age = 19;
        Console.WriteLine(bob);
        Console.WriteLine($"Structs comprassion sam == new Person(\"Sam\")? {sam == new Person("Sam")}");
        Console.WriteLine($"Structs class comprassion john == new ClassPerson(\"John\", 18, 185)? {john == new ClassPerson("John", 18, 185)}\n");




    }

    public void multiply(ref int x, int y) => x *= y;
    public (int, int) swap(int x, int y) => (y, x);

    public record Person(string Name);
    public record struct StructPerson(string Name, int Age);
    public record class ClassPerson(string Name, int Age, int Height);
}
