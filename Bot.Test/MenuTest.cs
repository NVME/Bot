using System;
using Bot.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using System.Linq;
using System.Globalization;

namespace Bot.Test
{
    [TestClass]
    public class MenuTest
    {
       
        [TestMethod]
        public void TestLanguageNode()
        {

            var tree = NodeList.GetList().ToNode();
            var langNode = tree.Where<Node>(n => n.Id == 10001).FirstOrDefault();
            var display = langNode.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.Display);
            var result = langNode.Handle("", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Invalid);
            result = langNode.Handle("1", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            Assert.AreEqual(result.Next.LanguageCode, "en-us");
            result = langNode.Handle(" 1 ", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            result = langNode.Handle("en", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            Assert.AreEqual(result.Next.LanguageCode, "en-us");

        }

        [TestMethod]
        public void TestMenuNode()
        {
            var tree = NodeList.GetList().ToNode();
            var menu = tree.Where<Node>(n => n.Id == 11001).FirstOrDefault();
            var display = menu.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.Display);
            var result = menu.Handle("", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Invalid);
            result = menu.Handle("1", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            result = menu.Handle("sap", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            result = menu.Handle("SAP", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);

        }

        [TestMethod]
        public void TestInformationNode()
        {
            var tree = NodeList.GetList().ToNode();
            var info = tree.Where<Node>(n => n.Id == 11102).FirstOrDefault();
            var display = info.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.Display);
            var result = info.Handle("", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Invalid);
            result = info.Handle("1", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Invalid);
        }

        [TestMethod]
        public void HandoffNode()
        {
            var tree = NodeList.GetList().ToNode();
            var handoff = tree.Where<Node>(n => n.Id == 11112).FirstOrDefault();
            var display = handoff.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.Display);
            var result = handoff.Handle("", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Invalid);
            result = handoff.Handle("1", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.HandOff);
            result = handoff.Handle(" 1 ", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.HandOff);
            result = handoff.Handle(" #", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.GoBack);
            //11111
            var handoffNoConfirmation = tree.Where<Node>(n => n.Id == 11111).FirstOrDefault();
            display = handoffNoConfirmation.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.HandOffNoConfirmation);
        }

        [TestMethod]
        public void FlowTest()
        {
            var tree = NodeList.GetList().ToNode();
            var root = tree.Where(n => n.IsRootNode).FirstOrDefault();
            Assert.IsNotNull(root);
            var display = root.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.Display);
            var result = root.Handle(" 2", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            var menu = result.Next;
            Assert.IsNotNull(menu);
            Assert.AreEqual(menu.LanguageCode, "cantonese");
            display=menu.Display(NodeList.getSystemSetting());
            Assert.AreEqual(display.Type, DisplayResultType.Display);
            result = menu.Handle("sap", NodeList.getSystemSetting());
            Assert.AreEqual(result.Type, InteractionResultType.Matched);
            var sap = result.Next;
            Assert.IsNotNull(sap);
            Assert.AreEqual(sap.LanguageCode, "cantonese");



        }

    }
}
