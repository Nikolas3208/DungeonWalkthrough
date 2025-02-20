using Client.Graphics;

namespace Client;

public class Application
{
    private Window _window;

    public Application(WindowSettings settings)
    {
        _window = new Window(settings);
    }
}