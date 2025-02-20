using SFML.Graphics;

namespace Common.Tmx
{
    public class MapObject
    {
        public int Id { get; set; }
        public FloatRect Rect { get; set; }

        public MapObject(int id, FloatRect rect)
        {
            Id = id;
            Rect = rect;
        }
    }
}
