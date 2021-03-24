namespace _2021L_PAIM_Lab.Laboratorium.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;

    

    public class Doctor : Person
    {
         // https://www.prawo.pl/akty/dz-u-2019-602,18834210.html specjalizacje
        public int[] Specialization = new int[] { 0731, 0701, 0732, 0733, 0734, 0702, 0735, 0736, 0703, 0737, 0738, 0704, 0739, 0792, 0705, 0706, 0707, 0740, 0708, 0741, 0799, 0796, 0710, 0742, 0743, 0797, 0709, 0744, 0787, 0745, 0788, 0746, 0807, 0747, 0748, 0762, 0793, 0794, 0749, 0750, 0711, 0712, 0713, 0714, 0751, 0716, 0752, 0798, 0753, 0717, 0718, 0763, 0789, 0719, 0755, 0754, 0720, 0721, 0790, 0722, 0723, 0795, 0800, 0724, 0725, 0756, 0726, 0727, 0728, 0757, 0758, 0759, 0760, 0761, 0729, 0791, 0730 };


        public Doctor(string name, int[] specialization) : base(name)
        {
            Debug.Assert(Specialization.Any(x => specialization.Contains(x)));
            this.Specialization = specialization;
            

            //Debug.Assert(condition: Specialization.Contains(specialization));

            //this.Specialization = specialization;
        }
        
    }
}