using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class LightNode
    {
        public abstract string GetInnerHTML(int indentLevel = 0);
    }

    public class LightTextNode : LightNode
    {
        private string text;
        public LightTextNode(string text)
        {
            this.text = text;
        }
        public override string GetInnerHTML(int indentLevel = 0)
        {
            return text;
        }
    }

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        public bool IsBlockElement { get; }
        public bool IsSelfClosing { get; }
        private List<string> cssClasses;
        private List<LightNode> children;
        public LightElementNode(string tagName, bool isBlock, bool isSelfClosing)
        {
            TagName = tagName;
            IsBlockElement = isBlock;
            IsSelfClosing = isSelfClosing;
            cssClasses = new List<string>();
            children = new List<LightNode>();
        }
        public void AddClass(string className)
        {
            if (!cssClasses.Contains(className))
                cssClasses.Add(className);
        }
        public void AddChild(LightNode node)
        {
            if (!IsSelfClosing)
                children.Add(node);
        }
        public override string GetInnerHTML(int indentLevel = 0)
        {
            StringBuilder sb = new StringBuilder();
            string indent = new string(' ', indentLevel * 2);
            foreach (var child in children)
            {
                if (child is LightElementNode element)
                {
                    sb.AppendLine();
                    sb.Append(indent).Append(element.GetOuterHTML(indentLevel + 1));
                }
                else
                {
                    sb.Append(child.GetInnerHTML());
                }
            }
            return sb.ToString();
        }
        public string GetOuterHTML(int indentLevel = 0)
        {
            StringBuilder sb = new StringBuilder();
            string indent = new string(' ', indentLevel * 2);
            sb.Append(indent).Append("<").Append(TagName);
            if (cssClasses.Count > 0)
                sb.Append(" class=\"").Append(string.Join(" ", cssClasses)).Append("\"");
            if (IsSelfClosing)
            {
                sb.Append(" />");
            }
            else
            {
                sb.Append(">");
                sb.Append(GetInnerHTML(indentLevel + 1));
                sb.AppendLine();
                sb.Append(indent).Append("</").Append(TagName).Append(">");
            }
            return sb.ToString();
        }
    }
}