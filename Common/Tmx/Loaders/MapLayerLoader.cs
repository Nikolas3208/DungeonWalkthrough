using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Tmx.Loaders
{
    public class MapLayerLoader
    {
        public static List<MapLayer> Load(XElement map)
        {
            var retLayers = new List<MapLayer>();

            var layers = map.Elements("layer");

            foreach (XElement layer in layers)
            {
                int id = int.Parse(layer.Attribute("id")!.Value);
                var name = layer.Attribute("name")!.Value;
                int whidth = int.Parse(layer.Attribute("width")!.Value);
                int height = int.Parse(layer.Attribute("height")!.Value);
                var data = layer.Element("data")!.Value;

                int[] tileId = data.Split(new[] { ',' }).Select(int.Parse).ToArray();

                retLayers.Add(new MapLayer(id, name, whidth, height, tileId));
            }

            return retLayers;
        }
    }
}
