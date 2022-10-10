using System;

namespace SimpleGeometry
{
    class Line2d : BaseGeometry
    {
        public Point2d start;
        public Point2d end;

        //Det er en dårlig ide at have en tom constructor her.
        //En constructor skal helst sørge for at initialisere objektet
        //så det er i en gyldig tilstand.
        //Hvis man bruger den tomme constructor og direkte derefter
        //kalder Length() eller Azimuth vil du få en null-pointer.
        
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
            //Renamed local variable since it's only part of the azimuth calculation
            double atan = Math.Atan((end.X - start.X) / (end.Y - start.Y));
            return atan*200/Math.PI; //Shouldn't it be 180 rather than 200?
        }
    }
}
