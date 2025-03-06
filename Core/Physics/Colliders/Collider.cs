namespace Core.Physics.Colliders;

public class Collider
{
    public ColliderType Type { get; set; }

    public ColliderShape ColliderShape { get; set; }

    public Guid Id { get; }

    public Collider(ColliderType type, ColliderShape colliderShape)
    {
        Type = type;
        ColliderShape = colliderShape;

        Id = Guid.NewGuid();
    }
}
