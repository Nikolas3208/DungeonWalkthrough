using SFML.Graphics;
using SFML.System;
using Core;
using Core.Content;
using Core.Physics;
using Core.Utils.TmxLoader;
using Core.Graphics.TileMap;
using Core.Physics.Colliders;

namespace DungeonWalkthrough;

public class Game : IGame
{
    /// <summary>
    /// Менеджер асетов
    /// </summary>
    public static AssetManager? AssetManager;

    /// <summary>
    /// Родительское приложение
    /// </summary>
    public Application? PerentApp { get; set; }

    AssetManager? IGame.AssetManager => AssetManager;

    World? IGame.World => World;

    public static World? World;

    public Player Player { get; set; }

    /// <summary>
    /// Конструктор класса
    /// </summary>
    public Game()
    {
        AssetManager = new AssetManager("..\\..\\Content");
        AssetManager.LoadAssets();

        World = new World();
    }
    
    TileMapRender tileMapRender;

    /// <summary>
    /// Старт игры
    /// </summary>
    public void Start()
    {
        var map = TmxLoader.Load("..\\..\\Content\\Maps\\TestLevel\\testLevel.tmx");
        tileMapRender = new TileMapRender(map, this);
        tileMapRender.CreateRenderMap();

        var rb = World!.CreateRigidBody(new Collider(ColliderType.Rectangle, new ColliderShape(new AABB(new Vector2f(45, 45)))), BodyType.Daynamic);
        rb.IsGravity = false;

        Player = new Player(rb);

        rb.Position = new Vector2f(1700, 350);
    }

    /// <summary>
    /// Обновление игры
    /// </summary>
    /// <param name="deltaTime"> Время кадра </param>
    public void Update(Time deltaTime)
    {
        World!.Update(deltaTime);
        Player.Update(deltaTime);
    }

    /// <summary>
    /// Рисование игры
    /// </summary>
    /// <param name="target"></param>
    /// <param name="state"></param>
    public void Draw(RenderTarget target, RenderStates states)
    {
        target.Clear(Color.White);

        tileMapRender.Draw(target, states);
        //World!.Draw(target, states);
        Player.Draw(target, states);
    }

    /// <summary>
    /// Изменение разрешения игры
    /// </summary>
    /// <param name="width"> Ширина </param>
    /// <param name="height"> Высота </param>
    public void Resize(uint width, uint height)
    {

    }

    /// <summary>
    /// Закрытие приложения
    /// </summary>
    public void Close()
    {

    }
}
