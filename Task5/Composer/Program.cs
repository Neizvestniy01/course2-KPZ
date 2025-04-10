using System;
using ClassLibrary;

namespace Composer
{
    class Program
    {
        static void Main()
        {
            LightElementNode div = new LightElementNode("div", true, false);
            div.AddClass("container");
            LightElementNode ul = new LightElementNode("ul", true, false);
            ul.AddClass("list");
            LightElementNode li1 = new LightElementNode("li", true, false);
            li1.AddChild(new LightTextNode("Adolf"));
            LightElementNode li2 = new LightElementNode("li", true, false);
            li2.AddChild(new LightTextNode("Hitler"));

            ul.AddChild(li1);
            ul.AddChild(li2);
            div.AddChild(ul);
            Console.WriteLine(div.GetOuterHTML());
        }
    }
}