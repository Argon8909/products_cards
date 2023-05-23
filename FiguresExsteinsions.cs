using System;
using Library.figures;
using Library.figures.@abstract;

namespace Products
{
    public static class FiguresExsteinsions
    {
        public static double GetAreaAndVolSumm(this Cube cube)
        {
            return cube.Area + cube.Volume;
        }

        public static void CalculateAndPrint<T>(this IFigure<T> figure, string message)
        {
            var h= Math.Pow(figure.Area, 2);
            Console.WriteLine($"{message}: {h}");
        }

        public static void PrintInt(this int a)
        {
            Console.WriteLine($"Целое число - {a}");
        }
        
    }
}