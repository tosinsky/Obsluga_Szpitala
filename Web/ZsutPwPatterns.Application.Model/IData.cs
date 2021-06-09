﻿//===============================================================================
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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  using System.ComponentModel;

  public interface IData : INotifyPropertyChanged
  {
    string SearchText { get; set; }

    List<DoctorCabinet> DoctorList { get; }

    DoctorCabinet SelectedDoctor { get; set; }
  }
}
