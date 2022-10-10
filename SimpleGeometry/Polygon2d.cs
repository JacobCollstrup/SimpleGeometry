using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleGeometry
{
    class Polygon2d : BaseGeometry
    {
        public List<Line2d> LineSegments = new List<Line2d>();
        public List<Point2d> Vertices = new List<Point2d>();
        private int numLines;
        private int numPoints;

        public Polygon2d(List<Line2d> Lines)
        {
            if (Lines.Count < 3)
            {
                throw new Exception("Please supply 3 or more lines for generating polygon.");
            }
            LineSegments = Lines;
            foreach (var line in Lines) // Filling Vertices list, for use with calculating area
            {
                Vertices.Add(line.start);
                Vertices.Add(line.end);
            }
            numLines = Lines.Count;
        }

        public Polygon2d(List<Point2d> Points)
        {
            if (Points.Count < 3)
            {

                throw new Exception("Please supply 3 or more points for generating polygon.");
            }
            Vertices = Points;
            int i = 1;
            while (i < Points.Count) // Filling LineSegment list, for use with calculating circumference
            {
                if (i == Points.Count -1)
                {
                    var lastLine = new Line2d(Points[i], Points[0]);
                    LineSegments.Add(lastLine);
                }
                var line = new Line2d(Points[i - 1], Points[i]);
                LineSegments.Add(line);
                i++;
                numPoints = Vertices.Count;
            }
        }

        public double Circumference()
        {
            double circumference = 0;
            foreach (var Line in LineSegments)
            {
                circumference += Line.Length();
            }
            return circumference;
        }

        public double Area() // Using method from https://www.mathsisfun.com/geometry/area-irregular-polygons.html
        {
            // Adding the first point to the end, thus "closing the polygon".
            List<Point2d> localVertices = Vertices;
            localVertices.Add(Vertices[0]);
            
            Console.WriteLine(numPoints);

            double area = 0;
            for (int i = 0; i < numPoints; i++)
            {
                area +=
                    (localVertices[i + 1].X - localVertices[i].X) *
                    (localVertices[i + 1].Y + localVertices[i].Y) / 2;
            }
            return area;
        }

    }
}
