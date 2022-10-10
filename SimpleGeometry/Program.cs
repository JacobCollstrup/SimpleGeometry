using System;
using System.Collections.Generic;

namespace SimpleGeometry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Point2d p1 = new Point2d();
            p1.X = 100.00;
            p1.Y = 100.00;

            Point2d p2 = new Point2d(200.00, 100.00);

            Console.WriteLine(String.Format("The coordinates of the point p1 is {0}, {1}.", p1.X, p1.Y));
            Console.WriteLine(String.Format("The coordinates of the point p2 is {0}, {1}.", p2.X, p2.Y));

            Line2d line1 = new Line2d();
            line1.start = p1;
            line1.end = p2;

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

            var listOfPoints = new List<Point2d>();
            listOfPoints.Add(pOne);
            listOfPoints.Add(pTwo);
            listOfPoints.Add(pThree);
            listOfPoints.Add(pFour);
            listOfPoints.Add(pFive);
            listOfPoints.Add(pSix);
   
            var polygon = new Polygon2d(listOfPoints);
            var area = polygon.Area();
            var circ = polygon.Circumference();
            Console.WriteLine(String.Format("The area of the polygon is: {0}", area));
            Console.WriteLine(String.Format("The circumference of the polygon is: {0}", circ));
        }
    }
}
