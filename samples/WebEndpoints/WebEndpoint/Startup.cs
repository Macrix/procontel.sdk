﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Microsoft.OpenApi.Models;

namespace WebEndpoints.WebApiEndpoint
{

  public class Startup
  {
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public Startup(ILogger logger, IRuntimeContext runtimeContext, IConfigurationReader configurationReader)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
    }

    public void ConfigureServices(IServiceCollection services)
    {
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
     
      services.AddSpaStaticFiles(options => { options.RootPath = "WebApp"; });

      services.AddSignalR();
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "MOBILE API", Version = "v1" });
      });
      services.AddSwaggerGenNewtonsoftSupport();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseCors("CorsPolicy");

      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MOBILE API V1"); });

      app.UseSpaStaticFiles();

      app.UseMvc();

      app.UseSpa(spa => { });
    }
  }
}
