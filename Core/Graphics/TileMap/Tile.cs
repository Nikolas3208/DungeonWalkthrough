using Core.Animation;
using SFML.Graphics;

namespace Core.Graphics.TileMap;

public class Tile : Transformable, Drawable
{
    private Sprite? _sprite;
    private Animator? _animator;

    public IntRect TextureRect
    {
        get => _sprite!.TextureRect;
        set => _sprite!.TextureRect = value;
    }

    public Tile(Sprite sprite)
    {
        _sprite = sprite;
    }

    public Tile(Animator animator)
    {
        _animator = animator;
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
        states.Transform *= Transform;

        if (_sprite != null && _animator == null)
            target.Draw(_sprite, states);

        else if (_animator != null)
            _animator.Draw(target, states);
    }

}
