using Core.Physics.Colliders;

namespace Core.Physics.Collision;

public static class CollisionDetected
{    
    public static bool AABBvsAABB(AABB aabb1, AABB aabb2)
    {
        if (aabb1.Min.X <= aabb2.Max.X && aabb1.Min.X >= aabb2.Min.X
            && aabb1.Max.Y >= aabb2.Min.Y && aabb1.Min.Y <= aabb2.Max.Y)
            return true;

        if (aabb1.Min.Y >= aabb2.Min.Y && aabb1.Min.Y <= aabb2.Max.Y
            && aabb1.Max.X >= aabb2.Min.X && aabb1.Max.X <= aabb2.Max.X)
            return true;

        if (aabb1.Min.X <= aabb2.Min.X && aabb1.Min.Y <= aabb1.Min.Y
            && aabb1.Max.X >= aabb2.Min.X && aabb1.Max.Y >= aabb2.Min.Y
            && aabb1.Max.X <= aabb2.Max.X && aabb1.Max.Y <= aabb2.Max.Y)
            return true;

        if (aabb1.Max.Y >= aabb2.Max.Y && aabb1.Min.Y <= aabb2.Min.Y
            && aabb1.Max.X >= aabb2.Min.X && aabb1.Max.X <= aabb2.Max.X)
            return true;

        if (aabb1.Max.X >= aabb2.Max.X && aabb1.Min.X <= aabb2.Min.X
            && aabb1.Max.Y >= aabb2.Min.Y && aabb1.Max.Y <= aabb2.Max.Y)
            return true;

        if (aabb1.Max.X >= aabb2.Max.X && aabb1.Min.X <= aabb2.Min.X
            && aabb1.Min.Y <= aabb2.Max.Y && aabb1.Min.Y >= aabb2.Min.Y)
            return true;

        return false;
    }

    public static bool CircleVsCircle(Circle circle1, Circle circle2)
    {
        float distance = MathHelper.GetDistance(circle1.Point, circle2.Point);

        if (distance < circle1.Radius * 1.5f || distance < circle2.Radius * 1.5f)
            return true;

        return false;
    }

    public static bool AABBvsCircle(AABB aabb, Circle circle)
    {
        if (circle.Point.Y + circle.Radius >= aabb.Min.Y && circle.Point.Y + circle.Radius <= aabb.Max.Y
            && circle.Point.X >= aabb.Min.X && circle.Point.X <= aabb.Max.X)
            return true;

        if (circle.Point.X + circle.Radius >= aabb.Min.X && circle.Point.X + circle.Radius <= aabb.Max.X
            && circle.Point.Y >= aabb.Min.Y && circle.Point.Y < +aabb.Max.Y)
            return true;

        return false;
    }
}
