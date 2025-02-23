namespace Core.Animation;

public class Animation
{
    /// <summary>
    /// Масив кадров
    /// </summary>
    private AnimationFrame[]? _frames;

    /// <summary>
    /// Имя анимаии
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Создание пустой анимаии
    /// </summary>
    /// <param name="name"> Имя анимации </param>
    public Animation(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Создание анимации с кадрами
    /// </summary>
    /// <param name="name"> Имя анимаии </param>
    /// <param name="frames"> Кадры анимаии </param>
    public Animation(string name, AnimationFrame[] frames)
    {
        Name = name;
        _frames = frames;
    }

    /// <summary>
    /// Установить кадры анимации с заменой предыдуших
    /// </summary>
    /// <param name="frames"> Кадры анимаии </param>
    public void SetAnimationFrames(params AnimationFrame[] frames)
    {
        _frames = frames;
    }

    /// <summary>
    /// Получить кадры анимаии
    /// </summary>
    /// <returns> Возвращает кадры анимаии </returns>
    public AnimationFrame[]? GetAnimationFrames()
    {
        return _frames;
    }
}
