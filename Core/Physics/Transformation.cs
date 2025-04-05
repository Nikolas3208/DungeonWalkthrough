using SFML.Graphics;
using SFML.System;
using System.Numerics;

namespace Core.Physics;

public class Transformation
{
    private Transform _transform = new Transform();
    private Vector2f _oldPosition = new Vector2f();
    private Vector2f _position = new Vector2f();
    private Vector2f _scale = new Vector2f(1, 1);
    private Vector2f _origin = new Vector2f();
    private float _rotation = 0f;

    /// <summary>
    /// Трансформаия
    /// </summary>
    public Transform Transform { get => _transform; }

    /// <summary>
    /// Предыдущая позиция
    /// </summary>
    public Vector2f OldPosition { get => _oldPosition; }

    /// <summary>
    /// Позиция
    /// </summary>
    public Vector2f Position { get => _position; set { _oldPosition = _position; _position = value; UpdateTransform(); } }

    /// <summary>
    /// Маштаб
    /// </summary>
    public Vector2f Scale { get => _scale; set { _scale = value; UpdateTransform(); } }

    /// <summary>
    /// Центер
    /// </summary>
    public Vector2f Origin { get => _origin; set { _origin = value; UpdateTransform(); } }

    /// <summary>
    /// Вращение в градусах
    /// </summary>
    public float Rotation { get => _rotation; set { _rotation = value; UpdateTransform(); } }

    public Transformation()
    {
        UpdateTransform();
    }

    /// <summary>
    /// Обновление трансформации
    /// </summary>
    public void UpdateTransform()
    {
        var angle = -_rotation * 3.141592654F / 180.0F;
        var cosine = MathF.Cos(angle);
        var sine = MathF.Sin(angle);
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

    /// <summary>
    /// Копировать трансформацию
    /// </summary>
    /// <param name="transformation"> Трансформация </param>
    public void UpdateTransform(Transformation transformation)
    {
        _oldPosition = transformation.OldPosition;
        _position = transformation.Position;
        _scale = transformation.Scale;
        _origin = transformation.Origin;
        _rotation = transformation.Rotation;
    }
}
