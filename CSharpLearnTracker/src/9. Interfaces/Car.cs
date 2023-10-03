namespace CSharpLearnTracker.Interfaces;

public class Car : IMovable
{
    public int MaxSpeed { get; init; }
    public string Name { get; set; }

    public Car(string name, int maxSpeed)
    {
        Name = name;
        MaxSpeed = maxSpeed;
    }

    public event IMovable.MoveHandler? MoveEvent;

    public void Move()
    {
        Console.WriteLine("Car rides");
        MoveEvent?.Invoke("Car rides");
    }
}
