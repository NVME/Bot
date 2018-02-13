using System;
using Bot.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
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
            var dto = NodeList.GenerateLangageNodeDto();
            var langNode = new LanguageNode
            {
                Id = dto.Id,
                ParentId = dto.ParentId,
                Parent = null,
                Header = new Header { Format = dto.HeaderTextFormat, Text = dto.HeaderText },
                Footer = new Footer { Format = dto.FooterTextFormat, Text = dto.FooterText },
                Disclaimer = new Disclaimer { Format = dto.DisclaimerTextFormat, Text = dto.DisclaimerText },
                Keywords = dto.Keywords,
                LanguageOptions = dto.LanguageOptions,
                LanguagesAltText = dto.LanguageAltText,
                UseEnglishLanguageName = dto.UseEnglishLanguageName,
                AdditionalOptions = dto.AdditionalOptions,
                CweCommand = dto.CweCommand
            };
            var html = langNode.Display();
        }
    }
}
