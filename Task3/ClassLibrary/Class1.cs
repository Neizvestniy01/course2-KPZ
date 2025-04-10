using System;

namespace ClassLibrary
{
    public interface IRenderer
    {
        void Render(string shape);
    }
    public class VectorRenderer : IRenderer
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Drawing {shape} as vector graphics.");
        }
    }
    public class RasterRenderer : IRenderer
    {
        public void Render(string shape)
        {
            Console.WriteLine($"Drawing {shape} as pixels.");
        }
    }
    public abstract class Shape
    {
        protected IRenderer renderer;
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }
        public abstract void Draw();
    }
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer) { }
        public override void Draw()
        {
            renderer.Render("Circle");
        }
    }
    public class Square : Shape
    {
        public Square(IRenderer renderer) : base(renderer) { }
        public override void Draw()
        {
            renderer.Render("Square");
        }
    }
    public class Triangle : Shape
    {
        public Triangle(IRenderer renderer) : base(renderer) { }
        public override void Draw()
        {
            renderer.Render("Triangle");
        }
    }
}