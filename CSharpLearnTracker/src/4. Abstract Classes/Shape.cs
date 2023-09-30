namespace CSharpLearnTracker.Shapes;

public abstract class Shape
{
    public abstract string ShapeName { get; }
    public abstract double GetPerimeter();
    public abstract double GetArea();
}

public class Rectangle : Shape
{
    public override string ShapeName { get => "Rectangle"; }
    public float Width { get; init; }
    public float Height { get; init; }

    public Rectangle(float w, float h)
    {
        Width = w;
        Height = h;
    }

    public override double GetArea() => Width * Height;

    public override double GetPerimeter() => 2 * Width + 2 * Height;

}

public class Circle : Shape
{
    public override string ShapeName { get => "Circle"; }

    public float Radius { get; init; }

    public Circle(float r) => Radius = r;

    public override double GetArea() => Math.PI * Math.Pow(Radius, 2);

    public override double GetPerimeter() => 2 * Math.PI * Radius;
}