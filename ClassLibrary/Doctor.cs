namespace _2021L_PAIM_Lab.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;



    public class Doctor : Person
    {
        
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