using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hanoi
{
    internal class Map
    {
        public List<int> tower = new List<int>
        {
          10, //tower 1 position  0
          20, //tower 2 position  1
          30 //tower 3 position   2

        };

        public List<int> line = new List<int>
        {
        4, // bottom line       0   line 1
        3, //bottom niddle line 1   line 2
        2, // top middle line   2   line 3
        1  // top line          3   line 4
        };
    }
}
