using SFML.System;

namespace Core.Physics.Colliders;

public struct Circle
{
    public float Radius { get; }

    public Vector2f Point { get; private set; }

    public Circle(float radius)
    {
        Radius = radius;
        Point = new Vector2f(-radius, -radius) / 2;
    }
    public Circle(Vector2f point, float radius)
    {
        Radius = radius;
        Point = new Vector2f(point.X + radius / 2, point.Y + radius / 2);
    }

    public Circle(Circle circle)
    {
        Point = circle.Point;
        Radius = circle.Radius;
    }

    public Circle UpdatePosition(Vector2f position) => new Circle(Point + position, Radius);

}
