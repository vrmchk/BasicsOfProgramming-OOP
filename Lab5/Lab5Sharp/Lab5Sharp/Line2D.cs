using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Sharp
{
    internal class Line2D : Line
    {
        public Point2D A { get; private set; }
        public Point2D B { get; private set; }
        public Point2D VectorCoord => new Point2D(B.X - A.X, B.Y - A.Y);

        public Line2D()
        {
            A = new Point2D();
            B = new Point2D(1);
        }

        public Line2D(Point2D b)
        {
            A = new Point2D();
            B = b;
        }

        public Line2D(Point2D a, Point2D b) : this(b)
        {
            if (a != b) A = a;
        }

        public Line2D((int x, int y) b)
        {
            A = new Point2D();
            B = new Point2D(b);
        }

        public Line2D((int x, int y) a, (int x, int y) b) : this(b)
        {
            if(a != b) A = new Point2D(a);
        }

        public override bool IsParallelTo(Line line)
        {
            return line is Line2D line2D && line2D.VectorCoord.X != 0 && line2D.VectorCoord.Y != 0 &&
                   (decimal) VectorCoord.X / line2D.VectorCoord.X == (decimal) VectorCoord.Y / line2D.VectorCoord.Y;
        }

        public override bool IsPerpendicularTo(Line line)
        {
            return line is Line2D line2D &&
                   VectorCoord.X * line2D.VectorCoord.X + VectorCoord.Y * line2D.VectorCoord.Y == 0;
        }

        public override bool ContainsPoint(Point point)
        {
            if (point is not Point2D point2D) return false;
            Line2D lineWithPoint = new Line2D(A, point2D);
            return IsParallelTo(lineWithPoint);
        }

        public override string ToString() => $"A: {A}\tB: {B}";
    }
}