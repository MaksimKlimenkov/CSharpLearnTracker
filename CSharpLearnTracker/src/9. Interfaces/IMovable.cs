namespace CSharpLearnTracker.Interfaces;

public interface IMoveEvent
{
    delegate void MoveHandler(string message);

    event MoveHandler? MoveEvent;
}

public interface IMovable : IMoveEvent // Inheritance
{
    const int minSpeed = 0;
    int MaxSpeed { get; init; }
    string Name { get; set; }

    void Move();
}
