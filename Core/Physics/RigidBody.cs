using Core.Physics.Colliders;
using Core.Physics.Transformation;
using SFML.System;

namespace Core.Physics;

public class RigidBody : TransformObject
{
    public bool IsCollision { get; set; }

    public bool IsGravity { get; set; } = true;

    public Vector2f Velocity { get; set; }
    public Vector2f Direction { get; set; }


    public Guid Id { get; }
    public BodyType Type { get; set; }

    public Collider Collider { get; set; }

    public RigidBody(Collider collider, BodyType type = BodyType.Static)
    {
        Collider = collider;
        Type = type;

        Id = Guid.NewGuid();
    }
}
