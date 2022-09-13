using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_of_Hanoi
{
    internal class Disk
    {
        private int size;

        public Disk(int size)
        {
            this.size = size;

        }

        public string Generate()
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
