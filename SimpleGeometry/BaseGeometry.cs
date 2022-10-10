using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGeometry
{
    class BaseGeometry
    {
        //Der er delte meninger om at bruge _ som prefix, men når det bruges
        //er det typisk for at indikere private variable, hvilket disse ikke er.
        //Typen af Id er ændret til long, for det er træls hvis id overflower om 10 år.
        //Man kunne også overveje at bruge string, da vi antageligvis ikke skal lave matematik på id'erne.
        public long Id { get; set; }    
        public string Category { get; set; }
        public double SurveyCode { get; set; }
    }
}
