using SFML.Graphics;
using SFML.System;

namespace Core;

public interface IGame
{
    /// <summary>
    /// Родительское прилодение
    /// </summary>
    Application? PerentApp { get; set; }

    /// <summary>
    /// Старт игры
    /// </summary>
    void Start();

    /// <summary>
    /// Обновление игры
    /// </summary>
    /// <param name="deltaTime"> Время кадра </param>
    void Update(Time deltaTime);

    /// <summary>
    /// Рисование игры
    /// </summary>
    /// <param name="target"></param>
    /// <param name="states"></param>
    void Draw(RenderTarget target, RenderStates states);

    /// <summary>
    /// Изменение размера окна
    /// </summary>
    /// <param name="width"> Ширина </param>
    /// <param name="height"> Высота </param>
    void Resize(uint width, uint height);

    /// <summary>
    /// Закртие игры
    /// </summary>
    void Close();
}