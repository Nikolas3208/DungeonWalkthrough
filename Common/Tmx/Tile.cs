using Common.Animation;
using SFML.Graphics;

namespace GameEngine.Core.Utils.TMXLoaderCommon.Tmx
{
    public class Tile : Transformable, Drawable
    {
        private bool _isAnimated = false;
        public int Id { get; set; }

        public bool IsAnimated
        {
            get => _isAnimated;
            set
            {
                _isAnimated = value;
            }
        }

        public Sprite Sprite { get; set; }

        public Tile(int id, Sprite sprite)
        {
            Id = id;
            Sprite = sprite;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
        }
    }
}
