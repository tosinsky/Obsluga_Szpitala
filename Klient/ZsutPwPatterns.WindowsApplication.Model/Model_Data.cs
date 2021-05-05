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

  public partial class Model : IData
  {
    public string SearchText
    {
      get { return this.searchText; }
      set
      {
        this.searchText = value;

        this.RaisePropertyChanged( "SearchText" );
      }
    }
    private string searchText;

    public List<DoctorExaminationRoom> DoctorExaminationRoomList
    {
      get { return this.doctorExaminationRoomList; }
      private set
      {
        this.doctorExaminationRoomList = value;

        this.RaisePropertyChanged( "DoctorExaminationRoomList" );
      }
    }
    private List<DoctorExaminationRoom> doctorExaminationRoomList = new List<DoctorExaminationRoom>( );

    public DoctorExaminationRoom SelectedDoctorExaminationRoom
    {
      get { return this.selectedDoctorExaminationRoom; }
      set
      {
        this.selectedDoctorExaminationRoom = value;

        this.RaisePropertyChanged( "SelectedDoctorExaminationRoom" );
      }
    }
    private DoctorExaminationRoom selectedDoctorExaminationRoom;
  }
}
