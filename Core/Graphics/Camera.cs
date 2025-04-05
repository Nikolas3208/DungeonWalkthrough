using SFML.Graphics;
using SFML.System;

namespace Core.Graphics;

public struct Camera
{
    /// <summary>
    /// Размер вида камеры
    /// </summary>
    public Vector2u Size;

    /// <summary>
    /// Позиция камеры
    /// </summary>
    public Vector2f Position;

    /// <summary>
    /// Поворот камеры
    /// </summary>
    public float Rotation {  get; set; }

    /// <summary>
    /// Увеличение камеры
    /// </summary>
    public float Zoom {  get; set; }

    /// <summary>
    /// Камера
    /// </summary>
    /// <param name="size"> Размер вида </param>
    /// <param name="position"> Позиция </param>
    public Camera(Vector2u size, Vector2f position)
    {
        Size = size;
        Position = position;
    }

    public FloatRect GetCameraRect() => new FloatRect(new Vector2f(Position.X, Position.Y) - (Vector2f)Size / 2, (Vector2f)Size);

    public Camera UpdateSize(Vector2u size) => new Camera(size, Position);
    public Camera UpdatePosition(Vector2f position) => new Camera(Size, position);
}
