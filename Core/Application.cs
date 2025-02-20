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
        _game = game;
        _window = new Window(this, settings);
    }

    public void Run()
    {
        _game.Start();
        _window.Run();
    }

    public void Update(Time deltaTime)
    {
        _game.Update(deltaTime);
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        _game.Draw(target, states);
    }

    public void Resize(uint width, uint height)
    {

    }
    public void Close()
    {
        
    }
}