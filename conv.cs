using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace ASCIIconvertor
{
    public class conv
    {
        private readonly char[] table = { '.', ',', ':', '+', '*', '?', '%', 'S', '#', '@' };
        private readonly Bitmap _bitmap;
        public conv(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public char[][] Convert()
        {
            var result = new char[_bitmap.Height][];

            for (int y = 0; y < _bitmap.Height; y++)
            {
                result[y] = new char[_bitmap.Width];
                for (int x = 0; x < _bitmap.Width; x++)
                {
                    int mapIndx = (int)Map(_bitmap.GetPixel(x,y).R, 0, 255, 0, table.Length - 1 );
                    result[y][x] = table[mapIndx];
                }
            }

            return result;
        }
        private float Map(float vToMap, float st1, float sto1, float st2, float sto2)
        {
            return ((vToMap - st1) / (sto1 - st1)) * (sto2 - st2) + st2;
        }
    }
}
