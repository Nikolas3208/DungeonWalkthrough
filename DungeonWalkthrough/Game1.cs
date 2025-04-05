using SFML.Graphics;
using SFML.System;
using Core;
using Core.Content;
using Core.Utils.TmxLoader;
using Core.Graphics;
using Core.Window;
using Core.Physics;
using Core.Physics.Collision.Colliders;

namespace DungeonWalkthrough;

public class Game1 : Game
{
    private Player Player { get; set; }
    private MyTileMapRender Level {  get; set; }

    /// <summary>
    /// Конструктор класса
    /// </summary>
    public Game1(GameWindow gameWindow) : base(gameWindow)
    {
        assetManager = new AssetManager("..\\..\\Content");
        assetManager.LoadAssets();
    }


    /// <summary>
    /// Старт игры
    /// </summary>
    public override void Start()
    {
        Level = new MyTileMapRender(TmxLoader.Load("..\\..\\Content\\Maps\\TestLevel2\\testLevel2.tmx"), physicsWorld);
        Level.CreateRenderMap(assetManager!);

        var playerBody = physicsWorld.CreateBody(Polygon.BoxPolygon(64, 64), Material.Default, false);
        Player = new Player(playerBody, assetManager, camera);

        Player.Position = new Vector2f(1400, 400);
    }

    /// <summary>
    /// Обновление игры
    /// </summary>
    /// <param name="deltaTime"> Время кадра </param>
    public override void Update(float deltaTime)
    {
        camera = Player.Update(deltaTime);

        base.Update(deltaTime);
    }


    /// <summary>
    /// Рисование игры
    /// </summary>
    public override void Draw(WindowDrawEvent e)
    {
        Level.Draw(e.Target, e.States);
        Player.Draw(e.Target, e.States);
    }
}
