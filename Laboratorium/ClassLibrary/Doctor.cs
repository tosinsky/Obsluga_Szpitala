namespace _2021L_PAIM_Lab.Laboratorium.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;



    public class Doctor : Person
    {
        public int Specialization[] = new int { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
        public double Size { get; private set; }

        public Doctor(string name, double size) : base(name)
        {
            Debug.Assert(condition: size > 0);

            this.Size = size;
        }

        public override double GetArea()
        {
            return this.Size * this.Size;
        }
        
    }
}