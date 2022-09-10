using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Game
    {
        public void Draw()
        {
            var cursorTop = 9;
            var cursorLeft = 0;
            var list = new List<int>{1,2,3}; 

            Console.SetCursorPosition(0, 15);
            Console.WriteLine("      |====[1]====|====[2]====|====[3]====|");

            foreach (var item in list)
            {
                cursorLeft += 12;
                cursorTop = 9;



                for (int j = 0; j < 6; j++)
                {
                    Console.SetCursorPosition(cursorLeft, cursorTop);
                    Console.WriteLine("|");
                    cursorTop += 1;
                }
            }
         /*   for (int i = 0; i < 5; i++)
            {
                Console.SetCursorPosition(cursorLeft, cursorTop);
                Console.WriteLine("|");
                cursorTop += 1;
            }*/
            
            

        }
    }

   
}
