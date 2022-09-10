using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandymai
{
    internal class Input
    {
        public int GetPosition()
        {
            while (true)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Write("1");
                        return 0;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Write("2");
                        return 1;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Write("3");
                        return 2;
                    case ConsoleKey.Escape:
                        Console.Write("ESC");
                        return -1;
                    default:
                        Console.WriteLine("Ivalid Key");
                        return 3;

                }
            }
        }
    }
}
