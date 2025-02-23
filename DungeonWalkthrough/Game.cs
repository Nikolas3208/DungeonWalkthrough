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

    /// <summary>
    /// Родительское приложение
    /// </summary>
    public Application? PerentApp { get; set; }

    /// <summary>
    /// Конструктор класса
    /// </summary>
    public Game()
    {
        AssetManager = new AssetManager("Assets");
        AssetManager.LoadAssets();
    }


    /// <summary>
    /// Старт игры
    /// </summary>
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

    /// <summary>
    /// Рисование игры
    /// </summary>
    /// <param name="target"></param>
    /// <param name="state"></param>
    public void Draw(RenderTarget target, RenderStates state)
    {

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
