using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Services;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Newtonsoft.Json.Converters;
using WebEndpoints.WebApiEndpoint.Common;
using System.Text.RegularExpressions;
using WebEndpoints.WebApiEndpoint.Middlewares;
using Microsoft.OpenApi.Models;
using WebEndpoints.WebApiEndpoint.Hubs;

namespace WebEndpoints.WebApiEndpoint
{

  public class Startup
  {
    Type WebHostType = typeof(Microsoft.AspNetCore.WebHost);

    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    private readonly WebHostConfiguration _configuration;
    public Startup(ILogger logger, IRuntimeContext runtimeContext, IConfigurationReader configurationReader)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
      _configuration = configurationReader.ReadAndJsonDeserialize<WebHostConfiguration>();
    }

    private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
      // Get just the name of assmebly
      // Aseembly name excluding version and other metadata
      string name = new Regex(",.*").Replace(args.Name, string.Empty);
      if (name.ToLower().Contains("newtonsoft")
        || name.ToLower().Contains("system.componentmodel.annotations"))
      {
        // Load whatever version available
        return Assembly.Load(name);
      }
      return null;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      //workaround for loading dll with wrong version
      AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

      services.AddMvcCore()
        .AddJsonOptions(options =>
          options.SerializerSettings.Converters.Add(new StringEnumConverter()))
        .AddJsonFormatters()
        .AddDataAnnotations()
        .AddApiExplorer()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_0);

      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", cors =>
          cors
          .AllowAnyHeader()
              .AllowAnyMethod()
              .SetIsOriginAllowed((host) => true)
              .AllowCredentials());
      });
     
      services.AddSpaStaticFiles(options => { options.RootPath = "wwwroot"; });

      services.AddSignalR();
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MOBILE API", Version = "v1" });
      });
      services.AddSwaggerGenNewtonsoftSupport();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseMiddleware<RequestLoggingMiddleware>();

      app.UseMiddleware<ErrorHandlingMiddleware>();

      app.UseCors("CorsPolicy");

      if (_configuration.ForceHttps)
      {
        app.UseHttpsRedirection();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MOBILE API V1"); });

      app.UseSpaStaticFiles();

      app.UseMvc();

      app.UseSignalR(c =>
      {
        c.MapHub<OrderHub>("/ordersHub");
      });

      app.UseSpa(spa => { });
    }
  }
}
