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
            var bt = new BinaryTree();
            Assert.AreEqual("", bt.ToString());
        }

        [Test]
        public void BinaryTree_Add()
        {
            var bt = new BinaryTree();
            bt.Insert(1);
            bt.Insert(2);
            Assert.AreEqual("[-,1,[-,2,-]]", bt.ToLongString());
            Assert.AreEqual("12", bt.ToString());
        }

        [Test]
        public void BinaryTree_Add_4()
        {
            var bt = new BinaryTree();
            bt.Insert(1);
            bt.Insert(2);
            bt.Insert(3);
            bt.Insert(4);
            Assert.AreEqual("[-,1,[-,2,[-,3,[-,4,-]]]]", bt.ToLongString());
            Assert.AreEqual("1234", bt.ToString());
        }

        [Test]
        public void BinaryTree_Add_4_Reverse()
        {
            var bt = new BinaryTree();
            bt.Insert(4);
            bt.Insert(3);
            bt.Insert(2);
            bt.Insert(1);
            Assert.AreEqual("[[[[-,1,-],2,-],3,-],4,-]", bt.ToLongString());
            Assert.AreEqual("1234", bt.ToString());
        }

        [Test]
        public void BinaryTree_Add_4_MixedUp()
        {
            var bt = new BinaryTree();
            bt.Insert(2);
            bt.Insert(4);
            bt.Insert(1);
            bt.Insert(3);
            Assert.AreEqual("[[-,1,-],2,[[-,3,-],4,-]]", bt.ToLongString());
            Assert.AreEqual("1234", bt.ToString());
        }
    }
}
