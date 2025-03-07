using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core.Window;

public class GameWindow
{
    /// <summary>
    /// Окно
    /// </summary>
    private RenderWindow _window;

    /// <summary>
    /// Настройки окна
    /// </summary>
    private WindowSettings _settings;

    /// <summary>
    /// Приложение
    /// </summary>
    private Application _perentApp;

    /// <summary>
    /// Часы/Таймер
    /// </summary>
    private Clock _clock;

    /// <summary>
    /// Екземпляр окна
    /// </summary>
    /// <param name="app"> Родительское приложение </param>
    /// <param name="settings"> Настройки окна </param>
    public GameWindow(Application app, WindowSettings settings)
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

    /// <summary>
    /// Запуск окна
    /// </summary>
    public void Run()
    {
        while (_window.IsOpen)
        {
            _window.DispatchEvents();

            _perentApp.Update(_clock.Restart());

            _window.Clear();

            _perentApp.Draw(_window, RenderStates.Default);

            _window.Display();
        }
    }

    /// <summary>
    /// Установить настройки окна
    /// </summary>
    /// <param name="settings"> Настройки окна </param>
    public void SetSettings(WindowSettings settings) { _settings = settings; UpdateSettings(settings); }

    /// <summary>
    /// Полусить настройки окна
    /// </summary>
    /// <returns> Настройки окна </returns>
    public WindowSettings GetSettings() => _settings;

    /// <summary>
    /// Установить вид/камеру окна
    /// </summary>
    /// <param name="view"> Вид/Камера </param>
    public void SetView(View view) => _window.SetView(view);

    /// <summary>
    /// Получить вид/камеру окна
    /// </summary>
    /// <returns> Вид/Камера </returns>
    public View GetView() => _window.GetView();

    /// <summary>
    /// Обновить настройки окна
    /// </summary>
    /// <param name="settings"> Настройки окна </param>
    private void UpdateSettings(WindowSettings settings)
    {
        _window.SetTitle(settings.Title);
        _window.SetVerticalSyncEnabled(settings.VSync);
        _window.SetFramerateLimit(settings.FramerateLimit);
    }

    /// <summary>
    /// Евент изменения размера окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Resized(object? sender, SizeEventArgs e)
    {
        _perentApp.Resize(e.Width, e.Height);
        _window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
    }

    /// <summary>
    /// Евент закрытия окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Closed(object? sender, EventArgs e)
    {
        _perentApp.Close();
        _window.Close();
    }

    public Vector2u GetSize()
    {
        return _window.Size;
    }
}