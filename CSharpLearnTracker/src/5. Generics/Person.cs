namespace CSharpLearnTracker.Generics;

public class Person<T>
{
    public T Id { get; }
    public string Name { get; }

    public Person(T id, string name)
    {
        Id = id;
        Name = name;
    }
}
