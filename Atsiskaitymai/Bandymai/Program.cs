using System;
using System.Text;

namespace Bandymai
{
    internal class Program

    {
        public static List<int> usedRandIndex = new List<int>();
        public static int wrongCount = 0;
        public static bool gameOn = true;
        public static bool menuOn = true;
        public static bool looseMenuOn = true;



        static void Main(string[] args)
        {
            var varduZodynas = new Dictionary<int, string>()
            {
                {1, "TOMAS"},
                {2, "GINTARAS"},
                {3, "LAURYNAS"},
                {4, "EDVINAS"},
                {5, "ROBERTAS"},
                {6, "PAULIUS"},
                {7, "ROMUALDAS"},
                {8, "SIMONAS"},
                {9, "DOMINYKAS"},
                {10, "VYTAUTAS"}
            };

            Random rand = new Random();

            int randIndex = rand.Next(1, (varduZodynas.Count + 1));
            List<int> usedRandIndex = new List<int>();
            bool x = true;
            while (x)
            {
                Console.WriteLine(randIndex.ToString());
                usedRandIndex.Add(randIndex);
                while (usedRandIndex.Contains(randIndex)) { randIndex = rand.Next(1, (varduZodynas.Count + 1)); };
                Console.WriteLine(usedRandIndex.ToString());
                if (usedRandIndex.Count == 10)
                    x = false;  
            }
        }
    }
}
      