using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    internal class Disk
    {
        public int size { get; set; }
        
     

        public string Object() 
        {
            StringBuilder disk = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                disk.Append("#");
            }
            disk.Append("|");
            for (int i = 0; i < size; i++)
            {
                disk.Append("#");
            }
            return disk.ToString();
        }
    }
}
