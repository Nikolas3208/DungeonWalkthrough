using SFML.Window;
using Client.Graphics;

namespace Client;

public class Program
{
    private static Application _app;
    public static void Main()
    {
        var settings = new WindowSettings
        {
            VideoMode = VideoMode.DesktopMode
        };

        _app = new Application(settings);
    }
}