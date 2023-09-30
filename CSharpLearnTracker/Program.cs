global using CSharpLearnTracker.Abstract;
using CSharpLearnTracker.Classes;
using CSharpLearnTracker.Inheritance;
using CSharpLearnTracker.Structs;

namespace CSharpLearnTracker;
public static class Program
{
    public static void Main()
    {
        ClassesLesson classesLesson = new(1);
        StructsLesson structsLesson = new(2);
        InheritanceLesson inheritanceLesson = new(3);
        AbstractClassesLesson abstractClassesLesson = new(4);
    }
}