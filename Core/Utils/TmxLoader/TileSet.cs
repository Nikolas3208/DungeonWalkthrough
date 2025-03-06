
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.TmxLoader
{
    public class TileSet
    {
        public int FirstId { get; set; }
        public int LastId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TileWidth {  get; set; }
        public int TileHeight { get; set; }

        public TileSetImage Image { get; set; }

        public List<TileFrame> TileFrames { get; set; }

        public TileSet(int firstId, string name, int tileWidth, int tileHeight, TileSetImage image)
        {
            FirstId = firstId;
            Name = name;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Image = image;

            LastId = FirstId + (Image.Width / TileWidth * (Image.Height / TileHeight)) - 1;
        }

        public TileSet(int firstId, string name, int tileWidth, int tileHeight, TileSetImage image, List<TileFrame> tileFrames) : this(firstId, name, tileWidth, tileHeight, image)
        {
            TileFrames = tileFrames;
        }

        public bool ContainsTile(int tileId)
        {
            return tileId >= FirstId && tileId <= LastId;
        }
    }
}
