namespace CSharpLearnTracker.Exceptions;

public class ExceptionsLesson : Lesson
{
    public ExceptionsLesson(string name) : base(name)
    {
    }

    protected override void StartLesson()
    {
        Validator validator = new();
        try
        {
            Console.WriteLine(validator.isString("megastring"));
            Console.WriteLine(validator.isString(5));
        }
        catch (ValidatorException ex)
        {
            Console.WriteLine("Valudator Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine();
        }
    }
}
