using SFML.Graphics;
using SFML.System;

namespace Core;

public interface IGame
{
    void Start();
    void Update(Time deltaTime);
    void Draw(RenderTarget target, RenderStates states);
}