using System.Xml.Linq;

namespace Core.Utils.TmxLoader
{
    public class TileSetLoader
    {
        public static List<TileSet> Load(XElement map, string filePath)
        {
            var retTileSets = new List<TileSet>();

            var tileSets = map.Elements("tileset");

            foreach (var tileSet in tileSets)
            {
                int firstgid = int.Parse(tileSet.Attribute("firstgid")!.Value);

                if (tileSet.Element("image") != null)
                {
                    var tileset = LoadTSX(tileSet.Element("image")!.Attribute("source")!.Value, firstgid, filePath);

                    retTileSets.Add(tileset);
                }
                else
                {
                    var source = tileSet.Attribute("source")!.Value;

                    var tileset = LoadTSX(source, firstgid, filePath);

                    retTileSets.Add(tileset);
                }
            }

            return retTileSets;
        }

        private static TileSet LoadTSX(string source, int firstId, string filePath)
        {
            XDocument xDocument = XDocument.Load(filePath + "\\" + source);

            var tileSet = xDocument.Element("tileset");

            var name = tileSet!.Attribute("name")!.Value;
            int tileWidth = int.Parse(tileSet.Attribute("tilewidth")!.Value);
            int tileHeight = int.Parse(tileSet.Attribute("tileheight")!.Value);

            var image = tileSet.Element("image");

            var sourceImage = image!.Attribute("source")!.Value;
            int width = int.Parse(image.Attribute("width")!.Value);
            int height = int.Parse(image.Attribute("height")!.Value);

            if (tileSet.Element("tile") == null)
                return new TileSet(firstId, name, tileWidth, tileHeight, new TileSetImage(sourceImage, width, height));
            else
            {
                List<TileFrame> framesAnim = new List<TileFrame>();

                var tile = tileSet.Element("tile");
                var animation = tile!.Element("animation");
                var frames = animation!.Elements("frame");

                foreach( var frame in frames)
                {
                    int tileId = int.Parse(frame.Attribute("tileid")!.Value);
                    float duration = float.Parse(frame.Attribute("duration")!.Value) / 100;

                    framesAnim.Add(new TileFrame(tileId, duration));
                }

                return new TileSet(firstId, name, tileWidth, tileHeight, new TileSetImage(sourceImage, width, height), framesAnim);
            }
        }
    }
}
