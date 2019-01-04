using System;

namespace ReadTextApp
{
    class Program
    {
        public static string BasePath => AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\files\";

        static void Main(string[] args)
        {
            var lParser = new Parser(BasePath + "TARANAN.png");

            lParser.FindAllCaracter();

            //var Son = Console.ReadLine();
        }
        
    }
}
