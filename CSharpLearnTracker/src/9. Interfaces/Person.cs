namespace CSharpLearnTracker.Interfaces;

public class Person : IMovable
{
    public string Name { get; set; }

    private int maxSpeed;
    int IMovable.MaxSpeed { get => maxSpeed; init => maxSpeed = value; } //Explict implementation

    public Person(string name)
    {
        Name = name;
        maxSpeed = 10;
    }

    public event IMovable.MoveHandler? MoveEvent;

    public void Move()
    {
        Console.WriteLine("Walking");
        MoveEvent?.Invoke("Person walking");
    }
}
