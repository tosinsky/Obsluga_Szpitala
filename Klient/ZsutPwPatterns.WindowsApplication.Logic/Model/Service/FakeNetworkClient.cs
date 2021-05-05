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

  public class FakeNetworkClient : INetwork
  {
    private static readonly DoctorExaminationRoom[ ] doctorExaminationRooms = new DoctorExaminationRoom[ ] { new DoctorExaminationRoom( ) { Doctor = "Maksymilian Frapp", ExaminationRoom = "217" } , new DoctorExaminationRoom( ) { Doctor = "Andrzeja Młokos", ExaminationRoom = "213a" }, new DoctorExaminationRoom() { Doctor = "Janina Cheeto", ExaminationRoom = "202" } };

    public DoctorExaminationRoom[ ] GetDoctorExaminationRooms( string searchText )
    {
      return FakeNetworkClient.doctorExaminationRooms;
    }
  }
}
