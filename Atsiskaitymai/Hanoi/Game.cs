using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    internal class Game
    {
        public int tower1position = 10;
        public int tower2position = 20;
        public int tower3position = 30;
        public int line { get; set; }
        
        public void Draw(string disk)
        {
            Console.CursorLeft = tower1position - (disk.Length - 1) / 2;
            Console.CursorTop = line;
            Console.WriteLine(disk);

        }
    }
}
