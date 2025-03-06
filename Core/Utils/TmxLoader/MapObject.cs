using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.TmxLoader
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
