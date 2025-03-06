using SFML.Graphics;
using SFML.System;

namespace Core.Physics.Transformation;

public class TransformObject : ITransformObject
{
    private Transform _transform;
    private Vector2f _oldPosition;
    private Vector2f _position;
    private Vector2f _scale = new Vector2f(1, 1);
    private Vector2f _origin;
    private float _rotation;

    public Transform Transform { get => _transform; }

    public Vector2f OldPosition { get => _oldPosition; }
    public Vector2f Position { get => _position; set { _oldPosition = _position; _position = value; UpdateTransform(); } }
    public Vector2f Scale { get => _scale; set { _scale = value; UpdateTransform(); } }
    public Vector2f Origin { get => _origin; set { _origin = value; UpdateTransform(); } }
    public float Rotation { get => _rotation; set { _rotation = value; UpdateTransform(); } }

    public void UpdateTransform()
    {
        var angle = -_rotation * 3.141592654F / 180.0F;
        var cosine = (float)Math.Cos(angle);
        var sine = (float)Math.Sin(angle);
        var sxc = _scale.X * cosine;
        var syc = _scale.Y * cosine;
        var sxs = _scale.X * sine;
        var sys = _scale.Y * sine;
        var tx = (-_origin.X * sxc) - (_origin.Y * sys) + _position.X;
        var ty = (_origin.X * sxs) - (_origin.Y * syc) + _position.Y;

        _transform = new Transform(sxc, sys, tx,
                                    -sxs, syc, ty,
                                    0.0F, 0.0F, 1.0F);
    }

    public void UpdateTransform(ITransformObject transformObject)
    {
        _oldPosition = transformObject.OldPosition;
        _position = transformObject.Position;
        _scale = transformObject.Scale;
        _origin = transformObject.Origin;
        _rotation = transformObject.Rotation;

        UpdateTransform();
    }

}
