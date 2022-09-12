using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Board
    {
        public void Draw() //Draws border of the game. Lines 5 to 1 and bottom line
        {
            int linecount = 5;
            for (int i = linecount; i > 0; i--)
            {
                Console.WriteLine("Line" + i);
            }
            Console.WriteLine("      |----1----|----2----|----3----|");
        }
        public void DrawTower() // Draws Pillars of Tower
        {
            int nuberOFtowers = 3;
            int cursorPOSITION = 0;
            int rows = 5;
            for (int i = 0; i < nuberOFtowers; i++)
            {
                cursorPOSITION += 10;
                for (int row = 0; row < rows; row++)
                {
                    Console.SetCursorPosition(cursorPOSITION, row);
                    Console.WriteLine("|");
                }
            }
        }
        public void Hud()
        {
            Console.SetCursorPosition(5, 7);
            Console.WriteLine("Moves : ");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("Hand : ");
        }
    }
}
/*
0    Line5     |         |         |
1    Line4     |         |         |
2    Line3     |         |         |
3    Line2     |         |         |
4    Line1     |         |         |
5         |----1----|----2----|----3----|
6
7
8
*/
    

