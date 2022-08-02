using System;
using System.Text;

namespace Hangman
{

    internal class Program

    {
        public static List<int> usedRandIndex = new List<int>();
        //public static List<int> usedRandIndex = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static int wrongCount = 0;
        public static bool gameOn = true;
        public static bool menuOn = true;
        //public static bool looseMenuOn = true;



        static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()
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
                    case "1":

                        gameOn = true;
                        Vardai();
                        break;
                    case "2":
                        gameOn = true;
                        Miestai();
                        break;
                    case "3":
                        gameOn = true;
                        Valstybes();
                        break;
                    case "4":
                        gameOn = true;
                        Gyvunai();
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

        public static void Gyvunai()
        {
            var gyvunuZodynas = new Dictionary<int, string>()
            {
                {1, "GEPARDAS"},
                {2, "BEGEMOTAS"},
                {3, "GYVATE"},
                {4, "LIUTAS"},
                {5, "PANTERA"},
                {6, "STIRNA"},
                {7, "JAUTIS"},
                {8, "VILKAS"},
                {9, "LEOPARDAS"},
                {10, "STRUTIS"}
            };
            Game(gyvunuZodynas);
        }

        public static void Valstybes()
        {
            var valstybiuZodynas = new Dictionary<int, string>()
            {
                {1, "LIETUVA"},
                {2, "ESTIJA"},
                {3, "LATVIJA"},
                {4, "LENKIJA"},
                {5, "KANADA"},
                {6, "BRAZILIJA"},
                {7, "JAPONIJA"},
                {8, "KROATIJA"},
                {9, "SLOVAKIJA"},
                {10, "VOKIETIJA"}
            };
            Game(valstybiuZodynas);
        }

        public static void Miestai()
        {
            var miestuZodynas = new Dictionary<int, string>()
            {
                {1, "KAUNAS"},
                {2, "VILNIUS"},
                {3, "KLAIPEDA"},
                {4, "PANEVEZYS"},
                {5, "SIAULIAI"},
                {6, "JUODKRANTE"},
                {7, "NIDA"},
                {8, "PERVALKA"},
                {9, "ALYTUS"},
                {10, "AKMENE"}
            };
            Game(miestuZodynas);
        }

        /*        private static void LooseMenu()
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
                }*/

        public static void Vardai()
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
            Game(varduZodynas);
        }



        /*        public static int MenuValidacija(string input)
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

                }*/

        /*        public static string ZaidimoValidaacija(string input)
                {

                    bool isNumber = double.TryParse(input, out _);
                    if (isNumber == true || isNumber == null)
                    {
                        Console.WriteLine("Negalima ivestis");
                        return "-1";
                    }
                    return input;

                }*/
        public static void Game(Dictionary<int, string> dict)
        {
            Random rand = new Random();
            var x = true;
            while (x)
            {
                int randIndex = rand.Next(1, (dict.Count + 1));// 1 - kad nebudtu generuojamas 0,,, +1 kad dictionary ilgi imtu imtinai.
                //----------------------------------------------//
                GameWinCondition(dict, ref x);

                UsedRandIndexCheck(ref randIndex, rand);


                //------------------------------------//
                var hiddenWord = new StringBuilder();

                string word = dict[randIndex];
                //string word = "ABC";

                foreach (var item in word) { hiddenWord.Append("-"); }

                Guess(hiddenWord, word);
            }


        }

        public static void UsedRandIndexCheck(ref int randIndex, Random rand)
        {
            while (usedRandIndex.Contains(randIndex)) { randIndex = rand.Next(1, 11); };
            usedRandIndex.Add(randIndex);
        }

        public static void GameWinCondition(Dictionary<int, string> dict, ref bool x)
        {
            if (usedRandIndex.Count == dict.Count)
            {
                Console.WriteLine("Laimejote");
                Console.ReadKey();
                usedRandIndex.Clear();
                wrongCount = 0;
                gameOn = false;
                x = false;
            }
        }

        public static void Guess(StringBuilder hiddenWord, string word)
        {
            var spetosRaides = new StringBuilder();

            var indexList = new List<int>();

            while (gameOn)
            {

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
                    break;
                }
                Drwing();

                Console.WriteLine(hiddenWord.ToString());
                Console.WriteLine(wrongCount);
                Console.WriteLine("Spetos Raides:\n{0}", spetosRaides.ToString());

                var guess = Console.ReadLine().ToUpper();

                foreach (var letter in guess)
                {
                    WrongCountCalculator(letter, word, ref spetosRaides);
                    CorrectGuess(letter, word, indexList, hiddenWord);
                }







            }


        }

        public static void CorrectGuess(char letter, string word, List<int> indexList, StringBuilder hiddenWord)
        {

            if (word.Contains(letter))
            {

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter) indexList.Add(i);
                }

            }
            foreach (var index in indexList) { hiddenWord[index] = word[index]; }
        }


        public static void WrongCountCalculator(char letter, string word, ref StringBuilder spetosRaides)
        {
            //if (guess.Length == word.Length) { wrongCount = 6; }          


            if (word.Contains(letter) == false)
            {

                bool isNumber = int.TryParse(letter.ToString(), out _);
                if (isNumber == true || isNumber == null)
                {
                    //nedaro nieko , skaiciaus ivedimas nefiksuojamas
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


        public static void Drwing()
        {


            //               galva|kunas|rank1|ranka2|koja1|koja2
            string[] body = { "o", "(_)", "\\", "/", "/", "\\" };
            //                  ↑     ↑     ↑     ↑    ↑    ↑
            string[] kunas = { " ", "   ", " ", " ", " ", " " };
            // ↑↑↑ tarpai ==    1     3     1    1    1    1 ↑↑↑

            for (int i = 0; i < wrongCount; ++i)
            {
                kunas[i] = body[i];

            };







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
+ Naudotojas pasirenka iš temų: VARDAI, LIETUVOS MIESTAI, VALSTYBES, KITA. 
  (ne mažiau kaip 10 žodžių kiekvienoje grupėje)
+ Žodis iš pasirinktos grupės parenkamas atsitiktine tvarka.
+ Užtikrinti kad nebūtu duodamas tas pat žodis daugiau kaip 1 kartą per žaidimą
+ Užtikrinti, kad programą nenulūžtu jei vartotojas įveda ne tai ko prašoma
+ Ėjimas skaitomas tik jei spėjama dar nespėta raidė
+ Jei spėjamas visas žodis ir neatspėjama - iškarto pralaimima
+ Parodoma atspėtos raidės vieta žodyje
+ Parodomos spėtos, bet neatspėtos raidės

Apribojimai:
+ Žodžius saugoti masyvuose  arba žodyne.
+ Kodą skaidyti į metodus.
+ negalima naudoti OOP ir LINQ
 */
// "","","","","","","","","",""