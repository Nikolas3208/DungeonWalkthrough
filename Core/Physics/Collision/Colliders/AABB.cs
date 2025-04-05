using SFML.System;

namespace Core.Physics.Collision.Colliders;

public struct AABB
{
    /// <summary>
    /// Минимальная позиция 
    /// </summary>
    public Vector2f Min { get; }

    /// <summary>
    /// Максималная позиция
    /// </summary>
    public Vector2f Max { get; }

    /// <summary>
    /// Ограничивающая рамка, выровненная по оси
    /// </summary>
    /// <param name="min"> Минимальная позиция </param>
    /// <param name="max"> Максимальная позиция </param>
    public AABB(Vector2f min, Vector2f max)
    {
        Min = min;
        Max = max;
    }

    /// <summary>
    /// Ограничивающая рамка, выровненная по оси
    /// </summary>
    /// <param name="minX"> Минимальный Х </param>
    /// <param name="minY"> Минимальный Y </param>
    /// <param name="maxX"> Максимальный Х </param>
    /// <param name="maxY"> Максимальный Y </param>
    public AABB(float minX, float minY, float maxX, float maxY)
    {
        Min = new Vector2f(minX, minY);
        Max = new Vector2f(maxX, maxY);
    }

    /// <summary>
    /// AABB из многоугольника
    /// </summary>
    /// <param name="poligon"> Многоугольник </param>
    /// <returns></returns>
    public AABB Transform(Polygon poligon)
    {
        float minX = float.MaxValue;
        float minY = float.MaxValue;
        float maxX = float.MinValue;
        float maxY = float.MinValue;

        for (int i = 0; i < poligon.Vertices.Count; i++)
        {
            Vector2f v = poligon.Vertices[i];

            if (v.X < minX) { minX = v.X; }
            if (v.X > maxX) { maxX = v.X; }
            if (v.Y < minY) { minY = v.Y; }
            if (v.Y > maxY) { maxY = v.Y; }
        }

        return new AABB(minX, minY, maxX, maxY);
    }

    /// <summary>
    /// AABB из круга
    /// </summary>
    /// <param name="circle"> Круг </param>
    /// <returns></returns>
    public AABB Transform(Circle circle)
    {
        float minX = circle.Center.X - circle.Radius;
        float minY = circle.Center.Y - circle.Radius;
        float maxX = circle.Center.X + circle.Radius;
        float maxY = circle.Center.Y + circle.Radius;

        return new AABB(minX, minY, maxX, maxY);
    }
}
