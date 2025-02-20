using SFML.Graphics;
using SFML.Window;

namespace Core.Graphics;

public class Window
{
    private RenderWindow _window;
    private WindowSettings _settings;
    private Application _perentApp;

    public Window(Application app, WindowSettings settings)
    {
        _settings = settings;
        _perentApp = app;

        _window = new RenderWindow(settings.VideoMode, settings.Title, settings.Styles);
        _window.Closed += Window_Closed;
        _window.Resized += Window_Resized;
    }

    public void Run()
    {
        while(_window.IsOpen)
        {
            _window.DispatchEvents();

            _window.Clear();

            _window.Display();
        }
    }

    private void Window_Resized(object? sender, SizeEventArgs e)
    {
        _perentApp.Resize(e.Width, e.Height);
        _window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
    }

    private void Window_Closed(object? sender, EventArgs e)
    {
        _perentApp.Close();
        _window.Close();
    }
}