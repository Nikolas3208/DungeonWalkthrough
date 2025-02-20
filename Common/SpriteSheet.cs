using SFML.Graphics;

namespace Common;

public class SpriteSheet
{
    private bool _isSmooth;

    public string Name { get; }
    public Sprite Sprite { get; }

    public int SubWidth { get; }
    public int SubHeight { get; }

    public int CountX { get; }
    public int CountY { get; }

    public bool IsSmooth { get => _isSmooth; set { _isSmooth = value; Sprite.Texture.Smooth = value; } }

    public SpriteSheet(string name, Sprite sprite, bool isSmooth = false)
    {
        Name = name;
        Sprite = sprite;
    }

    public SpriteSheet(string name, Texture texture, bool isSmooth = false) 
    {
        Name = name;
        Sprite = new Sprite(texture);
        _isSmooth = isSmooth;
    }
}