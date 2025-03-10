namespace Core.Physics.Colliders;

public class ColliderShape
{
    public AABB AABB { get; set; }
    public Circle Circle { get; set; }
    public Poligon Poligon { get; set; }

    public ColliderShape(AABB aabb)
    {
        AABB = aabb;
    }

    public ColliderShape(Circle circle)
    {
        Circle = circle;
    }

    public ColliderShape(Poligon poligon)
    {
        Poligon = poligon;
    }
}
