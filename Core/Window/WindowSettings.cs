using SFML.Graphics;
using SFML.Window;

namespace Core.Window;

public struct WindowSettings
{
    /// <summary>
    /// Размер окна
    /// </summary>
    public VideoMode VideoMode { get; set; }

    /// <summary>
    /// Имя окна
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Стили окна
    /// </summary>
    public Styles Styles { get; set; }

    /// <summary>
    /// Лимит кадров в секунду
    /// </summary>
    public uint FramerateLimit { get; set; } = 60;

    /// <summary>
    /// Вертикальная синхронизаия
    /// </summary>
    public bool VSync { get; set; } = false;

    public ContextSettings ContextSettings{ get; set; }

    /// <summary>
    /// Екземпляр настроек окна
    /// </summary>
    /// <param name="videoMode"> Размер окна </param>
    /// <param name="title"> Имя окна </param>
    /// <param name="styles"> Стили окна (По умолчанию Styles.Default) </param>
    public WindowSettings(VideoMode videoMode, string title, Styles styles = Styles.Default)
    {
        VideoMode = videoMode;
        Title = title;
        Styles = styles;
    }

    /// <summary>
    /// Екземпляр настроек окна
    /// </summary>
    /// <param name="videoMode"> Зармер окна </param>
    /// <param name="title"> Имя окна </param>
    /// <param name="contextSettings"></param>
    /// <param name="styles"> Стили окна (По умолчанию Styles.Default) </param>
    public WindowSettings(VideoMode videoMode, string title, ContextSettings contextSettings, Styles styles = Styles.Default) : this(videoMode, title, styles)
    {
        ContextSettings = contextSettings;
    }
}