//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright � 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WebApplication.BlazorServer
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.Hosting;
  using Microsoft.Extensions.Logging;

  public class Program
  {
    public static void Main( string[ ] args )
    {
      CreateHostBuilder( args ).Build( ).Run( );
    }

    public static IHostBuilder CreateHostBuilder( string[ ] args ) =>
      Host.CreateDefaultBuilder( args ).ConfigureWebHostDefaults( webBuilder => { webBuilder.UseStartup<Startup>( ); } );
  }
}
