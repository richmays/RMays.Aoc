using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmays.Aoc
{
    public class BinaryTree : IBinaryTree
    {
        public BinaryNode Root { get; set; }

        public virtual bool Insert(long newValue)
        {
            var nodeToAdd = new BinaryNode
            {
                Data = newValue
            };

            if (Root == null)
            {
                Root = nodeToAdd;
                return true;
            }

            var prev = Root;
            var curr = Root;
            while (curr != null)
            {
                prev = curr;
                if (curr.Data > newValue)
                {
                    curr = curr.Left;
                }
                else if (curr.Data < newValue)
                {
                    curr = curr.Right;
                }
                else
                {
                    // Duplicate!  Can't insert.
                    return false;
                }
            }

            // Curr is null, Prev is where we need to add the item.
            if (prev.Data > newValue)
            {
                prev.Left = nodeToAdd;
            }
            else if (prev.Data < newValue)
            {
                prev.Right = nodeToAdd;
            }

            return true;
        }

        public virtual bool Remove(long findData)
        {
            return false;
        }

        public virtual bool Exists(long findValue)
        {
            return false;
        }

        public BinaryNode Find(long findData)
        {
            return null;
        }

        public string ToLongString()
        {
            if (Root == null) return "";
            return Root.ToLongString();
        }

        public override string ToString()
        {
            if (Root == null) return "";
            return Root.ToString();
        }

    }

    public class BinaryNode
    {
        public BinaryNode Left { get; set; }
        public BinaryNode Right { get; set; }
        public long Data { get; set; }

        public string ToLongString()
        {
            return $"[{Left?.ToLongString() ?? "-"},{Data},{Right?.ToLongString() ?? "-"}]";
        }

        public override string ToString()
        {
            return $"{Left?.ToString() ?? ""}{Data}{Right?.ToString() ?? ""}";
        }
    }
}
