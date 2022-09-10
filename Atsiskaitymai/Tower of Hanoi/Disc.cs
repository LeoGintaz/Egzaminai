using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Disc
    {
        public int size;
        public int top;

        public void Draw()
        {
            var pos = size;
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(12 - pos, top);
                pos--;
                Console.WriteLine("#");
            }
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(13 + pos, top);
                pos++;
                Console.WriteLine("#");
            }
        }
    }


}
