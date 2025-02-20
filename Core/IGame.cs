using Common.Content;
using SFML.Graphics;
using SFML.System;

namespace Core;

public interface IGame
{
    Application? PerentApp { get; set; }
    void Start();
    void Update(Time deltaTime);
    void Draw(RenderTarget target, RenderStates states);

    void Resize(uint width, uint height);
    void Close();
}