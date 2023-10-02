namespace CSharpLearnTracker.Exceptions;

public class ExceptionsLesson : Lesson
{
    public ExceptionsLesson(int id) : base(id)
    {
        Console.WriteLine($"{id}. Exceptions");
        Validator validator = new();
        try
        {
            Console.WriteLine(validator.isString("megastring"));
            Console.WriteLine(validator.isString(id));
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
