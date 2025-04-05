using System.Numerics;
using SFML.System;

namespace Core.Maths;

public static class VectorConverter
{
    public static Vector2 ToVector2(Vector2f value)
    {
        return new Vector2(value.X, value.Y);
    }

    public static Vector2f ToVector2f(Vector2 value)
    {
        return new Vector2f(value.X, value.Y);
    }
}
