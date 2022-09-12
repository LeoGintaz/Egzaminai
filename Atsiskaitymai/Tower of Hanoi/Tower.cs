using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Tower
    {
        public int xAxis;
        private List<bool> lines = new List<bool> { false, false, false, false };
        public string line1 = "    |    ";
        public string line2 = "    |    ";
        public string line3 = "    |    ";
        public string line4 = "    |    ";
        public string lineReset = "    |    ";
        

        public void Set() 
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i] == true)
                {
                    Console.SetCursorPosition(xAxis - (8) / 2, i);// Tower middle - Max Disk Lenght (####|####) - 1 (|) halfed. To draw disks middle in towers middle
                    Console.WriteLine("    |    ");
                    lines[i] = false;
                    break;
                }
            }
        }
        public void Draw()
        {
            //Console.CursorLeft = xAxis;
            Console.SetCursorPosition(xAxis, 0);

            Console.WriteLine(lineReset);
            Console.SetCursorPosition(xAxis, 1);
            Console.WriteLine(line1);
            Console.SetCursorPosition(xAxis, 2);
            Console.WriteLine(line2);
            Console.SetCursorPosition(xAxis, 3);
            Console.WriteLine(line3);
            Console.SetCursorPosition(xAxis, 4);
            Console.WriteLine(line4);
        }
    }
}
