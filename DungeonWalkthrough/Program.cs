using Core;
using Core.Window;
using SFML.Window;

namespace DungeonWalkthrough;

public class Program
{
    public static void Main()
    {
        var game = new Game();

        var settings = new WindowSettings(VideoMode.DesktopMode, "Dungeon Walkthrough");

        var app = new Application(settings, game);
        app.Run();
    }
}