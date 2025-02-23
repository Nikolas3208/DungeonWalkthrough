namespace Core.Animation;

public class AnimationFrame
{
    /// <summary>
    /// Номер кадра в анимации
    /// </summary>
    public int FrameId { get; }

    /// <summary>
    /// Номер спрайта в SpriteSheet
    /// </summary>
    public int SpriteId { get; }

    /// <summary>
    /// Кадр анимации
    /// </summary>
    /// <param name="frameId"> номер кадра </param>
    /// <param name="spriteId"> номер спрайта </param>
    public AnimationFrame(int frameId, int spriteId)
    {
        FrameId = frameId;
        SpriteId = spriteId;
    }
}
