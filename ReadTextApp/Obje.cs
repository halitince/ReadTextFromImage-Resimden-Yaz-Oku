using System;
using System.Drawing;

namespace ReadTextApp
{
    public class Obje
    {
        public Point Start;
        public Point Stop;
        public bool[,] Data;
        public bool[,] ObjData;
        public int Width = 0;
        public int Height = 0;

        private Bosluk BosUst = new Bosluk();
        private Bosluk BosSag = new Bosluk();
        private Bosluk BosAlt = new Bosluk();
        private Bosluk BosSol = new Bosluk();
        public char Harf = '_';

        public Obje(Point startPoint, int width, int height)
        {
            Start = new Point(startPoint.X, startPoint.Y);
            Stop = new Point(startPoint.X, startPoint.Y);
            Data = new bool[width, height];
        }

        public void CheckPoint(int x, int y)
        {
            if (x < Start.X) Start.X = x;
            if (y < Start.Y) Start.Y = y;
            if (Stop.X < x) Stop.X = x;
            if (Stop.Y < y) Stop.Y = y;
        }

        public void DoAnalysis()
        {
            Width = Stop.X - Start.X + 1;
            Height = Stop.Y - Start.Y + 1;
            ObjData = new bool[Width, Height];
            for (var x = 0; x < Width; x++)
                for (var y = 0; y < Height; y++)
                    ObjData[x, y] = Data[x + Start.X, y + Start.Y];

            Bosluklar();
            Harf = Harfler.GetChar(BosUst, BosSag, BosAlt, BosSol);

            Tools.SaveImageFromBoolData(ObjData, Program.BasePath + $@"\chars\harf.{Harf}.{Start.X}.{Start.Y}.png");

        }

        private void Bosluklar()
        {
            var lDikeyAralik = (Height - 1M) / 4;
            var lYatayAralik = (Width - 1M) / 4;

            BosSol.a1 = GetSpaceX(Convert.ToInt32(lDikeyAralik * 0));
            BosSol.a2 = GetSpaceX(Convert.ToInt32(lDikeyAralik * 1));
            BosSol.a3 = GetSpaceX(Convert.ToInt32(lDikeyAralik * 2));
            BosSol.a4 = GetSpaceX(Convert.ToInt32(lDikeyAralik * 3));
            BosSol.a5 = GetSpaceX(Convert.ToInt32(lDikeyAralik * 4));

            BosSag.a1 = GetSpaceXx(Convert.ToInt32(lDikeyAralik * 0));
            BosSag.a2 = GetSpaceXx(Convert.ToInt32(lDikeyAralik * 1));
            BosSag.a3 = GetSpaceXx(Convert.ToInt32(lDikeyAralik * 2));
            BosSag.a4 = GetSpaceXx(Convert.ToInt32(lDikeyAralik * 3));
            BosSag.a5 = GetSpaceXx(Convert.ToInt32(lDikeyAralik * 4));

            BosUst.a1 = GetSpaceY(Convert.ToInt32(lYatayAralik * 0));
            BosUst.a2 = GetSpaceY(Convert.ToInt32(lYatayAralik * 1));
            BosUst.a3 = GetSpaceY(Convert.ToInt32(lYatayAralik * 2));
            BosUst.a4 = GetSpaceY(Convert.ToInt32(lYatayAralik * 3));
            BosUst.a5 = GetSpaceY(Convert.ToInt32(lYatayAralik * 4));

            BosAlt.a1 = GetSpaceYy(Convert.ToInt32(lYatayAralik * 0));
            BosAlt.a2 = GetSpaceYy(Convert.ToInt32(lYatayAralik * 1));
            BosAlt.a3 = GetSpaceYy(Convert.ToInt32(lYatayAralik * 2));
            BosAlt.a4 = GetSpaceYy(Convert.ToInt32(lYatayAralik * 3));
            BosAlt.a5 = GetSpaceYy(Convert.ToInt32(lYatayAralik * 4));

            int GetSpaceX(int y)
            {
                for (var x = 0; x < Width; x++)
                    if (ObjData[x, y])
                        return x;
                return 0;
            }
            int GetSpaceXx(int y)
            {
                for (var x = Width - 1; x >= 0; x--)
                    if (ObjData[x, y])
                        return Width - x;
                return 0;
            }
            int GetSpaceY(int x)
            {
                for (var y = 0; y < Height; y++)
                    if (ObjData[x, y])
                        return y;
                return 0;
            }
            int GetSpaceYy(int x)
            {
                for (var y = Height - 1; y >= 0; y--)
                    if (ObjData[x, y])
                        return Height - y;
                return 0;
            }

        }
    }


    public class Bosluk
    {
        public int a1 { get; set; }
        public int a2 { get; set; }
        public int a3 { get; set; }
        public int a4 { get; set; }
        public int a5 { get; set; }
    }
}
