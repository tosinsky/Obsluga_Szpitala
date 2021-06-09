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

        this.RaisePropertyChanged( "SearchText" );
      }
    }
    private string searchText;

    public List<DoctorCabinet> DoctorList
    {
      get { return this.nodeList; }
      private set
      {
        this.nodeList = value;

        this.RaisePropertyChanged( "NodeList" );
      }
    }
    private List<DoctorCabinet> nodeList = new List<DoctorCabinet>( );

    public DoctorCabinet SelectedDoctor
    {
      get { return this.selectedNode; }
      set
      {
        this.selectedNode = value;

        this.RaisePropertyChanged( "SelectedNode" );
      }
    }
    private DoctorCabinet selectedNode;
  }
}
