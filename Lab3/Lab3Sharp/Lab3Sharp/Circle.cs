using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3Sharp
{
    internal class Circle
    {
        private int _radius;

        public (int, int) CenterCoordinates { get; set; }
        public double Circuit { get; private set; }
        public double Square { get; private set; }

        public int Radius
        {
            get => _radius;
            set
            {
                if (value > 0)
                {
                    _radius = value;
                    SetCircuitAndSquare();
                }
            }
        }

        public Circle(int centerX = 0, int centerY = 0, int radius = 1)
        {
            CenterCoordinates = (centerX, centerY);
            Radius = radius;
            SetCircuitAndSquare();
        }

        public Circle((int, int) centerCoordinates, int radius)
        {
            CenterCoordinates = centerCoordinates;
            Radius = radius;
            SetCircuitAndSquare();
        }

        public void PrintCircle()
        {
            int printCellSize = 25;
            string[] circleProperties =
            {
                $"Center: {CenterCoordinates}", $"Radius: {_radius}",
                $"Circuit: {Math.Round(Circuit, 2)}", $"Square: {Math.Round(Square, 2)}"
            };

            foreach (string property in circleProperties)
            {
                Console.Write(property + new string(' ', printCellSize - property.Length));
            }

            Console.WriteLine();
        }

        private double SetCircuit() => 2 * Math.PI * _radius;

        private double SetSquare() => Math.PI * Math.Pow(_radius, 2);

        private void SetCircuitAndSquare()
        {
            Circuit = SetCircuit();
            Square = SetSquare();
        }
    }
}