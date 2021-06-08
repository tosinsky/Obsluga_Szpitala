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

namespace ZsutPw.Patterns.Application.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

    public class FakeNetworkClient : INetwork
    {
        //private static readonly Patient[ ] patients = new Patient[ ] { new Patient( ) { Doctor = "Maksymilian Frapp", ExaminationRoom = "217" } , new Patient( ) { Doctor = "Andrzeja Młokos", ExaminationRoom = "213a" }, new Patient() { Doctor = "Janina Cheeto", ExaminationRoom = "202" } };

        public Patient[] GetPatients(string searchText)
        {
            //return FakeNetworkClient.patients;
            return null;
        }

        public Patient[] GetPatientsBySurname(string searchText)
        {
            //return FakeNetworkClient.patients;
            return null;
        }

    }
}
