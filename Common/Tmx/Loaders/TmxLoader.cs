using System.Xml.Linq;

namespace Common.Tmx.Loaders
{
    public class TmxLoader
    {
        public static Map Load(string filePath)
        {
            XDocument xDocument = XDocument.Load(filePath);

            var map = xDocument.Element("map");

            var tileSets = TileSetLoader.Load(map!);

            var layers = MapLayerLoader.Load(map!);

            var mapObjects = MapObjectGroupsLoader.Load(map!);

            var Map = new Map(tileSets, layers, mapObjects);
            Map.Width = int.Parse(map.Attribute("width")!.Value);
            Map.Height = int.Parse(map.Attribute("height")!.Value);
            Map.TileWidth = int.Parse(map.Attribute("tilewidth")!.Value);
            Map.TileHeight = int.Parse(map.Attribute("tileheight")!.Value);

            return Map;
        }
    }
}
