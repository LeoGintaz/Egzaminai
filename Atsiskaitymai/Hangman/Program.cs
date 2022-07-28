using System;
using System.Text;

namespace Hangman
{

    internal class Program
        
    {
        public static int wrongCount = 0;
        public static bool gameOn = true;
        public static bool menuOn = true;
        public static int i2 = 0;
        
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            
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
         

            while (gameOn)
            {

               
                Random rand = new Random();
                int randIndex = rand.Next(list.Count);
                string word = list[randIndex];
                //------------------------------------//
                var hiddenWord = new StringBuilder();
                foreach (var item in word) { hiddenWord.Append("-"); }



               
                Guess(hiddenWord, word);
                
            }
        }

        public static void Guess(StringBuilder hiddenWord, string word)

        {
            var spetosRaides = new StringBuilder();

            var indexList = new List<int>();
            while (gameOn)
            {
                
                Console.Clear();
                Drwing();


                Console.WriteLine(hiddenWord.ToString());
                Console.WriteLine(wrongCount);
                Console.WriteLine("Spetos Raides:\n{0}",spetosRaides.ToString());
                var guess = Console.ReadLine().ToUpper();
                foreach (var letter in guess)  { spetosRaides.Append(letter); spetosRaides.Append(" "); };
                

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
                else
                {
                    foreach (var letter in guess)
                    {

                        ++wrongCount;
                        if (wrongCount > 5)
                        {

                            wrongCount++;

                            Console.WriteLine("Pralaimejote");
                                Console.ReadKey();

                            gameOn = false;
                            menuOn = true;
                            
                        }
                        

                    }
                }


                foreach (var index in indexList)
                {

                    
                        hiddenWord[index] = word[index];

                        
                    
                }

            }
        }

        private static void Drwing()
        {
            //               galva|kunas|rank1|ranka2|koja1|koja2
            string[] body  = { "o", "(_)", "\\", "/", "/", "\\" };
            //                  ↑     ↑     ↑     ↑    ↑    ↑
            string[] kunas = { " ", "   ", " ", " ", " ", " " };
            // ↑↑↑ tarpai ==    1     3     1    1    1    1 ↑↑↑
            for (int i = 0 ; i < wrongCount ; i++)
            {
                kunas[i] = body[i];
            }

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