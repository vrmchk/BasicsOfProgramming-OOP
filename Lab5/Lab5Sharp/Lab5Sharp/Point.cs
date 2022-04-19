using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab5Sharp
{
    internal abstract class Point { }

    internal class Point2D : Point
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }

        public Point2D(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public Point2D((int x, int y) coordinates)
        {
            X = coordinates.x;
            Y = coordinates.y;
        }

        public override string ToString() => $"({X}, {Y})";


        public static bool operator ==(Point2D point1, Point2D point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        public static bool operator !=(Point2D point1, Point2D point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y;
        }
        
    }

    internal class Point3D : Point2D
    {
        public int Z { get; protected set; }

        public Point3D(int x = 0, int y = 0, int z = 0) : base(x, y)
        {
            Z = z;
        }

        public Point3D((int x, int y, int z) coordinates)
        {
            X = coordinates.x;
            Y = coordinates.y;
            Z = coordinates.z;
        }

        public override string ToString() => $"({X}, {Y}, {Z})";
        
        
        public static bool operator ==(Point3D point1, Point3D point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y && point1.Z == point2.Z;
        }

        public static bool operator !=(Point3D point1, Point3D point2)
        {
            return point1.X != point2.X || point1.Y != point2.Y || point1.Z != point2.Z;
        }
    }
}