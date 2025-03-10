using Core.Physics.Colliders;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.TmxLoader
{
    public enum MapObjectType
    {
        AABB,
        Circle,
        Poligon
    }
    public class MapObject
    {
        public int Id { get; set; }
        public AABB AABB { get; set; }
        public Circle Circle { get; set; }
        public Poligon Poligon { get; set; }

        public MapObjectType MapObjectType { get; set; }

        public MapObject(int id, AABB aabb)
        {
            Id = id;
            AABB = aabb;
            MapObjectType = MapObjectType.AABB;
        }

        public MapObject(int id, Circle circle)
        {
            Id = id;
            Circle = circle;
            MapObjectType = MapObjectType.Circle;
        }

        public MapObject(int id, Poligon poligon)
        {
            Id = id;
            Poligon = poligon;
            MapObjectType = MapObjectType.Poligon;
        }
    }
}
