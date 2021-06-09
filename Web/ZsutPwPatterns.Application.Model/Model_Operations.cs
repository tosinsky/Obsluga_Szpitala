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
    public void LoadDoctorCabinetList( )
    {
      this.LoadDoctorCabinetTask( );
      /* AT
      Task.Run( ( ) => this.LoadNodesTask( ) );
      */
    }

    private void LoadDoctorCabinetTask( )
    {
      INetwork networkClient = NetworkClientFactory.GetNetworkClient( );

      try
      {
        DoctorCabinet[ ] dcs = networkClient.GetDoctorCabinet( this.SearchText );

        this.DoctorList = dcs.ToList( );
      }
      catch( Exception e )
      {
        Console.WriteLine( e.Message );
      }
    }
  }
}
