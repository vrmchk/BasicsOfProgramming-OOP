using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Sharp
{
    internal class Line3D : Line
    {
        public Point3D A { get; private set; }
        public Point3D B { get; private set; }
        public Point3D VectorCoord => new Point3D(B.X - A.X, B.Y - A.Y, B.Z - A.Z);

        public Line3D()
        {
            A = new Point3D();
            B = new Point3D(1);
        }

        public Line3D(Point3D b)
        {
            A = new Point3D();
            B = b;
        }

        public Line3D(Point3D a, Point3D b) : this(b)
        {
            if (a != b) A = a;
        }

        public Line3D((int x, int y, int z) b)
        {
            A = new Point3D();
            B = new Point3D(b);
        }

        public Line3D((int x, int y, int z) a, (int x, int y, int z) b) : this(b)
        {
            if (a != b) A = new Point3D(a);
        }

        public override bool IsParallelTo(Line line)
        {
            return line is Line3D line3D &&
                   line3D.VectorCoord.X != 0 && line3D.VectorCoord.Y != 0 && line3D.VectorCoord.Z != 0 &&
                   (decimal) VectorCoord.X / line3D.VectorCoord.X == (decimal) VectorCoord.Y / line3D.VectorCoord.Y &&
                   (decimal) VectorCoord.X / line3D.VectorCoord.X == (decimal) VectorCoord.Z / line3D.VectorCoord.Z;
        }

        public override bool IsPerpendicularTo(Line line)
        {
            return line is Line3D line3D &&
                   VectorCoord.X * line3D.VectorCoord.X + VectorCoord.Y * line3D.VectorCoord.Y +
                   VectorCoord.Z * line3D.VectorCoord.Z == 0;
        }

        public override bool ContainsPoint(Point point)
        {
            if (point is not Point3D point3D) return false;
            Line3D lineWithPoint = new Line3D(A, point3D);
            return IsParallelTo(lineWithPoint);
        }

        public override string ToString() => $"A: {A}\tB: {B}";
    }
}