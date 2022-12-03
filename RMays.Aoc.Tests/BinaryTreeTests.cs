using NUnit.Framework;
using Rmays.Aoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void BinaryTree_Create()
        {
            var bt = new BinaryTree<int>();
            Assert.AreEqual("", bt.ToString());
        }

        [Test]
        public void BinaryTree_Insert()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(1);
            bt.Insert(2);
            Assert.AreEqual("[-,1,[-,2,-]]", bt.ToLongString());
            Assert.AreEqual("12", bt.ToString());
            Assert.AreEqual("12", GetInOrder(bt.Root));
            Assert.AreEqual("12", GetPreorder(bt.Root));
            Assert.AreEqual("21", GetPostOrder(bt.Root));
        }

        [Test]
        public void BinaryTree_Insert_4()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(1);
            bt.Insert(2);
            bt.Insert(3);
            bt.Insert(4);
            Assert.AreEqual("[-,1,[-,2,[-,3,[-,4,-]]]]", bt.ToLongString());
            Assert.AreEqual("1234", bt.ToString());
            Assert.AreEqual("1234", GetInOrder(bt.Root));
            Assert.AreEqual("1234", GetPreorder(bt.Root));
            Assert.AreEqual("4321", GetPostOrder(bt.Root));
        }

        [Test]
        public void BinaryTree_Insert_4_Reverse()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(4);
            bt.Insert(3);
            bt.Insert(2);
            bt.Insert(1);
            Assert.AreEqual("[[[[-,1,-],2,-],3,-],4,-]", bt.ToLongString());
            Assert.AreEqual("1234", bt.ToString());
            Assert.AreEqual("1234", GetInOrder(bt.Root));
            Assert.AreEqual("4321", GetPreorder(bt.Root));
            Assert.AreEqual("1234", GetPostOrder(bt.Root));
        }

        [Test]
        public void BinaryTree_Insert_4_MixedUp()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(2);
            bt.Insert(4);
            bt.Insert(1);
            bt.Insert(3);
            Assert.AreEqual("[[-,1,-],2,[[-,3,-],4,-]]", bt.ToLongString());
            Assert.AreEqual("1234", bt.ToString());
            Assert.AreEqual("2143", GetPreorder(bt.Root));
            Assert.AreEqual("1342", GetPostOrder(bt.Root));
        }

        [Test]
        public void BinaryTree_Remove_Head()
        {
            // Arrange
            var bt = new BinaryTree<int>();
            bt.Insert(2);
            bt.Insert(1);
            bt.Insert(3);

            // Act
            bt.Remove(2);

            // Assert
            Assert.AreEqual("13", GetInOrder(bt.Root));
        }

        [Test]
        public void BinaryTree_RemoveAnywhere()
        {
            var defaultResult = "1234567";
            for (int i = 0; i <= 7; i++)
            {
                // Arrange
                var bt = BuildTree();
                bt.Remove(i);
                Assert.AreEqual(defaultResult.Replace(i.ToString(), ""), GetInOrder(bt.Root), $"Removing {i}...");
            }
        }

        [Test]
        public void BinaryTree_ExistsAnywhere()
        {
            var bt = BuildTree();

            Assert.IsFalse(bt.Exists(0), "Found 0, but we shouldn't have.");

            for (int i = 1; i <= 7; i++)
            {
                // Arrange
                Assert.IsTrue(bt.Exists(i), $"Didn't find {i}.");
            }
        }

        // Build a balanced tree with 7 nodes.
        private BinaryTree<int> BuildTree()
        {
            var bt = new BinaryTree<int>();
            bt.Insert(4);
            bt.Insert(2);
            bt.Insert(6);
            bt.Insert(1);
            bt.Insert(3);
            bt.Insert(5);
            bt.Insert(7);
            return bt;
        }

        private string GetPreorder(BinaryNode<int> node)
        {
            if (node == null) return "";

            return $"{node.Data}{GetPreorder(node.Left)}{GetPreorder(node.Right)}";
        }

        private string GetInOrder(BinaryNode<int> node)
        {
            if (node == null) return "";

            return $"{GetInOrder(node.Left)}{node.Data}{GetInOrder(node.Right)}";
        }

        private string GetPostOrder(BinaryNode<int> node)
        {
            if (node == null) return "";

            return $"{GetPostOrder(node.Left)}{GetPostOrder(node.Right)}{node.Data}";
        }
    }
}
