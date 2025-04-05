using SFML.System;
using System.Numerics;

namespace Core.Physics.Collision.Colliders;

public struct Circle
{
    /// <summary>
    /// Радиус круга
    /// </summary>
    public float Radius;

    /// <summary>
    /// Центр круга
    /// </summary>
    public Vector2f Center;

    /// <summary>
    /// Круг
    /// </summary>
    /// <param name="radius"> Радиус </param>
    public Circle(float radius) => Radius = radius;

    /// <summary>
    /// Круг
    /// </summary>
    /// <param name="radius"> Радиус </param>
    /// <param name="center"> Центр </param>
    public Circle(float radius, Vector2f center)
    {
        Radius = radius;
        Center = center;
    }

    /// <summary>
    /// Перемешение круга
    /// </summary>
    /// <param name="position"> Позиция </param>
    /// <returns> Круг </returns>
    public Circle Transform(Vector2f position) => new Circle(Radius, new Vector2f(position.X + Radius, position.Y + Radius));
}
