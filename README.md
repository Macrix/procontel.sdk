# ProconTEL.Sdk


## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Feature Comparison](#id-feature-comparison)
3. [Builder blocks](#id-builder-blocks)
    1. [EndpointMetadata](#id-builder-blocks-endpoint-metadata)
	2. [ILifeTimeCycle](#id-builder-blocks-ilife-time-cycle)
    3. [IHandler](#id-builder-blocks-ihandler)
	4. [IMessageMetadataProvider](#id-builder-blocks-imessage-metadata-provider)
	5. [ICommandHandler](#id-builder-blocks-icommand-handler)
	6. [IConfigurationCommandHandler](#id-builder-blocks-iconfiguration-command-handler)
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

`ProconTEL.Sdk` is a modern .Net Standard sdk for port your business logic in [ProconTEL](http://procontel.com/) environment. The modular design and middleware oriented architecture makes the endpoint highly customizable while providing sensible default for topology, communication and extensions. Documentation for version 1.x of the is currently found under [`docs`](https://macrix.eu/).

<div id='id-feature-comparison'/>

## 2. Feature Comparison

| Feature         | ChannelEndpointBase          | Sdk 0.4  | Sdk 1.1 |
| :-------------  |:-------------:|:---:|:------:|
| Import          | ✓             |-    | ✓  |
| Export          | ✓             |-     |   ✓    |
| Status Control     | ✓             |  ✓  |   ✓    |
| Send Command from Status Control   | ✓             |   ✓  |   ✓    |
| Endpoint Status Notification   | ✓             |   ✓  |   ✓    |
| Configuration Dialog    | ✓             |   ✓  |   ✓    |
| Send Command from Configuration Dialog   | ✓             |   ✓  |   ✓    |
| Endpoint Content Details   | ✓             |   ✓  |   ✓    |
| Endpoint Content Details in attribute   | -             |   -  |   ✓    |
| Acknowledgement   | ✓             |   ✓  |   ✓    |
<div id='id-builder-blocks'/>

## 3. Builder blocks

To create endpoint we need to decorate C# class with the <b>EndpointMetadata</b> attribute. To keep ProconTEL  environment clear we strongly recommended 
use self describe property Name in <b>EndpointMetadata</b>. ProconTEL.Sdk deliver builder blocks which gives developer possibilities to extend endpoint functionality. To use builder block endpoint has to implement one of interfase. This interfaces are representation of endpoint behaviors and can be mixed freely.
<b>EndpointMetadata</b> contains property SupportedRoles which is promise of endpoint communication posobilities.

<div id='id-builder-blocks-endpoint-metadata'/>

* ### EndpointMetadata 
This is simple example how we can decorate endpoint class.
```csharp
  [EndpointMetadata(Name = "Empty", SupportedRoles = SupportedRoles.Both)]
  public class EmptyEndpoint
  {
  }
```

<div id='id-builder-blocks-ilife-time-cycle'/>

* ### ILifeTimeCycle
A endpoint has a lifecycle managed by ProconTEL. ProconTEL.Sdk offers interface <b>ILifeTimeCycle</b> that provide visibility into these key life moments and the ability to act when they occur.
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
<b>IHandler</b> is common communication interface which provide receiving data from another endpoint. We can filter incoming messages by implement method `CanHandle`. 
Asynchronous method `HandleAsync` is responsible for processing data. <b>This execution is a blocking call (synchronous).</b> No execution will take place on the current thread until current processing returns some acknowledgement. <b>We will not process new messages until the current processing is completed.</b>
We support few acknowledgement types : Ack, Retry, Reject. Hadnler implementation has to return acknowledgement (mandatory), but sender can ignore it (obligatory).
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
Interface <b>IMessageMetadataProvider</b> provide mechanism to define runtime mutable list of sending message metadata.
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
Interface <b>ICommandHandler</b> support handling messages from Status Control Component. Processing approach is similar like in [IHandler](#id-builder-blocks-ihandler).
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

<div id='id-builder-blocks-iconfiguration-command-handler'/>

* ### IConfigurationCommandHandler
Interface <b>IConfigurationCommandHandler</b> support handling messages from Configuration Dialog Component. Configuration Command Handler mechanism will soon be deprecated.
```csharp
  [Obsolete("Configuration Command Handler mechanism will soon be deprecated.")]
  [EndpointMetadata(Name = "ConfigurationCommandHandler", SupportedRoles = SupportedRoles.None)]
  public class ConfigurationCommandHandlerEndpoint : IConfigurationCommandHandler
  {
    private readonly ILogger _logger;
    public ConfigurationCommandHandlerEndpoint(ILogger logger) => _logger = logger;

    public Task<object> HandleConfigurationCommandAsync(object command, ICorrelationContext context = null)
    {
      _logger.Information($"Execute command {command}");
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

<div id='id-ioc'/>

## 6. IoC

<div id='id-testing'/>

## 7. Testing

<div id='id-deployment'/>

## 8. Deployment

<div id='id-deployment-github'/>

* ### Github
```csharp

```

<div id='id-deployment-gitlab'/>

* ### GitLab
```csharp

```
