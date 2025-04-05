using Core;
using Core.Window;
using SFML.Window;

namespace DungeonWalkthrough;

public class Program
{
    public static void Main()
    {
        var settings = new WindowSettings(VideoMode.DesktopMode, "Dungeon Walkthrough");
        settings.VSync = false;
        settings.FramerateLimit = 60;

        var window = new GameWindow(settings);

        var game = new Game1(window);
        game.Run();
    }
}