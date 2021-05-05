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
    public void LoadDoctorExaminationRoomList( )
    {
      /* AT
      this.LoadDoctorExaminationRoomsTask( );
      */
      Task.Run( ( ) => this.LoadDoctorExaminationRoomsTask( ) );
    }

    private void LoadDoctorExaminationRoomsTask( )
    {
      INetwork networkClient = NetworkClientFactory.GetNetworkClient( );

      try
      {
                DoctorExaminationRoom[ ] doctorExaminationRooms = networkClient.GetDoctorExaminationRooms( this.SearchText );

        this.DoctorExaminationRoomList = doctorExaminationRooms.ToList( );
      }
      catch( Exception )
      {
      }
    }
  }
}
