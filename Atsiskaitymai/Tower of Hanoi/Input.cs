using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Input
    {
        public int Read()
        {
           
            Console.SetCursorPosition(5, 9);
            ConsoleKeyInfo keyInput = Console.ReadKey(true);


            switch (keyInput.Key)
            {
                case ConsoleKey.NumPad1:
                    Console.WriteLine("         1");
                    //break;
                    return 1;
                    break;
                case ConsoleKey.NumPad2:
                    Console.WriteLine("         2");
                    //break;
                    return 2;
                case ConsoleKey.NumPad3:
                    Console.WriteLine("         3");
                    //break;
                    return 3;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    //break;
                    return -2;
                default:
                    Console.WriteLine(" Wrong Key");
                    //break;
                    return -1;

            }


        }
    }
}
