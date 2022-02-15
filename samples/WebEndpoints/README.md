---
Title: "ProconTEL WEB Endpoint Examples"
github_url: "https://github.com/Macrix/procontel.sdk/Samples/WebEndpoint/edit/main/README.md"
Weight: 8
Description: >
  Use the ProconTEL endpoint to host and manage your WEB application
---

## Table of Contents

1. [Quick introduction](#quick-introduction)
2. [Web endpoint settings](#endpoint-settings)
3. [MVC Controller & dependency injection](#mvc-controller-dependency-injection)
4. [Hosting static files](#hosting-static-files)
5. [Broadcasting messages using http request](#broadcasting-messages)
 
 <div id='quick-introduction'/>
## 1. Quick introduction

Using ProconTEL, you can create an application that will provide communication between endpoints using HTTP request (Rest API). You can also use ProconTEL endpoint to host static files. The instruction describes how to solve the main issues with setup and hosting.
The presented code snippets are from an example that can be downloaded from the location: 
[`sample\WebEndpoints`](https://github.com/Macrix/procontel.sdk/samples/WebEndpoints)

<div id='endpoint-settings'/>
## 2. Web endpoint settings

The `WebEndpoint` is responsible for configuring and starting the WEB service. For this purpose, endpoint inherits from the `IEndpointLifeTimeCycle` interface which implements the `InitializeAsync` method. The `InitializeAsync` method is executing while the endpoint is activated. The consequently method will configure and lunch the WEB service. 

The endpoint implementation:
```csharp
    public class WebHostEndpoint : IEndpointLifeTimeCycle
```
The WEB service configuration:
```csharp
    public Task InitializeAsync(IMiddlewareBuilder builder)
    {
      var urls = Urls ?? _defaultUrls;
      _logger.Information($"Start initialize web host, urls = { string.Join(", ", urls.ToArray()) } ");
      Host = Microsoft.AspNetCore.WebHost
        .CreateDefaultBuilder()
        .UseContentRoot(Path.GetDirectoryName(typeof(WebEndpoint).Assembly.Location))
        .ConfigureServices(ConfigureServices)
        .UseStartup<Startup>()
        .UseUrls(urls)
        .Build();
      
      return Host.StartAsync();
    }

    protected virtual void ConfigureServices(IServiceCollection ioc)
    {
      ioc.AddTransient(ctx => _logger);
      ioc.AddTransient(ctx => _runtimeContext);
      ioc.AddTransient(ctx => _messageBus);
    }
```

<div id='mvc-controller-dependency-injection'/>
## 3. MVC Controller & dependency injection

It is possible to pass references to the controller using dependency injection. However, the dependency will not be resolved automatically. For this purpose, it is necessary to indicate in the configuration which dependencies can be injected into the controller. The example below shows how to inject a reference into the MessageBus service to broadcast messages in channel. 

Configuration of dependency injection
```csharp
    protected virtual void ConfigureServices(IServiceCollection ioc)
    {
      ioc.AddTransient(ctx => _logger);
      ioc.AddTransient(ctx => _runtimeContext);
      ioc.AddTransient(ctx => _messageBus);
    }
```
Configuration of MVC controller
```csharp
  [ApiController]
  [Route("api/[controller]")]
  public class ChannelController : ControllerBase
  {
    private IMessageBus MessageBus { get; }

    public ChannelController(IMessageBus messageBus)
    {
      MessageBus = messageBus;
    }
    ...
  }
```

<div id='hosting-static-files'/>
## 4. Hosting static files

It is possible to use the ProconTEL plugin to host static websites. For this purpose, the service `AddSpaStaticFiles` has been defined in the `Startup` class. Be able to display the page while installing the plugin, configure the path that contains the files. To publish your static files, follow the steps below:

- In the `Startup` class, set the name of the folder where the files will be located. In the example below, this is a folder named `WebApp`. 
```csharp
services.AddSpaStaticFiles(options => { options.RootPath = "WebApp"; });
```

- Install the plugin containing WEB endpoint.
- During plugin installation, select the folder with static files.

![Plugin Manager](./assets/PluginManager.png)

![Additional Directory](./assets/AdditionalDirectoryDefinition.png)

- Then add an endpoint to the channel or pool and run it. 

<div id='broadcasting-messages'/>
## 5. Broadcasting messages using http request

The web endpoint may allow you to communicate with other endpoints in the channel. An example of communication with other endpoints in the channel is presented below:

![Additional Directory](./assets/CommunicationInChannel.png)