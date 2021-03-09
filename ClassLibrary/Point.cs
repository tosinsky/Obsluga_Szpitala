namespace _2021L_PAIM_Lab.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;



    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            (this.X, this.Y) = (x, y);
        }


    }
}