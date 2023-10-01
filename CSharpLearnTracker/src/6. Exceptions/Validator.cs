using System.Text;

namespace CSharpLearnTracker.Exceptions;

public class Validator
{
    public bool isString(object s)
    {
        if (s is string || s is StringBuilder) return true;
        throw new ValidatorException($"{s} is not a string");
    }
}
