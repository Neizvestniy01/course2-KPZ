using System;
using ClassLibrary;

class Program
{
    static void Main()
    {
        IRenderer vectorRenderer = new VectorRenderer();
        IRenderer rasterRenderer = new RasterRenderer();

        Shape circle = new Circle(vectorRenderer);
        circle.Draw();
        Shape square = new Square(rasterRenderer);
        square.Draw();
        Shape triangle = new Triangle(rasterRenderer);
        triangle.Draw();
    }
}