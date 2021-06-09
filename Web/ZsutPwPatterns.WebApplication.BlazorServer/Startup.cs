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

  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Components;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.HttpsPolicy;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.Extensions.Hosting;

  using ZsutPw.Patterns.Application.Controller;
  using ZsutPw.Patterns.Application.Model;
  using ZsutPw.Patterns.Application.Utilities;

  public class Startup
  {
    public Startup( IConfiguration configuration )
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices( IServiceCollection services )
    {
      services.AddRazorPages( );
      services.AddServerSideBlazor( );

      services.AddScoped<IEventDispatcher, EventDispatcher>( );
      services.AddScoped<IModel, Model>( );
      services.AddScoped<IController, Controller>( );
    }

    public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
    {
      if( env.IsDevelopment( ) )
      {
        app.UseDeveloperExceptionPage( );
      }
      else
      {
        app.UseExceptionHandler( "/Error" );
        app.UseHsts( );
      }
      /* AT
      app.UseHttpsRedirection( );
      */
      app.UseStaticFiles( );

      app.UseRouting( );

      app.UseEndpoints( endpoints =>
      {
        endpoints.MapBlazorHub( );
        endpoints.MapFallbackToPage( "/_Host" );
      } );
    }
  }
}
