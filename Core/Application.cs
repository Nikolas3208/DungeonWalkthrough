using Core.Graphics;
using SFML.Graphics;
using SFML.System;

namespace Core;

public class Application
{
    private IGame _game;
    private Window _window;

    public Application(WindowSettings settings, IGame game)
    {
        game.PerentApp = this;
        _game = game;
        _window = new Window(this, settings);
    }

    public virtual void Run()
    {
        _game.Start();
        _window.Run();
    }

    public virtual void Update(Time deltaTime)
    {
        _game.Update(deltaTime);
    }

    public virtual void Draw(RenderTarget target, RenderStates states)
    {
        _game.Draw(target, states);
    }

    public virtual void Resize(uint width, uint height)
    {
        _game.Resize(width, height);
    }
    public virtual void Close()
    {
        _game.Close();
    }
}