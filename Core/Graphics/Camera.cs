using SFML.Graphics;
using SFML.System;

namespace Core.Graphics;

public struct Camera
{
    /// <summary>
    /// ������ ���� ������
    /// </summary>
    public Vector2u Size;

    /// <summary>
    /// ������� ������
    /// </summary>
    public Vector2f Position;

    /// <summary>
    /// ������� ������
    /// </summary>
    public float Rotation {  get; set; }

    /// <summary>
    /// ���������� ������
    /// </summary>
    public float Zoom {  get; set; }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="size"> ������ ���� </param>
    /// <param name="position"> ������� </param>
    public Camera(Vector2u size, Vector2f position)
    {
        Size = size;
        Position = position;
    }

    public FloatRect GetCameraRect() => new FloatRect(new Vector2f(Position.X, Position.Y) - (Vector2f)Size / 2, (Vector2f)Size);

    public Camera UpdateSize(Vector2u size) => new Camera(size, Position);
    public Camera UpdatePosition(Vector2f position) => new Camera(Size, position);
}
