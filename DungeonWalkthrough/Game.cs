using SFML.Graphics;
using SFML.System;
using Core;
using Core.Content;

namespace DungeonWalkthrough;

public class Game : IGame
{
    /// <summary>
    /// Менеджер асетов
    /// </summary>
    public static AssetManager? AssetManager;

    public Application? PerentApp { get; set; }

    public Game()
    {
        AssetManager = new AssetManager("Assets");
        AssetManager.LoadAssets();
    }

    public void Start()
    {

    }

    /// <summary>
    /// Обновление игры
    /// </summary>
    /// <param name="deltaTime"> Время кадра </param>
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
