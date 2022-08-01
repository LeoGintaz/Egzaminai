using System;
using System.Text;

namespace Hangman
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
            MainMenu();
        }

        private static void MainMenu()
        {

            while (menuOn)
            {

                Console.Clear();
                #region SPALVA
                Console.ForegroundColor = ConsoleColor.White;
                #endregion
                Console.WriteLine("--HANGMAN--\n\nPASIRINKITE KATEGORIJA\n");
                Console.WriteLine("[1] VARDAI\n[2] LIETUVOS MIESTAI\n[3] VALSTYBES\n[4] KITA\n[5] ISEITI");
                var input = Console.ReadLine();

                switch (input)
                {
                    case  "1":
                        //wrongCount = 0;
                        gameOn = true;
                        Vardai();
                        break;
                    case "2":
                        //Miestai();
                        break;
                    case "3":
                        //Valstybes();
                        break;
                    case "4":
                        //Givunai();
                        break;
                    case "5":
                        menuOn = false;
                        break;
                    default: 
                        Console.WriteLine("Negalima ivestis");
                        Console.ReadKey();
                        break;



                }
            }

        }

        private static void LooseMenu()
        {
            #region SPALVA
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
            Console.WriteLine("\n[1] BANDYTI IS NAUJO\n[2] PASIRINKTI KITA TEMA");
            var input = Console.ReadLine();
            while (looseMenuOn = true)
            {
                switch (MenuValidacija(input))
                {
                    case 1:
                        Vardai();
                        break;
                    case 2:
                        looseMenuOn = false;
                        MainMenu();
                        break;
                }
            }
        }

        private static void Vardai()
        {
            //List<string> vardai = new List<string> { "TOMAS", "GINTARAS", "LAURYNAS", "EDVINAS", "ROBERTAS", "PAULIUS", "ROMUALDAS", "SIMONAS", "DOMINYKAS", "VYTAUTAS" };
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
            Game(varduZodynas);
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
        public static void Game(Dictionary<int, string> list)
        {
            Random rand = new Random();

            int randIndex = rand.Next(1, (list.Count + 1));
            if (usedRandIndex.Count == list.Count)
            {
                Console.WriteLine("Laimejote");
                usedRandIndex.Clear();
                wrongCount = 0;
                MainMenu();
            }
            
            while (usedRandIndex.Contains(randIndex)) { randIndex = rand.Next(1, 11); };
            usedRandIndex.Add(randIndex);

            //------------------------------------//
            var hiddenWord = new StringBuilder();

            string word = list[randIndex];


            //usedRandIndex.Add(randIndex);
            foreach (var item in word) { hiddenWord.Append("-"); }

            Guess(hiddenWord, word, randIndex,rand);


        }

        public static void Guess(StringBuilder hiddenWord, string word, int randIndex, Random rand)

        {

            var spetosRaides = new StringBuilder();

            var indexList = new List<int>();
            

            while (gameOn)
            {
                //usedRandIndex.Add(randIndex);
                //while (usedRandIndex.Contains(randIndex)) { randIndex = rand.Next(1, 11); };
                //usedRandIndex.Add(randIndex);

               

                Console.Clear();
                if (wrongCount > 5)
                {
                    #region SPALVA
                    Console.ForegroundColor = ConsoleColor.Red;
                    #endregion
                    Console.WriteLine("Pralaimejote");
                    wrongCount = 0;
                    gameOn = false;

                }
                if (hiddenWord.ToString() == word)
                {
                    
                    Console.WriteLine("Atspejote");
                    Console.ReadKey();
                    
                    wrongCount = 0;
                    Vardai();
                }
                Drwing();

                Console.WriteLine(hiddenWord.ToString());
                Console.WriteLine(wrongCount);
                Console.WriteLine("Spetos Raides:\n{0}", spetosRaides.ToString());

                var guess = Console.ReadLine().ToUpper();
                foreach (var letter in guess)
                {
                    bool isNumber = double.TryParse(letter.ToString(), out _);
                    if (isNumber == true || isNumber == null)
                    {
                        Console.WriteLine("Negalima ivestis");

                    }
                }

                //foreach (var letter in guess) { spetosRaides.Append(letter); spetosRaides.Append(" "); };

                WrongCountCalculator(guess, word , ref spetosRaides);
                CorrectGuess(guess, word, indexList, hiddenWord);






            }


        }

        public static void CorrectGuess(string guess, string word, List<int> indexList, StringBuilder hiddenWord)
        {

            if (word.Contains(guess))
            {
                foreach (var letter in guess)
                {

                    for (int i = 0; i < word.Length; i++)

                    {
                        if (word[i] == letter) indexList.Add(i);

                    }
                }
            }
            foreach (var index in indexList)
            {


                hiddenWord[index] = word[index];



            }
        }

        public static void WrongCountCalculator(string guess, string word, ref StringBuilder spetosRaides)
        {
            if (word.Contains(guess) == false)
            {


                foreach (var letter in guess)

                {
                    bool isNumber = int.TryParse(letter.ToString(), out _);
                    if (isNumber == true || isNumber == null)
                    {                       

                    }
                    else
                    {
                        if (spetosRaides.ToString().Contains(letter) == false)
                        {
                            spetosRaides.Append(letter);
                            spetosRaides.Append(" ");
                            ++wrongCount;
                        }
                    }
                }
            }
        }

        public static void Drwing()
        {


            //               galva|kunas|rank1|ranka2|koja1|koja2
            string[] body = { "o", "(_)", "\\", "/", "/", "\\" };
            //                  ↑     ↑     ↑     ↑    ↑    ↑
            string[] kunas = { " ", "   ", " ", " ", " ", " " };
            // ↑↑↑ tarpai ==    1     3     1    1    1    1 ↑↑↑
            for (int i = 0; i < wrongCount; ++i) { kunas[i] = body[i]; };







            #region STATINIS PIESSINYS
            /////////////////////////////////////////////////////////            
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.WriteLine("     _________");/////////////////////
            Console.Write("     |       ");//////////////////////////
            Console.ForegroundColor = ConsoleColor.Yellow;///////////
            Console.Write("|\n");////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;/////// STATINIS PIESSINYS
            Console.Write("     |       ");//////////////////////////
            Console.ForegroundColor = ConsoleColor.Yellow;///////////
            Console.Write("|\n");////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("     |      ");///////////////////////////
                                          /////////////////////////////////////////////////////////
            #endregion

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(kunas[2]);//kaire ranka1
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(kunas[0]);//galva
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(kunas[3]);//desne ranka2

            #region STATINIS PIESSINYS
            /////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("\n    /|\\     ");//////////////////////// STATINIS PIESSINYS
                                             /////////////////////////////////////////////////////////
            #endregion

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(kunas[1]);//kunas

            #region STATINIS PIESSINYS
            /////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("\n   / | \\    ");//////////////////////// STATINIS PIESSINYS
                                             /////////////////////////////////////////////////////////
            #endregion

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(kunas[4]);//kaire koja1
            Console.Write(" ");//koju arpas
            Console.Write(kunas[5]);//desne koja2

            #region STATINIS PIESSINYS
            /////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("\n  /——|——\\\n");/////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkGreen;////////
            Console.Write("_");//////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("/");//////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkGreen;////////
            Console.Write("___");//////////////////////////////////// STATINIS PIESSINYS
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("|");//////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkGreen;////////
            Console.Write("___");////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkYellow;///////
            Console.Write("\\");/////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.DarkGreen;////////
            Console.WriteLine("________");///////////////////////////
                                          /////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

        }
    }
}
/*
 Instructions
- Naudotojas pasirenka iš temų: VARDAI, LIETUVOS MIESTAI, VALSTYBES, KITA. 
  (ne mažiau kaip 10 žodžių kiekvienoje grupėje)
+ Žodis iš pasirinktos grupės parenkamas atsitiktine tvarka.
+ Užtikrinti kad nebūtu duodamas tas pat žodis daugiau kaip 1 kartą per žaidimą
+ Užtikrinti, kad programą nenulūžtu jei vartotojas įveda ne tai ko prašoma
+ Ėjimas skaitomas tik jei spėjama dar nespėta raidė
+ Jei spėjamas visas žodis ir neatspėjama - iškarto pralaimima
+ Parodoma atspėtos raidės vieta žodyje
+ Parodomos spėtos, bet neatspėtos raidės

Apribojimai:
- Žodžius saugoti masyvuose  arba žodyne.
- Kodą skaidyti į metodus.
- negalima naudoti OOP ir LINQ
 */
// "","","","","","","","","",""