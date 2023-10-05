namespace CSharpLearnTracker.Interfaces;

public class Driver : Person, IMovable
{
    public int MaxSpeed { get; init; }

    public Driver(string name) : base(name)
    {
        MaxSpeed = 11;
    }
}
