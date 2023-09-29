namespace CSharpLearnTracker.Structs;

public struct Person
{
    public string Name;
    public int Age;

    public Person() { }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public override string ToString() => $"Person{{Name={Name},Age={Age}}}";
}
