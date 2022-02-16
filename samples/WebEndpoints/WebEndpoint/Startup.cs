using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Microsoft.OpenApi.Models;

namespace WebEndpoints.WebApiEndpoint
{

  public class Startup
  {
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
      
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rest API", Version = "v1" });
      });
      services.AddSwaggerGenNewtonsoftSupport();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseCors("CorsPolicy");

      app.UseSwagger();
      app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest API V1"); });

      app.UseSpaStaticFiles();

      app.UseMvc();

      app.UseSpa(spa => { });
    }
  }
}
