using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Utils.TmxLoader
{
    public class Map
    {
        public List<TileSet> TileSets;
        public List<MapLayer> MapLayers;
        public List<MapObjectGroup>? MapObjects;

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public int Width { get; set; }  
        public int Height { get; set; }

        public Map(List<TileSet> tileSets, List<MapLayer> mapLayers)
        {
            TileSets = tileSets;
            MapLayers = mapLayers;
        }

        public Map(List<TileSet> tileSets, List<MapLayer> mapLayers, List<MapObjectGroup> mapObjects) : this(tileSets, mapLayers)
        {
            MapObjects = mapObjects;
        }
    }
}
