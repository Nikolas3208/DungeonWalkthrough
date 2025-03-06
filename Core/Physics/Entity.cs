using Core.Physics.Colliders;
using Core.Physics.Transformation;
using SFML.Graphics;
using SFML.System;

namespace Core.Physics;

public class Entity : TransformObject, Drawable
{
    private RigidBody? _rigidBody;
    private Collider? _collider;

    public RigidBody? RigidBody { get => _rigidBody; set { if (value != null) _rigidBody = value; } }
    public Collider? Collider { get => _collider; set { if (value != null) _collider = value; } }

    public virtual void Update(Time deltaTime)
    {

    }

    public void Draw(RenderTarget target, RenderStates states)
    {

    }


}
