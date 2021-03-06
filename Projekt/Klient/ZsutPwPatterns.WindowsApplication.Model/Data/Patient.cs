//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WindowsApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class Patient
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long PESEL { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public List<string> Appointments { get; set; }
    }
}
