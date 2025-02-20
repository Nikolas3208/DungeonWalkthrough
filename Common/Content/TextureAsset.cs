using SFML.Graphics;

namespace Common.Content;

public class TextureAsset : Asset
{
    public Texture Texture { get; }
    public TextureAsset(string name, string fullPath) : base(name, fullPath)
    {
        Type = AssetEnum.Texture;
        Texture = new Texture(fullPath);
    }
}