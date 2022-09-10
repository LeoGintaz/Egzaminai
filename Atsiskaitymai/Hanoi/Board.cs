using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    internal class Board
    {
        internal int linecount = 5;
        
        public void Draw()
        {
            for (int i = linecount; i > 0; i--)
            {
                Console.WriteLine("Line" + i);
            }
            Console.WriteLine("     |----1----|----2----|----3----|");
        }
        public void DrawTower()
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
    }
}
