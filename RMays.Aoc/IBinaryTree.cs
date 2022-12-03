using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmays.Aoc
{
    public interface IBinaryTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// Inserts the given value into the binary tree.
        /// </summary>
        /// <param name="newData">The value to insert.</param>
        void Insert(T newData);

        /// <summary>
        /// Remove the given value from the binary tree.
        /// </summary>
        /// <param name="findData">The value to find; if it's found, remove it</param>
        /// <returns>Did this operation succeed?  ('False' means it wasn't found.)</returns>
        bool Remove(T findData);

        /// <summary>
        /// Returns whether or not the value exists in the binary tree.
        /// </summary>
        /// <param name="findData">The value to find.</param>
        /// <returns>True if the value is in the tree, False otherwise.</returns>
        bool Exists(T findData);

        /// <summary>
        /// Returns the node that contains the given value, or null if the value wasn't found.
        /// </summary>
        /// <param name="findData">The value to find.</param>
        /// <returns>The node containing the value, or null if the value wasn't found.</returns>
        BinaryNode<T> Find(T findData);
    }
}
