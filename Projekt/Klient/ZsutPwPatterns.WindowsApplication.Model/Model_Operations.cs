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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IOperations
  {
    public void LoadPatientList( )
    {
      /* AT
      this.LoadPatientsTask( );
      */
      Task.Run( ( ) => this.LoadPatientsTask( ) );
    }

    private void LoadPatientsTask( )
    {
      INetwork networkClient = NetworkClientFactory.GetNetworkClient( );

      try
      {
        Patient[ ] patients = networkClient.GetPatients( this.SearchText );

        this.PatientList = patients.ToList( );
      }
      catch( Exception )
      {
      }
    }
  }
}
