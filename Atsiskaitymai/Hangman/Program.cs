using System;
using System.Text;

namespace Hangman
{

    internal class Program
    {
        public static int wrongCount = 0;
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            bool menuOn = true;
            while (menuOn)
            {
                Console.WriteLine("--HANGMAN--\n\nPASIRINKITE KATEGORIJA\n");
                Console.WriteLine("[1] VARDAI\n[2] LIETUVOS MIESTAI\n[3] VALSTYBES\n[4] KITA\n[5] ISEITI");
                var input = Console.ReadLine();

                switch (MenuValidacija(input))
                {
                    case 1:
                        Vardai();
                        break;
                    case 2:
                        //Miestai();
                        break;
                    case 3:
                        //Valstybes();
                        break;
                    case 4:
                        //Givunai();
                        break;
                    case 5:
                        menuOn = false;
                        break;



                }
            }

        }

        private static void Vardai()
        {
            List<string> vardai = new List<string> { "TOMAS", "GINTARAS", "LAURYNAS", "EDVINAS", "ROBERTAS", "PAULIUS", "ROMUALDAS", "SIMONAS", "DOMINYKAS", "VYTAUTAS" };
            var varduZodynas = new Dictionary<int, string>()
            {
                {1, "TOMAS"},
                {2, "GINTARAS"},
                {3, "LAURYNAS"},
                {4,"EDVINAS"},
                {5, "ROBERTAS"},
                {6, "PAULIUS"},
                {7, "ROMUALDAS"},
                {8, "SIMONAS"},
                {9, "DOMINYKAS"},
                {10, "VYTAUTAS"}
            };
            Game(vardai);
        }



        public static int MenuValidacija(string input)
        {

            bool isNumber = int.TryParse(input, out int result);
            if (isNumber == false)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Negalima ivestis");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return result;

        }

        public static string ZaidimoValidaacija(string input)
        {

            bool isNumber = double.TryParse(input, out _);
            if (isNumber == true || isNumber == null)
            {
                Console.WriteLine("Negalima ivestis");
                return "-1";
            }
            return input;

        }
        private static void Game(List<string> list)
        {

            bool gameOn = true;
            while (gameOn)
            {

                if (wrongCount == 6) gameOn = false;
                Random rand = new Random();
                int randIndex = rand.Next(list.Count);
                string word = list[randIndex];
                //------------------------------------//
                var sbSpejimas = new StringBuilder();
                foreach (var item in word) { sbSpejimas.Append("_"); }




                Guess(sbSpejimas, word);
            }
        }

        public static void Guess(StringBuilder sbSpejimas, string word)

        {
            bool gameOn = true;
            var indexList = new List<int>();
            while (gameOn)
            {
                if (wrongCount == 6) gameOn = false;
                Console.WriteLine(sbSpejimas.ToString());
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
}
/*
 Instructions
- Naudotojas pasirenka iš temų: VARDAI, LIETUVOS MIESTAI, VALSTYBES, KITA. 
  (ne mažiau kaip 10 žodžių kiekvienoje grupėje)
- Žodis iš pasirinktos grupės parenkamas atsitiktine tvarka.
- Užtikrinti kad nebūtu duodamas tas pat žodis daugiau kaip 1 kartą per žaidimą
- Užtikrinti, kad programą nenulūžtu jei vartotojas įveda ne tai ko prašoma
- Ėjimas skaitomas tik jei spėjama dar nespėta raidė
- Jei spėjamas visas žodis ir neatspėjama - iškarto pralaimima
- Parodoma atspėtos raidės vieta žodyje
- Parodomos spėtos, bet neatspėtos raidės

Apribojimai:
- Žodžius saugoti masyvuose  arba žodyne.
- Kodą skaidyti į metodus.
- negalima naudoti OOP ir LINQ
 */
// "","","","","","","","","",""