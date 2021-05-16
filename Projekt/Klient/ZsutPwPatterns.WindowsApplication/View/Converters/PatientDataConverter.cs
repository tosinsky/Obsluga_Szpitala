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

namespace ZsutPw.Patterns.WindowsApplication.View
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Windows.UI.Xaml.Data;

  using ZsutPw.Patterns.WindowsApplication.Model;

  public class PatientConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      Patient patient = (Patient)value;

      return String.Format( "{0} {1}, {2}, {3}, {4}, {5}", patient.Name, patient.Surname, patient.PESEL, patient.Birthdate.ToString("dd/MM/yyyy"), patient.PhoneNumber, patient.Appointments );
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      throw new NotImplementedException( );
    }
  }
}
