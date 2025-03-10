using SFML.System;

namespace Core.Graphics;

public struct Camera
{
    public Vector2u Size;
    public Vector2f Position;

    public float Rotation;
    public float Zoom = 1.5f;

    public Camera(Vector2u size, Vector2f position)
    {
        Size = size;
        Position = position;
    }

    public Camera Resize(Vector2u size) => new Camera(size, Position);

    public Camera MoveTo(Vector2f position) => new Camera(Size, Position + position);

    public Camera SetPosition(Vector2f position) => new Camera(Size, position);

    public Camera SetRotation(float rotation) => new Camera(Size, Position) { Rotation = rotation };
}
