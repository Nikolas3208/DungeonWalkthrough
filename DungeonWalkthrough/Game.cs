using SFML.Graphics;
using SFML.System;
using Core;
using Common.Content;

namespace DungeonWalkthrough;

public class Game : IGame
{
    public static AssetManager? AssetManager;

    public Application? PerentApp { get; set; }

    public Game()
    {
        AssetManager = new AssetManager("Assets");
        AssetManager.Load();
    }

    public void Start()
    {

    }

    public void Update(Time deltaTime)
    {

    }

    public void Draw(RenderTarget target, RenderStates state)
    {

    }

    public void Resize(uint width, uint height)
    {

    }

    public void Close()
    {
        
    }
}
