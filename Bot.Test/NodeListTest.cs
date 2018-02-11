using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bot.Core;

namespace Bot.Test
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void TestJson()
        {
            NodeList.GetList();
            string result = NodeList.ToJson();
            Assert.IsTrue(!string.IsNullOrEmpty(result));
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));
        }
        [TestMethod]
        public void TestMapping()
        {
            var tree = NodeList.GetList().ToNode();
            Assert.IsTrue(tree.Count> 0);

        }
    }
}
