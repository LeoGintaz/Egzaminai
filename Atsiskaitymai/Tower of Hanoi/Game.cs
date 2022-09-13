using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Game
    {
        private string handReset = "";
        
        public void Start(List<Tower> towers, List<string> disks)
        {
            Input input = new Input();
            towers[0].line1 = disks[0];
            towers[0].line2 = disks[1];
            towers[0].line3 = disks[2];
            towers[0].line4 = disks[3];
          

            while (true)
            {
                towers[0].Draw();
                towers[1].Draw();
                towers[2].Draw();
                switch (input.Read())
                {
                    case 1:
                        for (int i = 0; i < disks.Count; i++)
                        {
                            if (disks[i].Length < disks[i + 1].Length)
                            {
                                towers[0].lines[i] = towers[0].lineReset;
                                Hand(disks[i]);
                                break;
                            }
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case -1:
                        break;
                }
            }

        }
        private void Hand(string disk) 
        { 
            Console.SetCursorPosition(30, 7);
            Console.WriteLine(disk);
        }




    }
}

   

