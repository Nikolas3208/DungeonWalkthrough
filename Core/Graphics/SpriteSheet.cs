using SFML.Graphics;

namespace Core.Graphics;

public class SpriteSheet
{
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
    public int SubWidth { get; }
    /// <summary>
    /// Размер одного спрайта по высоте
    /// </summary>
    public int SubHeight { get; }

    /// <summary>
    /// Количиство спрайтов по шырине
    /// </summary>
    public int SubCountWidth { get; }
    /// <summary>
    /// Количесто спрайтов по высоте
    /// </summary>
    public int SubCountHeight { get; }

    /// <summary>
    /// Расстояние между спрайтами
    /// </summary>
    public int BorderSize { get; set; }

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
}
