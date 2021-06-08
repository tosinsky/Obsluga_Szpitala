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

  using ZsutPw.Patterns.Application.Model;

    public class PatientConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Patient patient = (Patient)value;

            var res = "[" + string.Join(", ", patient.Appointments.Select(s => $"'{s}'")) + "]";
            return String.Format("{0} {1},\n PESEL: {2},\n numer telefonu: {3},\n data urodzenia: {4},\n historia wizyt: {5}", patient.Name, patient.Surname, patient.PESEL, patient.PhoneNumber, patient.Birthdate.ToString("dd/MM/yyyy"), res);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
