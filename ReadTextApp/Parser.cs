using System;
using System.Collections.Generic;
using System.Drawing;

namespace ReadTextApp
{
    public class Parser
    {
        public Bitmap Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool[,] DataP2 { get; set; }

        public List<Obje> Objeler = new List<Obje>();

        public Parser(string path)
        {
            Image = new Bitmap(path);
            Width = Image.Width;
            Height = Image.Height;

            DataP2 = new bool[Width + 2, Height + 2];

            for (var x = 0; x < Width; x++)
                for (var y = 0; y < Height; y++)
                {
                    var clr = Image.GetPixel(x, y);

                    var lGry = Convert.ToByte((clr.R + clr.G + clr.B) / 3);
                    var lBlack = Convert.ToByte(lGry / 128 * 255);

                    DataP2[x + 1, y + 1] = lBlack == 0;
                    Image.SetPixel(x, y, Color.FromArgb(lBlack, lBlack, lBlack));
                }

            Image.Save(path + ".black.bmp");
        }

        public void FindAllCaracter()
        {
            for (int index = 0; index < 30; index++)
            {
                FindNextObjectAddObjectList(Program.BasePath + $"image-char{index}.bmp");
            }
        }
        public void FindNextObjectAddObjectList(string fileName)
        {
            var lObject = FindNextObject(fileName);
            if (lObject != null)
                Objeler.Add(lObject);
        }

        public Obje FindNextObject(string fileName)
        {
            var lPoint = GetFirstCoordinate();
            if (lPoint.X == -1 || lPoint.Y == -1)
                return null;

            var lObject = new Obje(lPoint, DataP2.GetLength(0), DataP2.GetLength(1));

            GetTopCoordinate(lPoint.X, lPoint.Y);

            lObject.DoAnalysis();

            //Tools.SaveImageFromBoolData(lObject.Data, fileName);


            return lObject;
            

            void GetTopCoordinate(int x, int y)
            {
                lObject.CheckPoint(x, y);
                lObject.Data[x, y] = true;

                DataP2[x, y] = false;

                if (DataP2[x - 1, y - 1]) GetTopCoordinate(x - 1, y - 1);
                if (DataP2[x - 0, y - 1]) GetTopCoordinate(x - 0, y - 1);
                if (DataP2[x + 1, y - 1]) GetTopCoordinate(x + 1, y - 1);

                if (DataP2[x - 1, y - 0]) GetTopCoordinate(x - 1, y - 0);
                if (DataP2[x + 1, y - 0]) GetTopCoordinate(x + 1, y - 0);

                if (DataP2[x - 1, y + 1]) GetTopCoordinate(x - 1, y + 1);
                if (DataP2[x - 0, y + 1]) GetTopCoordinate(x - 0, y + 1);
                if (DataP2[x + 1, y + 1]) GetTopCoordinate(x + 1, y + 1);
            }
        }

        private Point GetFirstCoordinate()
        {
            var point = new Point { X = -1, Y = -1 };

            for (var y = 0; y < DataP2.GetLength(1); y++)
                for (var x = 0; x < DataP2.GetLength(0); x++)
                {
                    if (!DataP2[x, y])
                        continue;
                    point.X = x;
                    point.Y = y;
                    return point;
                }
            return point;
        }

    }
}
