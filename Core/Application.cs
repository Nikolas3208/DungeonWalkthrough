using Core.Window;
using SFML.Graphics;
using SFML.System;

namespace Core;

public class Application
{
    /// <summary>
    /// Екземпляр игры
    /// </summary>
    private IGame _game;

    /// <summary>
    /// Окно приложения
    /// </summary>
    private GameWindow _window;

    /// <summary>
    /// Приложение хранит окно и саму игру
    /// </summary>
    /// <param name="settings"> Настройки окна </param>
    /// <param name="game"> Обект наследуемый от интерфейса IGame </param>
    public Application(WindowSettings settings, IGame game)
    {
        game.PerentApp = this;
        _game = game;
        _window = new GameWindow(this, settings);
    }

    /// <summary>
    /// Запуск приложеня
    /// </summary>
    public virtual void Run()
    {
        _game.Start();
        _window.Run();
    }

    /// <summary>
    /// Обновление приложения
    /// </summary>
    /// <param name="deltaTime"> Время кадра </param>
    public virtual void Update(Time deltaTime)
    {
        _game.Update(deltaTime);
    }

    /// <summary>
    /// Рисование приложения
    /// </summary>
    /// <param name="target"></param>
    /// <param name="states"></param>
    public virtual void Draw(RenderTarget target, RenderStates states)
    {
        _game.Draw(target, states);
    }

    /// <summary>
    /// Изменения размера окна
    /// </summary>
    /// <param name="width"> Ширина </param>
    /// <param name="height"> Высота </param>
    public virtual void Resize(uint width, uint height)
    {
        _game.Resize(width, height);
    }

    /// <summary>
    /// Закрытие приложения
    /// </summary>
    public virtual void Close()
    {
        _game.Close();
    }
}