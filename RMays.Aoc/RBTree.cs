using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmays.Aoc
{
    public class RBTree : BinaryTree
    {
        public new RBNode Root { get; set; }
    }

    public class RBNode : BinaryNode
    {
        public bool IsRed = false;
        public bool IsBlack => !IsRed;
    }
}
