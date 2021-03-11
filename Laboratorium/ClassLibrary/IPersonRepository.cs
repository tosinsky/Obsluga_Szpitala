namespace _2021L_PAIM_Lab.ClassLibrary
{
    using System;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;




    public interface IPersonRepository
    {
        Person[] Find(PersonSex sex);
    }
}