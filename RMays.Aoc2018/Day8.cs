using RMays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc2018
{
    public class Day8
    {
        public class Node2
        {
            public List<Node2> ChildNodes { get; set; }
            public List<int> MetaData { get; set; }

            public Node2()
            {
                ChildNodes = new List<Node2>();
                MetaData = new List<int>();
            }

            public int GetMetaDataSum()
            {
                return MetaData.Sum(x => x) + ChildNodes.Sum(x => x.GetMetaDataSum());
            }

            public int GetValue()
            {
                if (ChildNodes.Count == 0) return MetaData.Sum(x => x);
                var result = 0;
                foreach (var m in MetaData)
                {
                    if (m >= 1 && m <= ChildNodes.Count)
                    {
                        result += ChildNodes[m - 1].GetValue();
                    }
                }
                return result;
            }

            public override string ToString()
            {
                return $"Value: {GetValue()}";
            }
        }

        public long SolveA(string input)
        {
            // 2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2
            // A-----------------------------m-m-m
            //     B----m--m--m C----------m
            //                      D----m

            // I don't know what part 2 is, but I can assume it's some tree-traversal thing.
            // So don't do the easy algorithm where we just walk through and add numbers.
            // Let's actually build the tree.

            var myList = Parser.Tokenize(input, ' ').Select(x => int.Parse(x)).ToList();
            var parentNode = new Node2();

            ReadNode(parentNode, myList);

            // Now, traverse, and get the total.
            return parentNode.GetMetaDataSum();
        }

        private void ReadNode(Node2 node, List<int> myList)
        {
            var numChildNodes = Pop(myList);
            var numMetaDatas = Pop(myList);
            for (var nodeIndex = 0; nodeIndex < numChildNodes; nodeIndex++)
            {
                var childNode = new Node2();
                ReadNode(childNode, myList);
                node.ChildNodes.Add(childNode);
            }
            for (var nodeIndex = 0; nodeIndex < numMetaDatas; nodeIndex++)
            {
                node.MetaData.Add(Pop(myList));
            }
        }

        private int Pop(List<int> myList)
        {
            var toReturn = myList.First();
            myList.RemoveAt(0);
            return toReturn;
        }

        public long SolveB(string input)
        {
            var myList = Parser.Tokenize(input, ' ').Select(x => int.Parse(x)).ToList();
            var parentNode = new Node2();

            ReadNode(parentNode, myList);

            // Now, traverse, and get the total.
            return parentNode.GetValue();
        }
    }
}
