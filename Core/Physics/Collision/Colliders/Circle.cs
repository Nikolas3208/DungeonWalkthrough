using SFML.System;
using System.Numerics;

namespace Core.Physics.Collision.Colliders;

public struct Circle
{
    /// <summary>
    /// ������ �����
    /// </summary>
    public float Radius;

    /// <summary>
    /// ����� �����
    /// </summary>
    public Vector2f Center;

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="radius"> ������ </param>
    public Circle(float radius) => Radius = radius;

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="radius"> ������ </param>
    /// <param name="center"> ����� </param>
    public Circle(float radius, Vector2f center)
    {
        Radius = radius;
        Center = center;
    }

    /// <summary>
    /// ����������� �����
    /// </summary>
    /// <param name="position"> ������� </param>
    /// <returns> ���� </returns>
    public Circle Transform(Vector2f position) => new Circle(Radius, new Vector2f(position.X + Radius, position.Y + Radius));
}
