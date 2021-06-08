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

    public partial class Model : IOperations
    {
        public void LoadPatientList()
        {
            /* AT
            this.LoadPatientsTask( );
            */
            Task.Run(() => this.LoadPatientsTask());

        }
        public void LoadPatientBySurnameList()
        {
            /* AT
            this.LoadPatientsTask( );
            */
            Task.Run(() => this.LoadPatientsBySurnameTask());

        }


        private void LoadPatientsTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                Patient[] patients = networkClient.GetPatients(this.SearchText);

                this.PatientList = patients.ToList();
            }

            catch (Exception)
            {
            }
        }
        private void LoadPatientsBySurnameTask()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();

            try
            {
                Patient[] patients = networkClient.GetPatientsBySurname(this.SearchText);

                this.PatientList = patients.ToList();
            }

            catch (Exception)
            {
            }
        }


    }
}

