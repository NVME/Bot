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
        public void TestType()
        {
            //var lang = new LanguageNode();
            //lang.Header = new Header { Text = "Please select a language" };
            //var sub1 = new MenuNode();
            //sub1.Header = new Header { Text = "Password Rest" };
            //var agent = new HandoffNode();
            //agent.Header = new Header { Text = "Chat with Agent" };
            //sub1.Nodes.Add(agent);
            //var sub2 = new MenuNode();
            //sub2.Header = new Header { Text = "OutLook" };           
            //var info = new InformationalNode();
            //info.Header = new Header { Text = "Pleae go to this link for help" };
            //sub2.Nodes.Add(info);
            //lang.Nodes.Add(sub1);
            //lang.Nodes.Add(sub2);           

            //Assert.IsTrue(lang is LanguageNode);
            //Assert.IsTrue(lang.Nodes[0] is MenuNode);
            //var node = lang.Nodes[0] as MenuNode;
            //Assert.IsTrue(node.Nodes[0] is HandoffNode);

            //Assert.IsTrue(lang.Nodes[1] is MenuNode);
            //var node1 = lang.Nodes[1] as MenuNode;
            //Assert.IsTrue(node1.Nodes[0] is InformationalNode);
        }
        [TestMethod]
        public void TestXelement()
        {
            //var el = new XElement("");
            //var s = el.ToString();
           var dt= DateTime.ParseExact(18.ToString("00"), "HH", CultureInfo.CurrentCulture)
        .ToString("hh:mm tt");


        }

        [TestMethod]
        public void TestLanguageNode()
        {
            
            var tree = NodeList.GetList().ToNode();
            var langNode = tree.Where<Node>(n => n.Id == 10001).FirstOrDefault();
            var display = langNode.Display(NodeList.getSystemSetting());
           
        }

        [TestMethod]
        public void TestMenuNode()
        {
            var tree = NodeList.GetList().ToNode();
            var menu = tree.Where<Node>(n => n.Id == 11001).FirstOrDefault();           
            var display = menu.Display(NodeList.getSystemSetting());
           
        }

        [TestMethod]
        public void TestInformationNode()
        {
            var tree = NodeList.GetList().ToNode();
            var info = tree.Where<Node>(n => n.Id== 11102).FirstOrDefault();
            var display = info.Display(NodeList.getSystemSetting());
           
        }

        [TestMethod]
        public void HandoffNode()
        {
            var tree = NodeList.GetList().ToNode();
            var handoff = tree.Where<Node>(n => n.Id == 11112).FirstOrDefault();
            var display = handoff.Display(NodeList.getSystemSetting());
            var result = handoff.Handle("", NodeList.getSystemSetting());

        }

        
    }
}
