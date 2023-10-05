using System.Text;
using System.Text.RegularExpressions;

namespace CSharpLearnTracker.Strings;

public class StringsLesson : Lesson
{
    public StringsLesson(int id) : base(id)
    {
        Console.WriteLine($"{id}. Strings");
        string s1 = "hello";
        string s2 = new('a', 6);
        string s3 = new(new char[] { 'w', 'o', 'r', 'l', 'd' });
        string s4 = new(new char[] { 'w', 'o', 'r', 'l', 'd' }, 2, 3);
        string text = """
            Big text;
            Yeah;
        """;
        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(s3);
        Console.WriteLine(s4);
        Console.WriteLine(text);
        Console.WriteLine("['" + string.Join("', '", new char[] { '1', '2', '3' }) + "']");
        string formated = string.Format("d4 = {0:d4}, p3 = {1:p3}, x = {2:x}, c3 = {3:c3}", 37, 227.5f, 255, 98.6);

        StringBuilder stringBuilder = new();
        stringBuilder.Append(s1);
        stringBuilder.Append(" ");
        stringBuilder.Append(s3);
        stringBuilder.Append("\n");
        stringBuilder.Append(formated);
        Console.WriteLine(stringBuilder.ToString());

        string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";
        Regex regex = new Regex(@"туп(\w*)");
        var matches = regex.Matches(s);
        foreach (Match match in matches)
            Console.WriteLine(match.Value);
        Console.WriteLine();

    }
}
