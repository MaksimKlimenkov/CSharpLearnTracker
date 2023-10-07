namespace CSharpLearnTracker.AdditionalOOP;

public class Counter
{
    public int Value { get; set; }
    public static bool operator <(Counter c1, Counter c2) => c1.Value < c2.Value;
    public static bool operator >(Counter c1, Counter c2) => c1.Value < c2.Value;
    public static Counter operator +(Counter c1, Counter c2) => new() { Value = c1.Value + c2.Value };
    public static implicit operator int(Counter c1) => c1.Value;
    public static explicit operator string(Counter c1) => $"Counter Value = {c1.Value}";

}
