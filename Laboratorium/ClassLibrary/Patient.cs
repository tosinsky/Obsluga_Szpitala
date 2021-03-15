namespace _2021L_PAIM_Lab.Laboratorium.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;



    public class Patient : Person
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Patient(string name, double width, double height) : base(name)
        {
            Debug.Assert(condition: width > 0 && height > 0);

            this.Width = width;
            this.Height = height;
        }

        public override double GetArea()
        {
            return this.Width * this.Height;
        }
    }
}