using SFML.Graphics;

namespace Core.Graphics;

public class SpriteSheet
{
    private bool _abIsCount = false;

    /// <summary>
    /// Спрайт
    /// </summary>
    public Sprite Sprite { get; }

    /// <summary>
    /// Текстура спрайтлиста
    /// </summary>
    public Texture Texture { get => Sprite.Texture; }

    /// <summary>
    /// Размер одного спрайта по ширине
    /// </summary>
    public int SubWidth { get; protected set; }
    /// <summary>
    /// Размер одного спрайта по высоте
    /// </summary>
    public int SubHeight { get; protected set; }

    /// <summary>
    /// Количиство спрайтов по шырине
    /// </summary>
    public int SubCountWidth { get; protected set; }
    /// <summary>
    /// Количесто спрайтов по высоте
    /// </summary>
    public int SubCountHeight { get; protected set; }

    /// <summary>
    /// Расстояние между спрайтами
    /// </summary>
    public int BorderSize { get; set; }

    /// <summary>
    /// Аb количество елементов по ширине и высоте?
    /// </summary>
    public bool AbIsCount { get => _abIsCount; set { _abIsCount = value; UpdateAb(value); } }

    /// <summary>
    /// Сглажывание изображения
    /// </summary>
    public bool IsSmooth
    {
        get
        {
            if (Sprite != null && Sprite.Texture != null)
                return Sprite.Texture.Smooth;

            return false;
        }
        set
        {
            if (Sprite != null && Sprite.Texture != null)
                Sprite.Texture.Smooth = value;
        }
    }

    /// <summary>
    /// Создание спрайтлиста
    /// </summary>
    /// <param name="sprite"> Спрайт </param>
    /// <param name="isSmooth"> Сглаживание </param>
    public SpriteSheet(Sprite sprite, bool isSmooth = false)
    {
        Sprite = sprite;
        IsSmooth = isSmooth;
    }

    /// <summary>
    /// Созданиие спрайтлиста
    /// </summary>
    /// <param name="texture"> Текстура </param>
    /// <param name="isSmooth"> Сглаживание </param>
    public SpriteSheet(Texture texture, bool isSmooth = false)
    {
        Sprite = new Sprite(texture);
        IsSmooth = isSmooth;
    }

    public SpriteSheet(int a, int b, bool abIsCount, int borderSize, Texture texture, bool isSmooth = false) : this(texture, isSmooth)
    {
        if (abIsCount)
        {
            SubCountWidth = a;
            SubCountHeight = b;
        }
        else
        {
            SubWidth = a;
            SubHeight = b;
        }

        if (borderSize > 0)
            BorderSize = borderSize + 1;

        AbIsCount = abIsCount;
    }

    /// <summary>
    /// Получить размер и позиию спрайта по номеру
    /// </summary>
    /// <param name="id"> Номер спрайта </param>
    /// <returns> Возвращает размер и позицию выбраного спрайта </returns>
    public IntRect GetTextureRect(int id)
    {
        int y = (id / SubCountWidth);
        int x = id - (y * SubCountWidth);

        y *= SubHeight + (id / SubCountHeight) * BorderSize;
        x *= SubWidth + (id / SubCountWidth) * BorderSize;

        return new IntRect(x, y, SubWidth, SubHeight);
    }
    /// <summary>
    /// Обновление размера и количиства спрайтов
    /// </summary>
    /// <param name="abisCount"></param>
    /// <exception cref="Exception"></exception>
    private void UpdateAb(bool abisCount)
    {
        if (Texture == null)
            throw new Exception("Texture is null");

        if (!abisCount)
        {
            SubWidth = (int)(Texture.Size.X / SubCountWidth);
            SubHeight = (int)(Texture.Size.Y / SubCountHeight);
        }
        else
        {
            SubCountWidth = (int)(Texture.Size.X / SubWidth);
            SubCountHeight = (int)(Texture.Size.Y / SubHeight);
        }
    }

}
