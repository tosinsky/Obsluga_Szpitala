namespace Patients.Web
{
    using Patients.Domain;
    using Patients.Domain.PatientAggregate;
    using Patients.Infrastructure;
    using Patients.Web.Application;
    using Patients.Web.Application.Commands;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.OpenApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Patients.Web", Version = "v1" });
            });

            //Miejsce, w kt�rym okre�lamy co ma si� kry� za poszczeg�lnymi interfejsami.
            //Poni�sze trzy linijki sprawi�, �e kiedy zdefiniujemy kontruktor przyjmuj�cy jako parametr jeden z poni�szych interfejs�w
            //framework automatycznie "wstzyknie" do niego wskazan� przez nas implementacj�
            services.AddSingleton<IPatientsRepository, PatientsRepository>();
            services.AddTransient<IPatientQueriesHandler, PatientQueriesHandler>();
            services.AddTransient<ICommandHandler<AddPatientCommand>, PatientsCommandsHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laboratories.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
