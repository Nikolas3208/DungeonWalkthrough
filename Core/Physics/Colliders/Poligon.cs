using SFML.System;

namespace Core.Physics.Colliders;

public struct Poligon
{
    public Vector2f Position { get; set; }
    public Vector2f[] Vertices { get; set; }

    public Poligon(Vector2f position, params Vector2f[] vertices)
    {
        Position = position;
        Vertices = vertices;
    }

    public Poligon(Poligon poligon)
    {
        Position = poligon.Position;
        Vertices = poligon.Vertices;
    }
}
