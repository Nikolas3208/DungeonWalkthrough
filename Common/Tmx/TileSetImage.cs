using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tmx
{
    public class TileSetImage
    {
        public string FilePath {  get; set; }
        public int Width {  get; set; }
        public int Height { get; set; }

        public TileSetImage(string filePath, int width, int height)
        {
            FilePath = filePath;
            Width = width;
            Height = height;
        }
    }
}
