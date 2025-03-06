using System.Xml.Linq;

namespace Core.Utils.TmxLoader
{
    public class TmxLoader
    {
        public static Map Load(string filePath)
        {
            XDocument xDocument = XDocument.Load(filePath);

            //filePath = filePath.Remove(filePath.IndexOf(".tmx"));

            int index1 = filePath.IndexOf(".tmx");

            for (int i = 0; i < filePath.Length; i++)
            {
                if (filePath[index1 - i] == '\\')
                {
                    filePath = filePath.Remove(index1 - i);
                    break;
                }
            }
                var map = xDocument.Element("map");

            var tileSets = TileSetLoader.Load(map!, filePath);

            var layers = MapLayerLoader.Load(map!);

            var mapObjects = MapObjectGroupsLoader.Load(map!);

            var Map = new Map(tileSets, layers, mapObjects);
            Map.Width = int.Parse(map!.Attribute("width")!.Value);
            Map.Height = int.Parse(map.Attribute("height")!.Value);
            Map.TileWidth = int.Parse(map.Attribute("tilewidth")!.Value);
            Map.TileHeight = int.Parse(map.Attribute("tileheight")!.Value);

            return Map;
        }
    }
}
