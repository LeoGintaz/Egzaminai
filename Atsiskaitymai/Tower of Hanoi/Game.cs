using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Game
    {
        public void Start(List<Tower> towers, List<string> disks)
        {
            towers[0].line1 = disks[0];
            towers[0].line2 = disks[1];
            towers[0].line3 = disks[2];
            towers[0].line4 = disks[3];
            towers[0].Draw();
            towers[1].Draw();
            towers[2].Draw();


        }




    }
}

   

