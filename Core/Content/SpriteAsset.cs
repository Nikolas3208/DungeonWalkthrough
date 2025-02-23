using SFML.Graphics;

namespace Core.Content;

public class SpriteAsset : Asset
{
    /// <summary>
    /// Текстура обекта ( Береться из спрайта )
    /// </summary>
    public Texture Texture { get => Sprite.Texture; }

    /// <summary>
    /// Спрайт обекта
    /// </summary>
    public Sprite Sprite { get; }

    /// <summary>
    /// Ексземпялр обекта ( Спрайт создаеться из текстуры лежащей в fullPath )
    /// </summary>
    /// <param name="name"> Имя обекта </param>
    /// <param name="fullPath"> Путь к файлу </param>
    public SpriteAsset(string name, string fullPath) : base(name, fullPath)
    {
        Sprite = new Sprite(new Texture(fullPath));
        Type = AssetType.Sprite;
    }

    /// <summary>
    /// Ексземпялр обекта 
    /// </summary>
    /// <param name="name"> Имя обекта </param>
    /// <param name="fullPath"> Путь к файлу </param>
    /// <param name="sprite"> Спрайт </param>
    public SpriteAsset(string name, string fullPath, Sprite sprite) : this(name, fullPath)
    {
        Sprite = sprite;
    }


    /// <summary>
    /// Ексземпялр обекта
    /// </summary>
    /// <param name="name"> Имя обекта </param>
    /// <param name="fullPath"> Путь к файлу </param>
    /// <param name="texture"> Текстура </param>
    public SpriteAsset(string name, string fullPath, Texture texture) : this(name, fullPath)
    {
        Sprite = new Sprite(texture);
    }
}
