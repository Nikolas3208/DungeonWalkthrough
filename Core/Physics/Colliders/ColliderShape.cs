namespace Core.Physics.Colliders;

public class ColliderShape
{
    public AABB AABB { get; set; }
    public Circle Circle { get; set; }

    public ColliderShape(AABB aabb)
    {
        AABB = aabb;
    }

    public ColliderShape(Circle circle)
    {
        Circle = circle;
    }
}
