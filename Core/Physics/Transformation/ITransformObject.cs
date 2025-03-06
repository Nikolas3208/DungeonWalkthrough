using Core.Physics.Collision;
using SFML.Graphics;
using SFML.System;

namespace Core.Physics.Transformation;

public interface ITransformObject
{
    Transform Transform { get; }
    public Vector2f OldPosition { get; }

    public Vector2f Position { get; set; }

    public Vector2f Scale { get; set; }

    public Vector2f Origin { get; set; }

    public float Rotation { get; set; }

    public void UpdateTransform();
    public void UpdateTransform(ITransformObject transformObject);
}
