using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Core.Window;

public class GameWindow
{
    public delegate void WindowUpdate(float deltaTime);
    public event WindowUpdate Update;

    public delegate void WindowDraw(WindowDrawEvent e);
    public event WindowDraw Draw;

    public delegate void WindowResize(WindowResizeEvent e);
    public event WindowResize Resize;

    public delegate void WindowClose();
    public event WindowClose Close;

    /// <summary>
    /// Окно
    /// </summary>
    private RenderWindow _window;

    /// <summary>
    /// Настройки окна
    /// </summary>
    private WindowSettings _settings;

    /// <summary>
    /// Часы/Таймер
    /// </summary>
    private Clock _clock;

    /// <summary>
    /// Екземпляр окна
    /// </summary>
    /// <param name="app"> Родительское приложение </param>
    /// <param name="settings"> Настройки окна </param>
    public GameWindow(WindowSettings settings)
    {
        _settings = settings;

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

            if (Update != null)
                Update(_clock.Restart().AsSeconds());

            _window.Clear();

            if (Draw != null)
                Draw(new WindowDrawEvent(_window, RenderStates.Default, _clock.Restart().AsSeconds()));

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
    /// Получить размер окна
    /// </summary>
    /// <returns> Возвращает Vector2u </returns>
    public Vector2u GetSize()
    {
        return _window.Size;
    }

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
        _window.SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));

        if(Resize != null)
            Resize(new WindowResizeEvent(e.Width, e.Height));
    }

    /// <summary>
    /// Евент закрытия окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Closed(object? sender, EventArgs e)
    {
        if (Close != null) 
            Close();

        _window.Close();
    }
}