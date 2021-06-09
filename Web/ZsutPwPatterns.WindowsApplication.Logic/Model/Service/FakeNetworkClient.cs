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
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  public class FakeNetworkClient : INetwork
  {
        private static readonly DoctorCabinet[] nodes = new DoctorCabinet[] { new DoctorCabinet() { Name = "Kamil Haust", Cabinet = "322B" }, new DoctorCabinet() { Name = "Tomasz Pryk", Cabinet = "B200a" }, new DoctorCabinet() { Name = "Marek Watroba", Cabinet = "217b" }, new DoctorCabinet() { Name = "Ewa Mil", Cabinet = "113D" } };


        public DoctorCabinet[] GetDoctorCabinet(string searchText)
        {
            return FakeNetworkClient.nodes.Where(dc => dc.Name.IndexOf(searchText) >= 0).ToArray();
        }
    }
}
