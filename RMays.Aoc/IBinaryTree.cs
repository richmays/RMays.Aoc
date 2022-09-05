using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmays.Aoc
{
    public interface IBinaryTree
    {
        /// <summary>
        /// Inserts the given number into the binary tree.
        /// </summary>
        /// <param name="newData">The number to insert.</param>
        /// <returns>Did this operation succeed?  ('False' means a duplicate was found.)</returns>
        bool Insert(long newData);

        /// <summary>
        /// Remove the given number from the binary tree.
        /// </summary>
        /// <param name="findData">The number to find; if it's found, remove it</param>
        /// <returns>Did this operation succeed?  ('False' means it wasn't found.)</returns>
        bool Remove(long findData);

        /// <summary>
        /// Returns whether or not the number exists in the binary tree.
        /// </summary>
        /// <param name="findData">The number to find.</param>
        /// <returns>True if the number is in the tree, False otherwise.</returns>
        bool Exists(long findData);

        /// <summary>
        /// Returns the node that contains the given number, or null if the number wasn't found.
        /// </summary>
        /// <param name="findData">The number to find.</param>
        /// <returns>The node containing the number, or null if the number wasn't found.</returns>
        BinaryNode Find(long findData);
    }
}
