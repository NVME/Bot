using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
