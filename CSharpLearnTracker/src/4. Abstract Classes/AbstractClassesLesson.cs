﻿using CSharpLearnTracker.Shapes;

namespace CSharpLearnTracker;

public class AbstractClassesLesson : Lesson
{
    public AbstractClassesLesson(int id) : base(id)
    {
        Console.WriteLine("4. Abstract Classes");
        Shape[] shapes = new Shape[2] { new Rectangle(10f, 2.2f), new Circle(3.14f) };
        foreach (Shape shape in shapes) PrintShape(shape);
        Console.WriteLine();
    }

    private void PrintShape(Shape shape) => Console.WriteLine(
        $"{shape.ShapeName} perimeter: {shape.GetPerimeter()} m. {shape.ShapeName} area {shape.GetArea()} m^2"
    );
}
