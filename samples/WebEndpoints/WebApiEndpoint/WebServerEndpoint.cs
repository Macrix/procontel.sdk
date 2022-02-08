﻿using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https.Internal;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using ProconTel.Sdk.Attributes;
using ProconTel.Sdk.Avatars;
using ProconTel.Sdk.Builders;
using ProconTel.Sdk.Messages;
using ProconTel.Sdk.Providers;
using ProconTel.Sdk.Services;
using ProconTel.Sdk.UI.Attributes;
using ProconTel.Sdk.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebEndpoints.WebApiEndpoint.Common;

namespace WebEndpoints.WebApiEndpoint
{
  [ConfigurationDialog("WebHostEndpoint", "WebHostConfigurationDialog")]
  //[StatusControl("RWE.Nuclear.Dialogs.WebHostEndpoint", "WebHostStatusControl", EndpointStatusControlType.WinForms, true, true)]
  [EndpointMetadata(Name = "[Test] WebServer", SupportedRoles = SupportedRoles.Both)]
  [SimpleCustomProtocol]
  //[MessageMetadataProvider(typeof(WebServerEndpoint))]
  public class WebServerEndpoint : WebHostEndpoint<Startup>, /*IMessageMetadataProvider,*/ IHandler
  {
    //public IEnumerable<MessageDetails> MessagesMetadata => new[] {
    //    new MessageDetails(nameof(RegisterOrderCommand), "Command - register order"),
    //    new MessageDetails(nameof(StartOrderCommand), "Command - start  order"),
    //    new MessageDetails(nameof(CancelOrderCommand), "Command - cancel  order")
    //};


    private readonly WebHostConfiguration _configuration;
    private readonly IConfigurationReader _configurationReader;
    private readonly IMessageBus _messageBus;

    public WebServerEndpoint(Func<ILogger> logger, Func<IRuntimeContext> runtimeContext,
      IConfigurationReader configurationReader, IMessageBus messageBus)
      : base(logger, runtimeContext)
    {
      _configurationReader = configurationReader;
      _messageBus = messageBus;

      _configuration = _configurationReader.ReadAndJsonDeserialize<WebHostConfiguration>(
        (ex) => Logger.Error("Configuration deserialization failed.", ex));

      Urls = (_configuration.Urls.Any()) ? _configuration.Urls.ToArray() : null;
    }

    protected override void ConfigureServices(IServiceCollection ioc)
    {
      base.ConfigureServices(ioc);
      ioc.AddTransient(ctx => _configurationReader);
      ioc.AddTransient(ctx => _messageBus);
    }
    protected override void SetKestrelOptions(KestrelServerOptions options)
    {
      if (_configuration.UseHttps)
      {
        X509Certificate2 cert = null;
        try
        {
          if (_configuration.SSLFromFile)
          {
            //todo
          }
          else
          {
            cert = CertificateLoader.LoadFromStoreCert(
                      _configuration.SSLSubject, _configuration.SSLStoreName,
                      StoreLocation.LocalMachine,
                      allowInvalid: true);
          }
        }
        catch (Exception ex)
        {
          Logger.Error("Read SSL certificate failed.", ex);
        }

        if (cert != null)
        {
          options.ConfigureHttpsDefaults(listenOptions =>
          {
            // certificate is an X509Certificate2
            listenOptions.ServerCertificate = cert;
          });
        }
        else
        {
          Logger.Information("HTTPS will be not used.");
        }
      }
    }

    public bool CanHandle(string messageId, ICorrelationContext context = null)
    {
      return true;
    }

    public async Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      Logger.Debug($"Handling {messageId} {message}");
      return new Ack();
    }
  }
}

