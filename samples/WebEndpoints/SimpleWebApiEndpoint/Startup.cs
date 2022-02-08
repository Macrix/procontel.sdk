using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Services;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Converters;

namespace SimpleWebApiEndpoint
{
  public class Startup
  {
    Type WebHostType = typeof(Microsoft.AspNetCore.WebHost);

    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public Startup(ILogger logger, IRuntimeContext runtimeContext, IConfigurationReader configurationReader)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
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
     
      services.AddSpaStaticFiles(options => { options.RootPath = "mobile"; });

      services.AddSignalR();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseCors("CorsPolicy");

      app.UseSpaStaticFiles();

      app.UseMvc();

      app.UseSpa(spa => { });
    }
  }
}
