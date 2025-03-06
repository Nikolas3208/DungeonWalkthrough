using Core.Window;

namespace Core;

public class ServerApplication : Application
{
    public ServerApplication(IGame game) : base(game)
    {
        _window = new GameWindow(this, new WindowSettings());
    }
}
