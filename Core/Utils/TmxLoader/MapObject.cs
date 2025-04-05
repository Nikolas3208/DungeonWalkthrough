using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.TmxLoader
{
    public enum MapObjectType
    {
        Circle,
        Poligon
    }
    public class MapObject
    {
        public int Id { get; set; }

        public Vector2f Position { get; set; }
        public Vector2f Size { get; set; }

        public float Radius { get; set; }

        public List<Vector2f> Points { get; set; }

        public MapObjectType MapObjectType { get; set; }

        public MapObject(int id, Vector2f position, Vector2f size)
        {
            Id = id;
            Position = position;
            Size = size;
            MapObjectType = MapObjectType.Poligon;
        }

        public MapObject(int id, Vector2f position, float radius)
        {
            Id = id;
            Position = position;
            Radius = radius;
            MapObjectType = MapObjectType.Circle;
        }

        public MapObject(int id, Vector2f position, List<Vector2f> points)
        {
            Id = id;
            Position = position;
            Points = points;
            MapObjectType = MapObjectType.Poligon;
        }
    }
}
