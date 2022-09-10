using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
     class Game
    {
       
       

        public void Draw(string disk, int towerPosition, int line)
        {
            Console.CursorLeft = towerPosition - (disk.Length - 1) / 2;
            Console.CursorTop = line;
            Console.WriteLine(disk);

        }
       
         

            
    }
    
}
