using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ReadTextApp
{
    public static class Tools
    {
        public static void SaveImageFromBoolData(bool[,] data, string fileName)
        {
            var w = data.GetLength(0);
            var h = data.GetLength(1);
            using (var lBitmap = new Bitmap(w, h, PixelFormat.Format24bppRgb))
            {
                for (var x = 0; x < w; x++)
                for (var y = 0; y < h; y++)
                {
                    byte lBlack = Convert.ToByte(data[x, y] ? 0 : 255);
                    lBitmap.SetPixel(x, y, Color.FromArgb(lBlack, lBlack, lBlack));
                }
                lBitmap.Save(fileName);
            }
        }
    }
}
