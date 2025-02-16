using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing_App_v01
{
    public class Node
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Size { get; set; }

        public Node(int x, int y, int size = 5)
        {
            X = x;
            Y = y;
            Size = size;
        }
    }
}
