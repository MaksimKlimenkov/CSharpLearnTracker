namespace CSharpLearnTracker;

public partial class PartClass
{
    partial void Read();
    public void DoSmth()
    {
        Console.WriteLine("I dont do that");
        Read();
    }
}
