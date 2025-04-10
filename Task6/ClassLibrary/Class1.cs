using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public abstract class LightNode
    {
        public abstract string GetOuterHTML();
    }

    public class LightTextNode : LightNode
    {
        private string text;
        public LightTextNode(string text)
        {
            this.text = text;
        }
        public override string GetOuterHTML()
        {
            return text;
        }
    }

    public class LightElementNode : LightNode
    {
        public string TagName { get; }
        private List<LightNode> children = new List<LightNode>();
        public LightElementNode(string tagName)
        {
            TagName = tagName;
        }
        public void AddChild(LightNode node)
        {
            children.Add(node);
        }
        public override string GetOuterHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<").Append(TagName).Append(">");

            foreach (var child in children)
            {
                sb.Append(child.GetOuterHTML());
            }
            sb.Append("</").Append(TagName).Append(">\n");
            return sb.ToString();
        }
    }
}