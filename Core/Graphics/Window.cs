using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core.Graphics;

public class Window
{
    private RenderWindow _window;
    private WindowSettings _settings;
    private Application _perentApp;
    private Clock _clock;

    public Window(Application app, WindowSettings settings)
    {
        _settings = settings;
        _perentApp = app;

        _window = new RenderWindow(settings.VideoMode, settings.Title, settings.Styles, settings.ContextSettings);
        
        _window.SetFramerateLimit(settings.FramerateLimit);
        _window.SetVerticalSyncEnabled(settings.VSync);

        _window.Closed += Window_Closed;
        _window.Resized += Window_Resized;

        _clock = new Clock();
    }

    public void Run()
    {
        while(_window.IsOpen)
        {
            _window.DispatchEvents();

            _perentApp.Update(_clock.Restart());

            _window.Clear();

            _perentApp.Draw(_window, RenderStates.Default);

            _window.Display();
        }
    }

    public void SetSettings(WindowSettings settings) { _settings = settings; UpdateSettings(settings); }
    public WindowSettings GetSettings() => _settings;

    public void SetView(View view) => _window.SetView(view);
    public View GetView() => _window.GetView();

    private void UpdateSettings(WindowSettings settings)
    {
        _window.SetTitle(settings.Title);
        _window.SetVerticalSyncEnabled(settings.VSync);
        _window.SetFramerateLimit(settings.FramerateLimit);
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