using System;
using System.Linq;
using System.Collections.Generic;
using Bot.COMM;

namespace Bot.Core
{
    public static class MapperExtension
    {
        public static BotProfile ToBotProfile(this BotProfileDto dto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Used as a deep copy of node list, so each conversation will have independent node list.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Node> ToNode(this List<NodeDto> list)
        {
            var treenodes = new List<Node>();
            //lock (new object())
            //{
            var nodes = new List<Node>();
            var languageNodes = list.Where(n => (NodeType)n.TypeId == NodeType.LanguageNode)
                .Select(
                    dto => new LanguageNode
                    {
                        Id = dto.Id,
                        ParentId = dto.ParentId,
                        Parent = null,
                        TextFormat = dto.TextFormat,
                        HeaderText = dto.HeaderText,
                        FooterText = dto.FooterText,
                        DisclaimerText = dto.DisclaimerText,
                        Keywords = dto.Keywords,
                        LanguageOptions = dto.LanguageOptions,
                        LanguagesAltText = dto.LanguageAltText,
                        UseEnglishLanguageName = dto.UseEnglishLanguageName,
                        AdditionalOptions = dto.AdditionalOptions,
                        CweCommand = dto.CweCommand
                    });
            var menuNodes = list.Where(n => (NodeType)n.TypeId == NodeType.MenuNode)
                .Select(
                    dto => new MenuNode
                    {
                        Id = dto.Id,
                        ParentId = dto.ParentId,
                        Parent = null,
                        TextFormat = dto.TextFormat,
                        HeaderText = dto.HeaderText,
                        FooterText = dto.FooterText,
                        DisclaimerText = dto.DisclaimerText,
                        OptionDisplayText = dto.OptionText,
                        DisableGoBackOption = dto.DisableGoBackOption,
                        Keywords = dto.Keywords,
                        HideMenu = dto.HideMenu,
                        HideMenuNumbers = dto.HideMenuNumbers,
                        AdditionalOptions = dto.AdditionalOptions,
                        CweCommand = dto.CweCommand
                    });

            var informationalNodes = list.Where(n => (NodeType)n.TypeId == NodeType.InformationalNode)
                .Select(
                dto => new InformationalNode
                {
                    Id = dto.Id,
                    ParentId = dto.ParentId,
                    Parent = null,
                    TextFormat = dto.TextFormat,
                    HeaderText = dto.HeaderText,
                    Keywords = dto.Keywords,
                    OptionDisplayText = dto.OptionText,
                    DisableGoBackOption = dto.DisableGoBackOption,
                    DisplayConnectionText = dto.DisplayConnectionText,
                    AdditionalOptions = dto.AdditionalOptions,
                    CweCommand = dto.CweCommand
                });
            var handoffNodes = list.Where(n => (NodeType)n.TypeId == NodeType.HandoffNode)
                .Select(dto => new HandoffNode
                {
                    Id = dto.Id,
                    ParentId = dto.ParentId,
                    Parent = null,
                    TextFormat = dto.TextFormat,
                    HeaderText = dto.HeaderText,
                    Keywords = dto.Keywords,
                    OptionDisplayText = dto.OptionText,
                    DisclaimerText = dto.DisclaimerText,
                    DisplayHoursOfOperation = dto.DisplayHoursOfOperation,
                    ShowConfirmation = dto.ShowConfirmation,
                    AdditionalOptions = dto.AdditionalOptions,
                    CweCommand = dto.CweCommand
                });
            var nodelinks = list.Where(n => (NodeType)n.TypeId == NodeType.NodeLink)
               .Select(dto => new NodeLink
               {
                   Id = dto.Id,
                   ParentId = dto.ParentId,
                   Parent = null,
                   TextFormat = dto.TextFormat,
                   NodeLinkNodeId = dto.NodeLinkNodeId,
                   Goto = null,
                   Keywords = dto.Keywords,
                   OptionDisplayText = dto.OptionText,
                   AdditionalOptions = dto.AdditionalOptions,
                   CweCommand = dto.CweCommand
               });

            foreach (var node in nodelinks)
            {
                int gotoNodeId = node.NodeLinkNodeId;
                if (node.Goto == null) node.Goto = languageNodes.FirstOrDefault(n => n.Id ==gotoNodeId);
                if (node.Goto== null) node.Goto = menuNodes.FirstOrDefault(n => n.Id == gotoNodeId);
                if (node.Goto == null) node.Goto = informationalNodes.FirstOrDefault(n => n.Id == gotoNodeId);
                if (node.Goto == null) node.Goto = handoffNodes.FirstOrDefault(n => n.Id == gotoNodeId);
            }
            nodes.AddRange(languageNodes);
            nodes.AddRange(menuNodes);
            nodes.AddRange(informationalNodes);
            nodes.AddRange(handoffNodes);
            nodes.AddRange(nodelinks);

            foreach (var node in nodes)
            {
                node.Parent = nodes.Find(n => n.Id == node.ParentId);               
                if (node is MenuNode)
                {
                    var menuNode = node as MenuNode;
                    menuNode.Nodes.AddRange(nodes.Where(n => n.ParentId == menuNode.Id && n.Id != n.ParentId));
                    treenodes.Add(menuNode);
                }
               
                if (!treenodes.Any(tn => tn.Id == node.Id)) treenodes.Add(node);
            }
            nodes = null;
            // }
            return treenodes;
        }

        public static Queue ToQueue(this QueueDto dto)
        {
            if (dto == null) throw new ApplicationException("null reference object");
            return new Queue { EnglishName = dto.Name };
        }
    }

    public enum NodeType
    {
        LanguageNode = 1,
        MenuNode = 2,
        InformationalNode = 3,
        LoopbackNode = 4,
        HandoffNode = 5,
        VirtualAgentNode = 6,
        NodeLink = 7

    }
    public static class ListExtenstions
    {
        public static void AddMany<T>(this List<T> list, params T[] elements)
        {
            list.AddRange(elements);
        }
    }
}
