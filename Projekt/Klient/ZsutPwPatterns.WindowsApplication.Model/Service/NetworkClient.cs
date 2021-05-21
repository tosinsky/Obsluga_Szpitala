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

    using System.Net.Http;

    public class NetworkClient : INetwork
    {
        private readonly ServiceClient serviceClient;

        public NetworkClient(string serviceHost, int servicePort)
        {
            Debug.Assert(condition: !String.IsNullOrEmpty(serviceHost) && servicePort > 0);

            this.serviceClient = new ServiceClient(serviceHost, servicePort);
        }

        public Patient[] GetPatients(string searchText)
        {
            string callUri = String.Format("patients", searchText);

            Patient[] patients = this.serviceClient.CallWebService<Patient[]>(HttpMethod.Get, callUri);

            return patients;
        }
        public Patient[] GetPatientsBySurname(string searchText)
        {
            string callUri = String.Format("patient-by-surname?surname={0}", searchText);

            Patient[] patients = this.serviceClient.CallWebService<Patient[]>(HttpMethod.Get, callUri);

            return patients;
        }

    }
}
