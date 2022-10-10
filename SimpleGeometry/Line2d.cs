using System;

namespace SimpleGeometry
{
    class Line2d : BaseGeometry
    {
        public Point2d start;
        public Point2d end;


        public Line2d()
        {

        }
        public Line2d(Point2d start, Point2d end)
        {
            this.start = start;
            this.end = end;
        }

        public double Length()
        {
            double length = Math.Sqrt((Math.Pow(start.X - end.X, 2) + Math.Pow(start.Y - end.Y, 2)));

            return length;
        }

        public double Azimuth()
        {
            double azimuth = Math.Atan((end.X - start.X) / (end.Y - start.Y));
            return azimuth*200/Math.PI;
        }
    }
}
