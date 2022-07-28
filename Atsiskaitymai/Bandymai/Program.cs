using System.Text;

namespace Bandymai
{
    internal class Program
       
    {
        public static bool gameOn = true;
        static void Main(string[] args)
        {
            while (gameOn)
            {
                int wrongCount = 0;
                if (wrongCount == 6) gameOn = false;
                Random rand = new Random();
                int randIndex = rand.Next(list.Count);
                string word = list[randIndex];
                //------------------------------------//
                var sbSpejimas = new StringBuilder();
                foreach (var item in word) { sbSpejimas.Append("_"); }




                Guess(sbSpejimas, word);
            }
            var indexList = new List<int>();
            while (gameOn)
            {
                if (wrongCount > 5)
                {
                    Console.WriteLine("Pralaimejote, bandykite dar karta");
                    gameOn = false;


                }

                Console.WriteLine(sbSpejimas.ToString());
                Console.WriteLine(wrongCount);
                var guess = Console.ReadLine().ToUpper();
                var spetosRaides = new StringBuilder();


                if (word.Contains(guess))
                {
                    foreach (var letter in guess)
                    {
                        spetosRaides.Append(letter);
                        for (int i = 0; i < word.Length; i++)

                        {
                            if (word[i] == letter) indexList.Add(i);

                        }
                    }
                }
                else
                {
                    foreach (var letter in guess)
                    {
                        spetosRaides.Append(letter);
                        spetosRaides.Append(" ");
                        wrongCount++;

                    }
                }


                foreach (var index in indexList)
                {

                    {
                        sbSpejimas[index] = word[index];

                        Console.Clear();
                    }
                }
            }
    }
}