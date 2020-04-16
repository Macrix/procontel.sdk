# ProconTEL.Sdk


## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Feature Comparison](#id-feature-comparison)
3. [Builder blocks](#id-builder-blocks)
    1. [ILifeTimeCycle](#id-builder-blocks-ilife-time-cycle)
    2. [IHandler](#id-builder-blocks-ihandler)
	3. [IMessageMetadataProvider](#id-builder-blocks-imessage-metadata-provider)
	4. [ICommandHandler](#id-builder-blocks-icommand-handler)
4. [Injected services](#id-injected-services)
    1. [ILogger](#id-injected-services-ilogger)
    2. [ISender](#id-injected-services-isender)
5. [UI Components](#id-ui-components)
    1. [Configuration Dialog](#id-ui-components-configuration-dialog)
    2. [Status Control](#id-ui-components-status-control)
6. [Deployment](#id-deployment)
    1. [Github](#id-deployment-github)
    2. [GitLab](#id-deployment-gitlab)

<div id='id-quick-introduction'/>

## 1. Quick introduction

`ProconTEL.Sdk` is a modern .Net Standard sdk for port your business logic in [ProconTEL](http://procontel.com/) environment. The modular design and middleware oriented architecture makes the endpoint highly customizable while providing sensible default for topology, communication and extensions. Documentation for version 1.x of the is currently found under [`/docs`](https://macrix.eu/).

<div id='id-feature-comparison'/>

## 2. Feature Comparison

| Feature         | x          | y | z |
| :-------------  |:-------------:|:---:|:------:|
| Backend         | redis         |redis| mongo  |
| Priorities      | ✓             |     |   ✓    |
| Concurrency     | ✓             |  ✓  |   ✓    |
| Delayed jobs    | ✓             |     |   ✓    |
| Global events   | ✓             |     |        |
| Rate Limiter    | ✓             |     |        |
| Pause/Resume    | ✓             |     |        |
| Sandboxed worker| ✓             |     |        |
| Repeatable jobs | ✓             |     |   ✓    |
| Atomic ops      | ✓             |  ✓  |        |
| Persistence     | ✓             |  ✓  |   ✓    |
| UI              | ✓             |     |   ✓    |
| REST API        |               |     |   ✓    |
| Optimized for   | Jobs / Messages | Messages | Jobs |

<div id='id-builder-blocks'/>

## 3. Builder blocks

<div id='id-builder-blocks-ilife-time-cycle'/>

* ### ILifeTimeCycle
```csharp
  [EndpointMetadata(Name = "LifeTimeCycle", SupportedRoles = SupportedRoles.Both)]
  public class LifeTimeCycleEndpoint : IEndpointLifeTimeCycle
  {
    private readonly ILogger _logger;
    public LifeTimeCycleEndpoint(ILogger logger) => _logger = logger;

    public Task InitializeAsync()
    {
      _logger.Information("Initialize");
      return Task.CompletedTask;
    }

    public Task TerminateAsync()
    {
      _logger.Information("Terminate");
      return Task.CompletedTask;
    }
  }

```

<div id='id-builder-blocks-ihandler'/>

* ### IHandler
```csharp
  [EndpointMetadata(Name = "Handler", SupportedRoles = SupportedRoles.Subscriber)]
  public class HandlerEndpoint : IHandler
  {
    private readonly ILogger _logger;
    public HandlerEndpoint(ILogger logger) => _logger = logger;

    public bool CanHandle(string messageId, ICorrelationContext context = null) => true;

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context)
    {
      _logger.Information($"Received id: {messageId}, message: {message}");
      return Task.FromResult<Acknowledgement>(new Ack());
    }
  }
```

<div id='id-builder-blocks-imessage-metadata-provider'/>

* ### IMessageMetadataProvider
```csharp
  [EndpointMetadata(Name = "MessageMetadataProvider", SupportedRoles = SupportedRoles.Provider)]
  public class MessageMetadataProviderEndpoint : IMessageMetadataProvider
  {
    public IEnumerable<MessageDetails> MessagesMetadata => Enumerable.Empty<MessageDetails>();
    public MessageMetadataProviderEndpoint() 
    {
    }
  }
```

<div id='id-builder-blocks-icommand-handler'/>

* ### ICommandHandler
```csharp
  [EndpointMetadata(Name = "CommandHandler", SupportedRoles = SupportedRoles.None)]
  public class CommandHandlerEndpoint : ICommandHandler
  {
    private readonly ILogger _logger;
    public CommandHandlerEndpoint(ILogger logger) => _logger = logger;

    public Task<object> HandleCommandAsync(object command, ICorrelationContext context = null)
    {
      _logger.Information($"Received command: {command}");
      return Task.FromResult<object>("Done");
    }
  }
```

<div id='id-injected-services'/>

## 4. Injected services

<div id='id-injected-services-ilogger'/>

* ### ILogger
```csharp

```

<div id='id-injected-services-isender'/>

* ### ISender
```csharp

```

<div id='id-ui-components'/>

## 5. UI Components

We are able to bind and communicate user interface to hosted business logic. Supported fronted framework:
 - Angular
 - React
 - Wpf
 - WinForms
 
<div id='id-ui-components-configuration-dialog'/>
 
* ### Configuration Dialog
```csharp

```

<div id='id-ui-components-status-control'/>

* ### Status Control
```csharp

```

<div id='id-deployment'/>

## 6. Deployment

<div id='id-deployment-github'/>

* ### Github
```csharp

```

<div id='id-deployment-gitlab'/>

* ### GitLab
```csharp

```
