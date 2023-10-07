namespace CSharpLearnTracker.AdditionalOOP;

public static class StringExtension
{
    public static int CharCount(this string str, char target)
    {
        int counter = 0;
        foreach (char c in str) if (target == c) counter++;
        return counter;
    }
}
