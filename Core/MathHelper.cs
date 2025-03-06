using SFML.System;

namespace Core;

public class MathHelper
{
    public static float GetDistance(float x1, float y1, float x2, float y2)
    {
        float x = x2 - x1;
        float y = y2 - y1;
        return MathF.Sqrt(x * x + y * y);
    }

    public static float GetDistance(Vector2f v1, Vector2f v2)
    {
        float x = v2.X - v1.X;
        float y = v2.Y - v1.Y;

        return MathF.Sqrt(x * x + y * y);
    }

    public static float GetDistance(Vector2f v)
    {
        return MathF.Sqrt(v.X * v.X + v.Y * v.Y);
    }

    public static Vector2f Normalize(Vector2f v)
    {
        float len = GetDistance(v);
        v.X /= len;
        v.Y /= len;
        return v;
    }
}
