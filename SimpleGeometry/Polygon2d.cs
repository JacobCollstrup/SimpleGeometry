using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleGeometry
{
    class Polygon2d : BaseGeometry
    {
        //Made setter private, we don't want external code updating our lines or vertices
        //Since we can't ensure it is a valid polygon if they do.
        public List<Line2d> LineSegments { get; private set; } = new List<Line2d>();
        public List<Point2d> Vertices { get; private set; } = new List<Point2d>();
        private int numLines;
        private int numPoints;

        public Polygon2d(List<Line2d> Lines)
        {
            //Added null-check so we don't get a null pointer exception if constructor is called with lines=null
            //Lines?.Count < 3 is shorthand for lines != null && lines.Count < 3
            if (Lines?.Count < 3)
            {
                //Updated to use more specific exception type
                throw new ArgumentException("Please supply 3 or more lines for generating polygon.");
            }

            LineSegments = Lines;
            foreach (var line in Lines) // Filling Vertices list, for use with calculating area            
            {
                //Won't we get a lot of duplicates since line[0].end == line[1].start, line[1].end == line[2].start, ...?
                Vertices.Add(line.start);
                Vertices.Add(line.end);
            }
            numLines = Lines.Count;
        }

        public Polygon2d(List<Point2d> Points)
        {
            //Same changes as in other constructor
            if (Points?.Count < 3)
            {
                throw new ArgumentException("Please supply 3 or more points for generating polygon.");
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
            }
            //Moved assignment out of loop
            numPoints = Vertices.Count;
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

            //Du brugte en while-løkke i din punktbaserede constructor, men her bruger du en for.
            //Begge dele er fint, men det er generelt en god ide at være stilmæssigt konsekvent.
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
