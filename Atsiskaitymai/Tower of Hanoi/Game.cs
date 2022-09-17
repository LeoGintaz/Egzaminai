using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Game
    {
        private string hand;
        private string handReset = "         ";
        
        public void Start(List<Tower> towers, List<string> disks)
        {
            Input input = new Input();
            towers[0].lines = disks;


            while (true)
            {
                towers[0].Draw();
                towers[1].Draw();
                towers[2].Draw();
                
                //---------Take-------------//
                switch (input.Read())
                {
                    case 1:
                        for (int i = 0; i < disks.Count; i++)
                        {
                            if (i == towers[0].lines.Count -1|| towers[0].lines[i].Length < towers[0].lines[i+1].Length)
                            {
                                Hand(towers[0].lines[i]);
                                towers[0].lines[i] = towers[0].lineReset;

                                break;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < disks.Count; i++)
                        {
                            if (i == towers[1].lines.Count -1 || towers[1].lines[i].Length < towers[1].lines[i + 1].Length)
                            {
                                Hand(towers[1].lines[i]);
                                towers[1].lines[i] = towers[1].lineReset;

                                break;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < disks.Count; i++)
                        {
                            if (i == towers[2].lines.Count - 1 || towers[2].lines[i].Length < towers[2].lines[i + 1].Length)
                            {
                                Hand(towers[2].lines[i]);
                                towers[2].lines[i] = towers[2].lineReset;

                                break;
                            }
                        }
                        break;
                    case -1:
                        break;
                }

                
                towers[0].Draw();
                towers[1].Draw();
                towers[2].Draw();

                //---------Place-------------//
                switch (input.Read())
                    {
                        case 1:
                           
                            for (int i = 3; i < disks.Count; i--)
                            {
                                if (!towers[0].lines[i].Contains("#"))
                                {
                                    towers[0].lines[i] = hand;
                                    Hand(handReset);

                                    break;
                                }

                            }
                            break;
                        case 2:
                        
                            for (int i = 3; i < disks.Count; i--)
                        {


                            if (towers[1].lines[i].Contains("#") || towers[1].lines[i].Where(x => (x == '#')).Count() > hand.Where(x => (x == '#')).Count())
                            {
                                Console.WriteLine("Error");
                                Console.WriteLine(hand);
                                Console.WriteLine(hand.Where(x => (x == '#')).Count());
                                Console.WriteLine(towers[1].lines[i]);
                                Console.WriteLine(towers[1].lines[i].Where(x => (x == '#')).Count());
                                Console.WriteLine(towers[1].lines[i].Where(x => (x == '#')).Count() < hand.Where(x => (x == '#')).Count());
                                

                              
                            }
                            
                            {
                                towers[1].lines[i] = hand;
                                Hand(handReset);
                                break;
                            }


                            break;




                        }
                        break;
                        case 3:
                        for (int i = 3; i < disks.Count; i--)
                        {
                            if (!towers[2].lines[i].Contains("#"))
                            {
                                towers[2].lines[i] = hand;
                                Hand(handReset);

                                break;
                            }
                        }
                            break;
                        
                        case -1:
                            break;
                    }

                
            }

        }
        private void Hand(string disk) 
        {
            hand = disk;
            Console.SetCursorPosition(30, 7);
            Console.WriteLine(disk);
        }


        /*  for (int i = 0; i < disks.Count; i++)
                        {
                            if (i == (disks.Count - 1) || disks[i].Length < disks[i+1].Length)
                            {
                                Hand(disks[i]);
                                towers[0].lines[i] = towers[0].lineReset;

                                break;
                            }
                        }
        */

    }
}

   

