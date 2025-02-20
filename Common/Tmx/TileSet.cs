using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tmx
{
    public class TileSet
    {
        public int FirstId { get; set; }
        public int LastId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TileWidth {  get; set; }
        public int TileHeight { get; set; }

        public TileSetImage Image { get; set; }

        public SpriteSheet? SpriteSheet { get; set; }

        public TileSet(int firstId, string name, int tileWidth, int tileHeight, TileSetImage image)
        {
            FirstId = firstId;
            Name = name;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Image = image;

            LastId = FirstId + ((Image.Width / TileWidth) * (Image.Height / TileHeight)) - 1;

            LoadSpriteSheet(image);
        }
        
        private void LoadSpriteSheet(TileSetImage image)
        {
            
        }

        public bool ContainsTile(int tileId)
        {
            return (tileId >= FirstId && tileId <= LastId);
        }
    }
}
