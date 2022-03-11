using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab3Sharp
{
    internal class CircleWorker
    {
        public void Start()
        {
            var arrayOfCircles = ArrayOfCircles(size: 10, random: true);
            Circle maxCircle = GetMaxCircle(arrayOfCircles);
            PrintCircles(arrayOfCircles, "Circles:");
            Console.WriteLine("The biggest circle:");
            maxCircle.PrintCircle();
            Console.ReadLine();
        }

        private Circle[] ArrayOfCircles(int size, bool random = true)
        {
            return random ? RandomArrayOfCircles(size) : ConsoleArrayOfCircles(size);
        }

        private Circle[] RandomArrayOfCircles(int size)
        {
            Random random = new Random();
            var circles = new Circle[size];

            for (int i = 0; i < size; i++)
            {
                circles[i] = new Circle(centerCoordinates: (random.Next(-100, 101), random.Next(-100, 101)),
                    radius: random.Next(1, 101));
            }

            return circles;
        }

        private Circle[] ConsoleArrayOfCircles(int size)
        {
            var circles = new Circle[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write("Enter center X coordinate: ");
                int centerX = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter center Y coordinate: ");
                int centerY = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter a radius: ");
                int radius = Convert.ToInt32(Console.ReadLine());
                circles[i] = new Circle(centerX, centerY, radius);
                Console.WriteLine();
            }

            return circles;
        }

        private void PrintCircles(Circle[] circles, string prePrint = "")
        {
            Console.WriteLine(prePrint);

            foreach (Circle circle in circles)
            {
                circle.PrintCircle();
            }

            Console.WriteLine();
        }

        private Circle GetMaxCircle(Circle[] circles)
        {
            Circle maxCircle = circles.First();
            foreach (Circle circle in circles)
            {
                if (maxCircle.Radius < circle.Radius) maxCircle = circle;
            }

            return maxCircle;
        }
    }
}