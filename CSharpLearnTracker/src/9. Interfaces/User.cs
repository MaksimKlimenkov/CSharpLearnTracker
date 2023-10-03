namespace CSharpLearnTracker.Interfaces;

public interface IUser<T>
{
    T Id { get; init; }
}

public class User<T> : IUser<T>
{
    public T Id { get; init; }
    public User(T id)
    {
        Id = id;
    }
}
