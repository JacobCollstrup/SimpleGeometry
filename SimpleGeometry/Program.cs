using System;
using System.Collections.Generic;

namespace SimpleGeometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Had to change this since I removed the empty constructor
            //100f is shorthand for 100float and is equivalent to 100.00
            Point2d p1 = new Point2d(100f, 100f);          
            Point2d p2 = new Point2d(200.00, 100.00);

            //Changed to use string interpolation rather than format
            //since it is much more readable IMO
            Console.WriteLine($"The coordinates of the point p1 is {p1.X}, {p1.Y}.");
            Console.WriteLine($"The coordinates of the point p2 is {p2.X}, {p2.Y}.");

            Line2d line1 = new Line2d(p1, p2);            

            double lengthLine1 = line1.Length();
            double azimuthLine1 = line1.Azimuth();

            Console.WriteLine("Length of line1 is: " + lengthLine1);
            Console.WriteLine("Azimuth of line1 is: " + azimuthLine1);

            var pOne = new Point2d(0.72, 2.28);
            var pTwo = new Point2d(2.66, 4.71);
            var pThree = new Point2d(5.00, 3.5);
            var pFour = new Point2d(3.63, 2.52);
            var pFive = new Point2d(4.00, 1.60);
            var pSix = new Point2d(1.90, 1.00);

            //Simplified list initialization
            var listOfPoints = new List<Point2d>
            {
                pOne,
                pTwo,
                pThree,
                pFour,
                pFive,
                pSix
            };

            var polygon = new Polygon2d(listOfPoints);
            var area = polygon.Area();
            var circ = polygon.Circumference();

            //Converted to interpolation
            Console.WriteLine($"The area of the polygon is: {area}");
            Console.WriteLine($"The circumference of the polygon is: {circ}");
        }
    }
}
