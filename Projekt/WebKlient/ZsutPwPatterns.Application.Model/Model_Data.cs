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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

    public partial class Model : IData
    {
        public string SearchText
        {
            get { return this.searchText; }
            set
            {
                this.searchText = value;

                this.RaisePropertyChanged("SearchText");
            }
        }
        private string searchText;

        public List<Patient> PatientList
        {
            get { return this.patientList; }
            private set
            {
                this.patientList = value;

                this.RaisePropertyChanged("PatientList");
            }
        }
        private List<Patient> patientList = new List<Patient>();

        public Patient SelectedPatient
        {
            get { return this.selectedPatient; }
            set
            {
                this.selectedPatient = value;

                this.RaisePropertyChanged("SelectedPatient");
            }
        }
        private Patient selectedPatient;
    }
}
