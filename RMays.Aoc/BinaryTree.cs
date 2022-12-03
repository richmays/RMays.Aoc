using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmays.Aoc
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryNode<T> Root { get; set; }

        public virtual void Insert(T newValue)
        {
            var nodeToAdd = new BinaryNode<T>
            {
                Data = newValue
            };

            if (Root == null)
            {
                Root = nodeToAdd;
                return;
            }

            var prev = Root;
            var curr = Root;
            while (curr != null)
            {
                prev = curr;
                if (newValue.CompareTo(curr.Data) < 0)
                {
                    curr = curr.Left;
                }
                else
                {
                    curr = curr.Right;
                }
            }

            // Curr is null, Prev is where we need to add the item.
            if (newValue.CompareTo(curr.Data) < 0)
            {
                prev.Left = nodeToAdd;
            }
            else
            {
                prev.Right = nodeToAdd;
            }
        }

        /// <summary>
        /// Remove a node from the given subtree.
        /// The node to find has the given value.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="findValue"></param>
        /// <returns>The root of the subtree after the 'RemoveNode' operation is done.</returns>
        private (BinaryNode<T>, bool) RemoveNode(BinaryNode<T> root, T findValue)
        {
            if (root == null)
            {
                return (root, false);
            }

            if (findValue.CompareTo(root.Data) < 0)
            {
                var result = RemoveNode(root.Left, findValue);
                root.Left = result.Item1;
                return (root, result.Item2);
            }
            else if (findValue.CompareTo(root.Data) > 0)
            {
                var result = RemoveNode(root.Right, findValue);
                root.Right = result.Item1;
                return (root, result.Item2);
            }

            if (root.Left == null && root.Right == null)
            {
                // Removing the root
                return (null, true);
            }
            else if (root.Left == null && root.Right != null)
            {
                // Remove the root, and promote the Right.
                return (root.Right, true);
            }
            else if (root.Left != null && root.Right == null)
            {
                // Remove the root, and promote the Left.
                return (root.Left, true);
            }
            else
            {
                // Node has 2 children.
                T maxValue = GetMaxValue(root.Left);
                root.Data = maxValue;
                var result = RemoveNode(root.Left, maxValue);
                root.Left = result.Item1;
                return (root, result.Item2);
            }
        }

        private T GetMaxValue(BinaryNode<T> root)
        {
            if (root.Right != null)
            {
                return GetMaxValue(root.Right);
            }

            return root.Data;
        }

        public virtual bool Remove(T findValue)
        {
            var result = RemoveNode(Root, findValue);
            if (result.Item2)
            {
                // We removed something
                Root = result.Item1;
            }

            return result.Item2;
        }

        public virtual bool Exists(T findValue)
        {
            return Find(findValue) != null;
        }

        public BinaryNode<T> Find(T findValue)
        {
            // Safety; can't remove anything from an empty tree.
            if (Root == null) return null;

            var curr = Root;
            while (curr != null && !curr.Data.Equals(findValue))
            {
                if (findValue.CompareTo(curr.Data) < 0)
                {
                    curr = curr.Left;
                }
                else
                {
                    curr = curr.Right;
                }
            }

            if (curr == null) return null;

            if (curr.Data.Equals(findValue))
            {
                return curr;
            }

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

    public class BinaryNode<T> where T : IComparable
    {
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }
        public T Data { get; set; }

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
