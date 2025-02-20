using SFML.Graphics;
using SFML.Window;

namespace Core.Graphics;

public struct WindowSettings
{
    public VideoMode VideoMode { get; set; }
    public string Title { get; set; }
    public Styles Styles { get; set; }

    public uint FramerateLimit {get; set; } = 60;
    public bool VSync { get; set; } = false;

    public ContextSettings ContextSettings{ get; set; }

    public WindowSettings(VideoMode videoMode, string title, Styles styles = Styles.Default)
    {
        VideoMode = videoMode;
        Title = title;
        Styles = styles;
    }

    public WindowSettings(VideoMode videoMode, string title, ContextSettings contextSettings, Styles styles = Styles.Default) : this(videoMode, title, styles)
    {
        ContextSettings = contextSettings;
    }
}