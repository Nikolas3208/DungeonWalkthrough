using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils.TmxLoader
{
    public class TileSetImage
    {
        public string FilePath {  get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public TileSetImage(string filePath, int width, int height)
        {
            FilePath = filePath;
            Width = width;
            Height = height;

            Name = Path.GetFileNameWithoutExtension(filePath);
        }
    }
}
