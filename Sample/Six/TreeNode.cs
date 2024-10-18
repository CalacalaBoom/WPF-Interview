using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    public class TreeNode
    {
        public int Value;
        public TreeNode? Left;
        public TreeNode? Right;
        public int Height;
        public TreeNode(int value)
        {
            Value = value;
            Height = 1;
        }
    }
}
