using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGeometry
{
    class Point2d : BaseGeometry
    {
        public double X;
        public double Y;

        //Se kommentar i line2d ang. tom constructor

        public Point2d(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
