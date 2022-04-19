using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Sharp
{
    internal static class LineWorker
    {
        public static Line? PerpendicularToAll(Line[] lines)
        {
            for (int indToCheck = 0; indToCheck < lines.Length; indToCheck++)
            {
                Line perpLine = lines[indToCheck];
                bool perpendicular =
                    lines.Where((l, j) => indToCheck != j).All(l => lines[indToCheck].IsPerpendicularTo(l));
                if (perpendicular) return perpLine;
            }

            return null;
        }

        public static void PrintLineArray(Line[] lines, string prePrint = "")
        {
            Console.WriteLine(prePrint);
            Array.ForEach(lines, Console.WriteLine);
            Console.WriteLine();
        }

        public static Line2D GetRandomLine2D(int randMin = -5, int randMax = 6)
        {
            Random random = new Random();
            var a = (random.Next(randMin, randMax), random.Next(randMin, randMax));
            var b = (random.Next(randMin, randMax), random.Next(randMin, randMax));
            return new Line2D(a, b);
        }

        public static Line3D GetRandomLine3D(int randMin = -5, int randMax = 6)
        {
            Random random = new Random();
            var a = (random.Next(randMin, randMax), random.Next(randMin, randMax), random.Next(randMin, randMax));
            var b = (random.Next(randMin, randMax), random.Next(randMin, randMax), random.Next(randMin, randMax));
            return new Line3D(a, b);
        }

        public static Line2D[] GetRandomLine2DArray(int size)
        {
            var lines = new Line2D[size];
            for (int i = 0; i < size; i++)
            {
                lines[i] = GetRandomLine2D();
            }

            return lines;
        }

        public static Line3D[] GetRandomLine3DArray(int size)
        {
            var lines = new Line3D[size];
            for (int i = 0; i < size; i++)
            {
                lines[i] = GetRandomLine3D();
            }

            return lines;
        }
    }
}