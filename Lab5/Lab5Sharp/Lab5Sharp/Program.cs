using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Sharp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Point2D point = new Point2D(new Random().Next(-5, 6), new Random().Next(-5, 6));
            Line[] line2Ds = LineWorker.GetRandomLine2DArray(100);
            var perpendicularToFirst = line2Ds.Where(l => l.IsPerpendicularTo(line2Ds.First())).ToArray();
            var linesWithPoint = perpendicularToFirst.Where(l => l.ContainsPoint(point)).ToArray();

            Line[] randomLine3Ds = LineWorker.GetRandomLine3DArray(3);
            Line[] line3Ds = {new Line3D((1, 2, 3), (2, 3, 4)), new Line3D((1, 1, -2)), new Line3D((2, 2, -4))};

            LineWorker.PrintLineArray(line2Ds, "2D Lines");
            LineWorker.PrintLineArray(perpendicularToFirst, "Lines, perpendicular to first");
            LineWorker.PrintLineArray(linesWithPoint, $"Lines, perpendicular to first with point: {point}");
            LineWorker.PrintLineArray(randomLine3Ds, "Random 3D Lines");
            Console.WriteLine($"Random 3D Line Perpendicular to all:\n{LineWorker.PerpendicularToAll(randomLine3Ds)}");
            LineWorker.PrintLineArray(line3Ds, "3D Lines");
            Console.WriteLine($"3D Line Perpendicular to all:\n{LineWorker.PerpendicularToAll(line3Ds)}");
            Console.ReadLine();
        }
    }
}