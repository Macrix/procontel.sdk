---
Title: "ProconTEL SDK"
Weight: 8
Description: >
  Learn how to use the ProconTEL SDK
---

## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Compatibility matrix](#id-compatibility-matrix)
3. [Feature comparison](#id-feature-comparison)
4. [Additional features](#id-additional-features-blocks)
5. [Builder blocks](#id-builder-blocks)
	* [ILifeTimeCycle](#id-builder-blocks-ilife-time-cycle)
    * [IHandler](#id-builder-blocks-ihandler)
    * [ICommandHandler](#id-builder-blocks-icommand-handler)
    * [IConfigurationCommandHandler](#id-builder-blocks-iconfiguration-command-handler)
    * [IOnlineConfigurationUpdate](#id-builder-blocks-ionline-configuration-update)
    * [IOnlineUpgradeLifetimeCycle](#id-builder-blocks-ionline-upgrade-life-time-cycle)    
    * [IAvatarsInsight](#id-builder-blocks-iavatars-insight)
    * [IFileHandler](#id-builder-blocks-ifilehandler)
    * [IAuthorization](#id-builder-blocks-iauthorization)
    * [IAuthentication](#id-builder-blocks-iauthentication)
    * [IExportable](#id-builder-blocks-iexportable)
    * [IRequestMissedContent](#id-builder-blocks-irequest-missed-content)
    * [IRequestLastContent](#id-builder-blocks-irequest-last-content)
6. [Injected services](#id-injected-services)
    * [ILogger](#id-injected-services-ilogger)
    * [IMessageBus](#id-injected-services-imessage-bus)
    * [IConfigurationReader](#id-injected-services-iconfiguration-reader)
    * [IRuntimeContext](#id-injected-services-iruntime-context)
    * [IMetadataContext](#id-injected-services-imetadata-context)
    * [INotificationService](#id-injected-services-inotification-service)
    * [IMetricsService](#id-injected-services-imetrics-service)
    * [IServiceContext](#id-injected-services-iservice-context)
    * [IReportService](#id-injected-services-ireportservice-context)
    * [IStreamingService](#id-injected-services-istreamingservice-context)
7. [Providers](#id-providers)
	  * [IMessageMetadataProvider](#id-providers-imessage-metadata-provider)
8. [Attributes](#id-attributes)
	  * [EndpointMetadata Attribute](#id-attributes-endpoint-metadata)
    * [MessageMetadata Attribute](#id-attributes-message-metadata)
    * [MessageMetadataProvider Attribute](#id-attributes-message-metadata-provider)
9. [Advanced concepts](#id-advanced-concepts)
    * [Supported protocols](#id-advanced-concepts-protocols)
    * [Persistent messages](#id-advanced-concepts-persistent-messages)
10. [UI Components](#id-ui-components)
    * [Configuration Dialog](#id-ui-components-configuration-dialog)
    * [Status Control](#id-ui-components-status-control)
    * [Custom Menu Items](#id-ui-custom-menu-items)
11. [Injected services for UI Components](#id-injected-services-ui-components)
    * [IConfigurationWriter](#id-ui-components-injected-services-iconfiguration-writer)
    * [ILocalStorage](#id-ui-components-injected-services-ilocal-storage)
    * [ISecurityService](#id-ui-components-injected-services-isecurity-service)
    * [IFileUploaderService](#id-ui-components-injected-services-ifileuploaderservice)
    * [IVirtualFileSystem](#id-ui-components-injected-services-ivirtualfilesystem)
    * [Streaming](#id-ui-components-injected-istreamingservice)
12. [IoC](#id-ioc)
13. [Middlewares](#id-middlewares)
14. [Legacy Sdk](#id-legacy-sdk)
15. [Testing](#id-testing)
16. [Deployment](#id-deployment)
    * [Github](#id-deployment-github)
    * [GitLab](#id-deployment-gitlab)



<div id='id-quick-introduction'/>

## 1. Quick introduction

`ProconTEL.Sdk` is a modern .NET Standard SDK for porting your business logic with [ProconTEL](http://procontel.com/) environment. The modular design and middleware oriented architecture makes the endpoint highly customizable while providing sensible default for topology, communication and extensions. Documentation for version 1.x is currently available under [`docs`](https://macrix.eu/).

<div id='id-compatibility-matrix'/>

## 2. Compatibility matrix
As SDK version may change, we provide SDK compatibility matrix which shows which SDK versions is supported by which *ProconTEL Engine*.
| *ProconTEL Engine* version | *ProconTEL SDK* version  | 
| :---:  |:---:|
| 3.0.17 | 1.0.5 |
| 3.0.16 | 1.0.4 |
| 3.0.15 | 1.0.3 |
| 3.0.14 | 1.0.2 |
| 3.0.13 | 1.0.2 |
| 3.0.12.2 | 1.0.1 |
| 3.0.12.1 | 1.0.1 |
| 3.0.12 | 1.0.1 |
| 3.0.11 | 1.0.1 |
| 3.0.10.1 | 1.0.0 |
| 3.0.10 | 1.0.0 |
| 3.0.9 | 1.0.0 |
| 3.0.8 | 0.11.0 |
| 3.0.7 | 0.10.0 |
| 3.0.6 | 0.9.0 |
| 3.0.5 | 0.8.0 |
| 3.0.4 | 0.7.0 |
| 3.0.3 | 0.6.0 |
| 3.0.2 | 0.5.0 |

<div id='id-feature-comparison'/>

## 3. Feature Comparison
Table below lists feature available in *ProconTEL Engine 2.x SDK* and compares it with features available in new SDK under *ProconTEL Engine 3.x*. Features are described with hints as it was available in *Engine 2.x*.

| Feature         | Engine 2.x SDK | SDK 1.0<br>*Current*  | SDK 1.1<br>*Planned* | SDK Legacy 1.0<br>*Current* |
| :---  |:---:|:---:|:---:|:---:|
| Broadcast message                                                                                      | ✓ | ✓ | ✓ | ✓ | 
| Send message                                                                                           | ✓ | ✓ | ✓ | ✓ | 
| Attach metadata with message when broadcast/send                                                       | ✓ | ✓ | ✓ | ✓ | 
| Handle message<br>`SubscriberStrategy.AcceptsContent()`, `SubscriberStrategy.ProcessContent()`         | ✓ | ✓ | ✓ | ✓ | 
| Handle metadata information of received message<br>`ContentInfo`                                       | ✓ | ✓ | ✓ | ✓ |
| Expose details of send/broadcasted messages<br>`ProviderStrategy.ProvidingContentDetails`              | ✓ | ✓ | ✓ | ✓ |
| Handle supported protocols<br>`SubscriberStrategy.SubscribingProtocols`                                | ✓ | ✓ | ✓ | ✓ |
| Acknowledge processed message<br>`SubscriberStrategy.AcknowledgeContent()`                             | ✓ | ✓ | ✓ | - |
| Automatic acknowledge<br>`SubscriberStrategy.AutomaticContentAcknowledge`                              | ✓ | - | - | ✓ |
| Life cycle mechanism<br>`ChannelEndpointBase.Initialize()`, `ChannelEndpointBase.Terminate()`          | ✓ | ✓ | ✓ | ✓ |
| On-line upgrade<br>`ChannelEndpointBase.OnBeforeUpgrade()`, `ChannelEndpointBase.OnAfterUpgrade()`     | ✓ | ✓ | ✓ | ✓ |
| Reading endpoint configuration<br>`ChannelEndpointBase.GetConfiguration()`                             | ✓ | ✓ | ✓ | ✓ |
| Handle endpoint configuration changes in runtime<br>`ChannelEndpointBase.OnConfigurationUpdated()`     | ✓ | ✓ | ✓ | ✓ |
| Logger<br>*all `Logger.Debug()`, `Logger.Error()`, etc. methods                                        | ✓ | ✓ | ✓ | ✓ |
| ~~Custom log source location information<br>`ILogMessageOrigin` support~~                              | ✓ | - | - | - |
| Endpoint metadata<br>`ChannelEndpointBase.Id`, `ChannelEndpointBase.CustomId`, etc.                    | ✓ | ✓ | ✓ | ✓ |
| Endpoint type<br>`ChannelEndpointBase.ActsAsProvider`, `ChannelEndpointBase.ActsAsSubscriber`          | ✓ | ✓ | ✓ | ✓ |
| Broadcast/Send stream in endpoint<br>`ChannelEndpointBase.BroadcastContent(Stream, StreamReleaseCallbackHandler)` | ✓ | ✓ | ✓ | - |
| Handle stream in endpoint                                                                              | ✓ | ✓ | ✓ | - |
| Send stream to UI status control                                                                       | ✓ | ✓ | ✓ | - |
| Handle stream in UI status control                                                                     | ✓ | ✓ | ✓ | - |
| Custom actions while endpoint is imported<br>`ChannelEndpointBase.ImportContentDirectory()`            | ✓ | ✓ | ✓ | ✓ |
| Custom actions while endpoint is exported<br>`ChannelEndpointBase.ExportContentDirectory()`            | ✓ | ✓ | ✓ | ✓ |
| Avatar connected event<br>`ChannelEndpointBase.AvatarConnected()`                                      | ✓ | ✓ | ✓ | ✓ |
| Avatar disconnected event<br>`ChannelEndpointBase.AvatarDisconnected()`                                | ✓ | ✓ | ✓ | ✓ |
| ~~Read and save avatars subscribed messages<br>`SubscriberStrategy.AddSubscribedContent()`~~           | ✓ | - | - | - |
| ~~Read/save avatars configuration<br>`IEndpointConfigurationController.GetAvatarConfiguration()`~~     | ✓ | - | - | - |
| Report custom warning<br>`ICommunicationChannel.ReportEndpointWarning()`                               | ✓ | ✓ | ✓ | ✓ |
| Clear custom warning<br>`ICommunicationChannel.ClearEndpointWarnings()`                                | ✓ | ✓ | ✓ | ✓ |
| `RequestLastContent()`                                                                                 | ✓ | ✓ |✓ | ✓ |
| `RequestMissedContents()`                                                                              | ✓ | ✓ | ✓ | ✓ |
| Configuration dialog (WinForms)                                                                        | ✓ | ✓ | ✓ | ✓ |
| Configuration dialog provider (WinForms)                                                               | - | ✓ | ✓ | ✓ |
| Read and store endpoint configuration in conf. dialog                                                  | ✓ | ✓ | ✓ | ✓ |
| Send command from conf. dialog<br>`SendCommandToServerEndpoint()`                                      | ✓ | ✓ | ✓ | ✓ |
| Access remote file system from conf. dialog                                                            | ✓ | ✓ | ✓ | ✓ |
| Send files from conf. dialog                                                                           | ✓ | ✓ | ✓ | ✓ |
| Conf. dialog available while endpoint is active                                                        | ✓ | ✓ | ✓ | ✓ |
| Endpoint status control (WinForms, WPF)                                                                | ✓ | ✓ | ✓ | ✓ |
| Send command from status control<br>`SendCommandToServerEndpoint()`                                    | ✓ | ✓ | ✓ | ✓ |
| Notification from endpoint to status control                                                           | ✓ | ✓ | ✓ | ✓ |
| Send files from status control                                                                         | ✓ | ✓ | ✓ | ✓ |
| Access remote file system from status control                                                          | ✓ | ✓ | ✓ | ✓ |
| State manager for status control                                                                       | ✓ | ✓ | ✓ | ✓ |
| Custom menu items (exposed in *Communication Console*)                                                 | ✓ | ✓ | ✓ | ✓ |
| `IAuthenticationEndpoint`                                                                              | ✓ | ✓ | ✓ | - |
| `IAuthorizationEndpoint`                                                                               | ✓ | ✓ | ✓ | - |
| After initialization method `AfterActivate()`                                                          | ✓ | - | - | ✓ |
| ~~Custom queues definitions~~                                                                          | ✓ | - | - | - |
| ~~Information about other endpoints available in channel<br>`ChannelSubscriberDetails`, `ChannelProviderDetails`, `ChannelProviderContentDetails`, `ChannelSubscriberIds`, `ChannelProviderIds`~~ | ✓ | - | - | - |
| ~~Custom endpoint remove confirmation dialog<br>`ChannelEndpointBase.GetRemoveConfirmationDialog()`~~  | ✓ | - | - | - |
| ~~Divide/merge configuration when endpoint is moved, split (avatar + endpoint) or merged (remove avatar and replace with endpoint from pool)~~ | ✓ | - | - | - |

<div id='id-additional-features-blocks'/>

## 4. Additional features
| Feature         | SDK version |
| :---  |:---:|
| Expose details of send/broadcasted messages in attribute                                               |  1.x |
| Override services implementation                      | 1.x |
| Asynchronous methods (`async`)                        | 0.10 |

<div id='id-builder-blocks'/>

## 5. Builder blocks

To create endpoint we need to decorate C# class with the `EndpointMetadata` attribute. To keep ProconTEL environment clear we strongly recommended to use self describing property `Name` in attribute. `ProconTEL.Sdk` delivers builder blocks which gives developer possibilities to extend endpoint functionality. To use builder block endpoint has to implement one of interfaces. Each interface represents endpoint behavior and it can be mixed freely. `EndpointMetadata` contains property `SupportedRoles` which is promise of endpoint communication posobilities.

<div id='id-builder-blocks-ilife-time-cycle'/>

* ### ILifeTimeCycle
A endpoint has a lifecycle managed by ProconTEL. ProconTEL.Sdk offers interface `ILifeTimeCycle` that provide visibility into these key life moments and the ability to act when they occur. It also allows customization of default ProconTEL input pipeline for receiving messages. For more information see [Middlewares](#id-middlewares).
```csharp
  [EndpointMetadata(Name = "LifeTimeCycle", SupportedRoles = SupportedRoles.Both)]
  public class LifeTimeCycleEndpoint : IEndpointLifeTimeCycle
  {
    private readonly ILogger _logger;
    public LifeTimeCycleEndpoint(ILogger logger) => _logger = logger;

    public Task InitializeAsync(IMiddlewareBuilder builder)
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
We support few acknowledgement types : Ack, Retry, Reject. Handler implementation has to return acknowledgement (mandatory), but sender can ignore it (obligatory).
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

<div id='id-builder-blocks-ionline-configuration-update'/>

* ### IOnlineConfigurationUpdate
Interface <b>IOnlineConfigurationUpdate</b> support observe configuration changed notification. To read current configuration version use <b>IConfigurationReader</b> service injection.  
```csharp
  [EndpointMetadata(Name = "OnlineConfigurationUpdate", SupportedRoles = SupportedRoles.None)]
  public class OnlineConfigurationUpdateEndpoint : IOnlineConfigurationUpdate
  {
    private readonly ILogger _logger;
    private readonly IConfigurationReader _configurationReader;
    public OnlineConfigurationUpdateEndpoint(ILogger logger, IConfigurationReader configurationReader)
    {
      _logger = logger;
      _configurationReader = configurationReader;
    }

    public Task ConfigurationChangedAsync()
    {
      _logger.Information($"Configuration was changed. Current values: {_configurationReader.GetConfiguration()})");
      return Task.CompletedTask;
    }
  }
```

<div id='id-builder-blocks-ionline-upgrade-life-time-cycle'/>

* ### IOnlineUpgradeLifetimeCycle
Interface <b>IOnlineUpgradeLifetimeCycle</b> support visibility into upgrade plugin process and the ability to act when they occur.
```csharp
  [EndpointMetadata(Name = "OnlineUpgradeLifetimeCycle", SupportedRoles = SupportedRoles.None)]
  public class OnlineUpgradeLifetimeCycleEndpoint : IOnlineUpgradeLifetimeCycle
  {
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public OnlineUpgradeLifetimeCycleEndpoint(ILogger logger, IRuntimeContext runtimeContext)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
    }
    public Task AfterUpgradeAsync()
    {
      _logger.Information($"Update endpoint finished (id: {_runtimeContext.MetadataContext.Id})");
      return Task.CompletedTask;
    }

    public Task<bool> CanUpgradeAsync() => Task.FromResult(true);
  }
```

<div id='id-builder-blocks-iavatars-insight'/>

* ### IAvatarsInsight
<b>IAvatarInsight</b> is an interface that allows to handle avatar connection and disconnection events in avatar source endpoint.

```csharp
  [EndpointMetadata(Name = "Avatar Insight Endpoint", SupportedRoles = SupportedRoles.None)]
  class AvatarInsightEndpoint : IAvatarsInsight
  {
    private ILogger Logger;

    public AvatarInsightEndpoint(ILogger logger)
    {
      Logger = logger;
    }

    public Task AvatarConnectedAsync(IAvatarConfiguration avatarConfiguration)
    {
      Logger.Information($"Avatar has been connected");
      return Task.CompletedTask;
    }

    public Task AvatarDisconnectedAsync(IAvatarConfiguration avatarConfiguration)
    {
      Logger.Information($"Avatar has been disconnected");
      return Task.CompletedTask;
    }
  }
```

<div id='id-builder-blocks-ifilehandler'/>

* ### IFileHandler
Interface <b>IFileHandler</b> allows handling of uploaded files from client to server backend.
```csharp
  [EndpointMetadata(Name = "FileReceiver", SupportedRoles = SupportedRoles.None)]
  public class FileReceiverEndpoint : IFileHandler
  {
    private readonly ILogger _logger;

    public FileReceiverEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public Task<object> HandleFileAsync(IUploadedFiles uploadedFiles)
    {
      _logger.Information($"Execute {nameof(HandleFileAsync)}. Uploaded files: {String.Join(",", uploadedFiles.TransferedFiles)}.");
      return Task.FromResult(new object());
    }
```

<div id='id-builder-blocks-iauthorization'/>

* ### IAuthorization
Interface <b>IAuthorization</b> provide authorization mechanism.
```csharp
  [EndpointMetadata(Name = "Authorization", SupportedRoles = SupportedRoles.None)]
  public class AuthorizationEndpoint : IAuthorizationEndpoint
  {
      private const string TOKEN = "secretToken";
      private const string ROLE = "administrator";

      public bool IsInRole(string authenticationToken, string roleName)
          => authenticationToken == TOKEN && ROLE.Equals(roleName);
  }
```

<div id='id-builder-blocks-iauthentication'/>

* ### IAuthentication
Interface <b>IAuthentication</b> provide authentication mechanism.
```csharp
  [EndpointMetadata(Name = "Authentication", SupportedRoles = SupportedRoles.None)]
  public class AuthenticationEndpoint : IAuthenticationEndpoint
  {
      private const string TOKEN = "secretToken";
      private const string PASSWORD = "secret";
      public string Authenticate(string authenticationString)
          => authenticationString == PASSWORD ? TOKEN : null;

      public byte[] ExecuteCustomAuthenticationCommand(byte[] command)
          => command;
  }
```

<div id='id-builder-blocks-iexportable'/>

* ### IExportable
Interface <b>IExportable</b> is used to save some custom files in exported pex file. Method `ImportContentDirectoryAsync` should be used to recreate stored files to disk, method `ExportContentDirectoryAsync` for serialize files into byte array that will be stored in pex file. 

```csharp
  [EndpointMetadata(Name = "Exportable Endpoint", SupportedRoles = SupportedRoles.None)]
  public class ExportableEndpoint : IExportable
  {
     public async Task ImportContentDirectoryAsync(byte[] directory)
    {
      /// Recreate files from byte array
    }

    public Task<byte[]> ExportContentDirectoryAsync()
    {
      /// Serialize files into byte array
    } 
  }
```


<div id='id-builder-blocks-irequest-missed-content'/>

* ### IRequestMissedContent
In some cases endpoint can ask for messages that was delivered but not acknowledged, to handle that event <b>IRequestMissedContent</b> was introduced.

```csharp
  [EndpointMetadata(Name = "Missing Messages Endpoint", SupportedRoles = SupportedRoles.Both)]
  public class MissingMessagesEndpoint : IRequestMissedContent
  {
    private readonly ILogger _logger;

    public MissingMessagesEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public Task ProcessMissedContentsRequestAsync(string subscriberId, IEnumerable<string> contentIds, DateTime? startingDateTime)
    {
      _logger.Information("SubscribedId endpoint asked for messages with contentsIds sent from startingDateTime up to now");
      return Task.CompletedTask;
    }
  }

```

<div id='id-builder-blocks-irequest-last-content'/>

* ### IRequestLastContent
In some cases endpoint can ask for last sent messages in channel, to handle that event <b>IRequestLastContent</b> was introduced.

```csharp
  [EndpointMetadata(Name = "Last Messages Endpoint", SupportedRoles = SupportedRoles.Both)]
  public class LastMessagesEndpoint : IRequestLastContent
  {
    private readonly ILogger _logger;

    public LastMessagesEndpoint(ILogger logger)
    {
      _logger = logger;
    }

    public Task OnRequestLastContentReceivedAsync(string requestingEndpointId, string providerId, params string[] contentIds)
    {
         _logger.Information("requestingEndpointId endpoint asked for messages with contentsIds sent by providerId");    
        return Task.CompletedTask;
    }
  }
```


<div id='id-injected-services'/>

## 6. Injected services

ProconTEL environment provide set of features available via dependency injection. To use this mechanism developer has to use appropriate interface in endpoint constructor. In ProconTEL naming conventions this interfaces called <b>services</b>.

```csharp
  [EndpointMetadata(Name = "Rich", SupportedRoles = SupportedRoles.Provider)]
  public class RichEndpint
  {
    private readonly ILogger _logger;
    private readonly IMessageBus _messageBus;
    private readonly IConfigurationReader _configurationReader;
    private readonly IRuntimeContext _runtimeContext;
    private readonly IServiceContext _serviceContext;
    private readonly IReportService _reportService;

    public RichEndpint(
      ILogger logger,
      IMessageBus messageBus,
      IConfigurationReader configurationReader,
      IRuntimeContext runtimeContext,
      IServiceContext serviceContext,
      IReportService reportService)
    {
      _logger = logger;
      _messageBus = messageBus;
      _configurationReader = configurationReader;
      _runtimeContext = runtimeContext;
      _serviceContext = serviceContext;
      _reportService = reportService;
    }
  }

```

<div id='id-injected-services-ilogger'/>

* ### ILogger
Service provide logging mechanism.

<div id='id-injected-services-imessage-bus'/>

* ### IMessageBus
Service provide send and broadcast mechanism. 

<div id='id-injected-services-iconfiguration-reader'/>

* ### IConfigurationReader
Service provide read configuration mechanism. 

<div id='id-injected-services-iruntime-context'/>

* ### IRuntimeContext
Service to aggregate other services related with endpoint runtime. 

<div id='id-injected-services-imetadata-context'/>

* ### IMetadataContext
Service provide metadata about running endpoint. This service is part of [IRuntimeContext](#id-injected-services-iruntime-context).

<div id='id-injected-services-inotification-service'/>

* ### INotificationService
Service provide notification from endpoint to status control. This service is part of [IRuntimeContext](#id-injected-services-iruntime-context).

<div id='id-injected-services-imetrics-service'/>

* ### IMetricsService
Feature in progress

<div id='id-injected-services-iservice-context'/>

* ### IServiceContext
Service provide access to implementation of internal services from procontel engine.
```csharp
  [EndpointMetadata(Name = "IoC", SupportedRoles = SupportedRoles.Provider)]
  public class IoCEndpoint : IEndpointLifeTimeCycle
  {
    private readonly Func<string, ILogger> _loggerFactory;
    private readonly IServiceContext _serviceContext;

    public IoCEndpoint(IServiceContext serviceContext)
    {
      _serviceContext = serviceContext;
      _loggerFactory = _serviceContext.Resolve<Func<string, ILogger>>();
      _loggerFactory("Custom Origin").Information("Invoke constructor for endpoint IoC");
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public Task TerminateAsync() => Task.CompletedTask; 
```

<div id='id-injected-services-ireportservice-context'/>

* ### IReportService
Service to inform about warnings in runtime.

<div id='id-injected-services-istreamingservice-context'/>

* ### IStreamingService
Service provides access to stream with given id. The service can be pass through  constructor in endpoint and in status control (implementing `IEndpointStatusControl` interface). This service is marked as obsolete and is strongly recommended to not use it in new projects.

The stream can be send by corresponding version of `IMessageBus` methods `Send` and `Broadcast`. In case of communication between two endpoints:
```csharp
 _messageBus.Send("receiverId", "messageId", "message body", 
        streamInstance, StreamCallbackDelegate, new ExampleProtocol(), null);
  /// or
 _messageBus.Broadcast("messageId", "message body", streamInstance, StreamCallbackDelegate, new ExampleProtocol(), null);       
```
 The stream passed to the method is not send itself, but the stream is registered and stored in procontel backend and available for everybody that know a stream id. The received message object should be cast to IStreamDescriptor to recognise whether the message contains stream or no:
 ```csharp
public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
  {
    if (message is IStreamDescriptor descriptor)
    {
      // get stream using IStreamingService instance and a stream id
      _stream = _streamingService.GetStream(descriptor.StreamId);
    }
    return Task.FromResult(new Acknowledgement());
  }
 ```   

In case of send stream between endpoint and UI status control can be used method `NotifyUI` from `INotificationService`:
```csharp
_notificationService.NotifyUI($"status information message body", streamInstance, StreamCallbackDelegate);
``` 
then `DisplayStatusAsync` from `IEndpointStatusControl` will be called with `IStreamDescriptor` as parameter:
 ```csharp 
public async Task DisplayStatusAsync(object statusInformation)
{
  if (statusInformation is IStreamDescriptor descriptor)
  {
    // get stream using IStreamingService instance and a stream id
    _stream = _streamingService.GetStream(descriptor.StreamId);
  }   
  return Task.FromResult(new Acknowledgement());
}
 ```
 Original message body can be obtained by accessing to `Data` property of `IStreamDescriptor<T>` and it's necessary to use a reflection:
 ```csharp
 public async Task DisplayStatusAsync(object statusInformation)
{
  if (statusInformation != null)
  {
    var statusInformation = statusInformation.GetType();
    if (type.IsGenericType)
    {
      var originalMessageBody = type.GetProperty(nameof(StreamDescriptor<object>.Data))?.GetValue(statusInformation);
    }
  }
  return Task.FromResult(new Acknowledgement());
}
 ```

<div id='id-providers'/>

## 7. Providers

<div id='id-providers-imessage-metadata-provider'/>

* ### IMessageMetadataProvider
Interface <b>IMessageMetadataProvider</b> provide mechanism to define runtime mutable list of sending message metadata.
```csharp
  public class MessageMetadataProviderEndpoint : IMessageMetadataProvider
  {
    public IEnumerable<MessageDetails> MessagesMetadata => Enumerable.Empty<MessageDetails>();
    public MessageMetadataProviderEndpoint() 
    {
    }
  }
```


<div id='id-attributes'/>

## 8. Attributes

<div id='id-attributes-endpoint-metadata'/>

* ### EndpointMetadata Attribute 
This is simple example how we can decorate endpoint class.
```csharp
  [EndpointMetadataAttribute(Name = "Empty", SupportedRoles = SupportedRoles.Both)]
  public class EmptyEndpoint
  {
  }
```

<div id='id-attributes-message-metadata' />

* ### MessageMetadata Attribute 
This is simple example how we can decorate endpoint class as provider message with id `message_id`.
```csharp
  [MessageMetadata("message_id", "message_caption")]
  [EndpointMetadataAttribute(Name = "Empty", SupportedRoles = SupportedRoles.Both)]
  public class EmptyEndpoint
  {
  }
```

<div id='id-attributes-message-metadata-provider' />

* ### MessageMetadataProvider Attribute 
This is simple example how we can decorate endpoint class.
```csharp
  public class MessageMetadataProvider : IMessageMetadataProvider
  {
    public IEnumerable<MessageDetails> MessagesMetadata => Enumerable.Empty<MessageDetails>();
  }

  [MessageMetadataProviderAttribute(typeof(MessageMetadataProvider))]
  [EndpointMetadata(Name = "MessageMetadataProvider", SupportedRoles = SupportedRoles.Provider)]
  public class MessageMetadataProviderEndpoint
  {
  }
```

<div id='id-advanced-concepts'/>

## 9. Advanced concepts

<div id='id-advanced-concepts-protocols'/>

* ### Supported protocols
Defining supported protocols can be done by creating custom attribute and marking endpoint with it.
```csharp
  public class CustomEndpointProtocol : IProtocol
  {
    public string Id => "Custom Endpoint Protocol";
  }

  public class CustomEndpointProtocolAttribute : ProconTel.Sdk.Communications.Attributes.SupportedProtocolAttribute
  {
    public CustomEndpointProtocolAttribute()
    {
      Name = new CustomEndpointProtocol();
    }
  }
  
  [EndpointMetadata(Name = "CustomProtocols", SupportedRoles = SupportedRoles.Both)]
  [CustomEndpointProtocol]
  public class CustomProtocolsEndpoint : IEndpointLifeTimeCycle, IHandler
  {
  }
```

<div id='id-advanced-concepts-persistent-messages'/>

* ### Persistent messages
To persist messages which are sent to an endpoint the `PersistMessage` attribute has to be set during implementation of an endpoint. The parameters of `PersistMessage` attribute are `QueueSize` and `Retention`. They are used to configure the message retention policy of an persisted endpoint. `Queuesize` defines the maximum number of messages that get stored in the database of an persisted endpoint. `Retention` defines how long messages of an perstited endpoint are stored. The format is `D.HH:MM:SS`

```csharp
  [PersistMessage("message", QueueSize = 100, Retention ="0.00:10:10")]
  [EndpointMetadata(Name = "PersistentMessage", SupportedRoles = SupportedRoles.Both)]
  public class PersistentMessageEndpoint : IHandler
  {
    private readonly ILogger _logger;
    public PersistentMessageEndpoint(ILogger logger) => _logger = logger;

    public bool CanHandle(string messageId, ICorrelationContext context = null) => true;

    public Task<Acknowledgement> HandleAsync(string messageId, object message, ICorrelationContext context = null)
    {
      _logger.Information($"Received id: {messageId}, message: {message}");
      return Task.FromResult<Acknowledgement>(new Ack());
    }
  }
```

<div id='id-ui-components'/>

## 10. UI Components

We are able to bind and communicate user interface to hosted business logic.

<div id='id-ui-components-configuration-dialog'/>
 
* ### Configuration Dialog
ProconTEL.Sdk provide few features:
- <b>read endpoint configuration,</b>
- <b>write endpoint configuration, </b></br>
  <i>add line ```DialogResult = DialogResult.OK;```to commit configuration changes</i>
- <b>send command to deactivated endpoint (does not have full access to endpoint resource )</b>
- <b>upload file from configuration dialog to endpoint</b>

To define Configuration UI Element binding endpoint has to be decorate with attribute <b>ConfigurationDialogAttribute</b>. Windows Forms dialog type should be put as a attribute constructor parameter.

```csharp
  [ConfigurationDialog(typeof(WebHostConfigurationDialog))]
  [EndpointMetadata(Name = "Configurable Endpoint", SupportedRoles = SupportedRoles.None)]
  public class ConfigurableEndpoint 
  {
    private readonly IConfigurationReader _configurationReader;
    public ConfigurableEndpoint(IConfigurationReader configurationReader)
    {
      _configurationReader = configurationReader;
    }
  }
```

```csharp
  public partial class ConfigurationDialog : Form
  {
    private readonly IConfigurationWriter _configurationWriter;
    private readonly IConfigurationReader _configurationReader;
    private readonly IEndpointCommandSender _endpointCommandSender;

    public ConfigurationDialog()
    {
      InitializeComponent();
    }

    public ConfigurationDialog(
      IConfigurationWriter configurationWriter,
      IConfigurationReader configurationReader,
      IEndpointCommandSender endpointCommandSender) : this()
    {
      _configurationWriter = configurationWriter;
      _configurationReader = configurationReader;
      _endpointCommandSender = endpointCommandSender;
      txtAdress.Text = _configurationReader.GetConfiguration();
    }

    private void SaveConfiguration_Click(object sender, EventArgs e)
    {
      _configurationWriter.SaveConfiguration(textBox1.Text);
      DialogResult = DialogResult.OK;
    }

    private void SendCommandToServerEndpoint_Click(object sender, EventArgs e)
    {
      txtConsole.Text = "Wait ...";
      var result = _endpointCommandSender.SendCommandToServerEndpoint(txtCommand.Text);
      txtConsole.Text = result.ToString();
    }
```
In order to use more sophisticated behavior we recommend use attribute <b>ConfigurationDialogProviderAttribute</b> with own implementation of <b>IEndpointConfigurationDialogProvider</b> interface.

<div id='id-ui-components-status-control'/>

* ### Status Control
Procontel.Sdk provide few features:
- <b>send command to endpoint,</b>
- <b>send notification from endpoint to frontend (push notification)</b>
- <b>read/write storage for current running machine</b>
- <b>use endpoint authorization/authentication mechanism</b>
- <b>send files from status control to endpoint</b>

Supported fronted framework:
 - Wpf
 - WinForms

To define Configuration UI Element binding endpoint has to be decorate with attribute <b>StatusControlAttribute</b>. User control type should be put as a attribute constructor parameter.

```csharp
  [StatusControl(typeof(WpfStatusControl), EndpointStatusControlType.Wpf)]
  [EndpointMetadata(Name = "WpfStatus", SupportedRoles = SupportedRoles.None)]
  public class WpfStatusEndpoint : ICommandHandler
  {
    private readonly ILogger _logger;
    private readonly IRuntimeContext _runtimeContext;
    public WpfStatusEndpoint(ILogger logger, IRuntimeContext runtimeContext)
    {
      _logger = logger;
      _runtimeContext = runtimeContext;
    }

    public Task<object> HandleCommandAsync(object command, ICorrelationContext context = null)
    {
      _logger.Information($"Received command from status control {command}");
      switch (command)
      {
        case "dowork": _logger.Information($"Let's do some work!"); break;
        case "notify": _runtimeContext.NotificationService.NotifyUI($"Notify from { _runtimeContext.MetadataContext.Caption} ", false); break;
        default: throw new NotSupportedException($"Command {command} is not supported.");
      }
      return Task.FromResult<object>("Done");
    }
  }
```
Status control has to implement interface <b>IEndpointStatusControl</b>.

```csharp
  public partial class WpfStatusControl : UserControl, IEndpointStatusControl
  {
    private readonly IEndpointCommandSender _sender;
    public WpfStatusControl() => InitializeComponent();
    public WpfStatusControl(IEndpointCommandSender sender) : this() => _sender = sender;

    public void DisplayStatus(object statusInformation)
    {
      if (statusInformation != null)
      {
        txtNotifications.Text = txtNotifications.Text.Insert(0, $"{DateTime.Now.ToString("HH:mm:ss")} {statusInformation.ToString()}{Environment.NewLine}");
      }
    }

    public void OnStatusControlHidden() { }
    public void OnStatusControlShown() { }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      txtConsole.Text = "Running...";
      try
      {
        var result = _sender.SendCommandToServerEndpoint(txtCommand.Text);
        txtConsole.Text = result.ToString();
      }
      catch (Exception ex)
      {
        txtConsole.Text = $"Something goes wrong. {ex.Message}";
      }
    }
```

In order to use more sophisticated behavior we recommend use attribute <b>StatusControlProviderAttribute</b> with own implementation of <b>IEndpointStatusControlProvider</b> interface.

<div id='id-ui-custom-menu-items' />

* ### Custom Menu Items
Procontel.Sdk provide feature for endpoint to have own custom menu item, with own icon and list of children item.

Supported fronted framework:
 - Wpf
 - WinForms

To define Custom Menu Items binding endpoint has to be decorate with attribute <b>MenuItemAttribute</b>. Children items action type should be put as a attribute constructor parameter.

```csharp
[EndpointMetadata(Name = "Custom Menu Items", SupportedRoles = SupportedRoles.Both)]
[MenuItem("1", "Items")]
[MenuItem("2", "1", "MenuItem1", typeof(MenuItemAction))]
[MenuItem("3", "1", "MenuItem2", typeof(MenuItemAction))]
public class MenuItemsEndpoint
{
  public MenuItemsEndpoint()
  {
  }
}

```

Item action has to implement interface <b>IMenuItemAction</b>.

```csharp
public class MenuItemAction : IMenuItemAction
{
  private readonly IConfigurationReader reader;
  private readonly IConfigurationWriter writer;
  private readonly IEndpointCommandSender sender;
  private readonly IMetadataContext metadataContext;
  private readonly IMenuItemCommand command;

  public MenuItemAction(IConfigurationReader reader, IConfigurationWriter writer, IEndpointCommandSender sender, IMetadataContext metadataContext, IMenuItemCommand command)
  {
    this.reader = reader;
    this.writer = writer;
    this.sender = sender;
    this.metadataContext = metadataContext;
    this.command = command;
  }
  public Task ExecuteAsync()
  {
    new MyDialog(writer, reader).ShowDialog();

    return Task.CompletedTask;
  }
}
```


<div id='id-injected-services-ui-components' />

## 11. Injected services for ui components

ProconTEL environment provide set of features available via dependency injection. To use this mechanism developer has to use appropriate interface in control or provider constructor. In ProconTEL naming conventions this interfaces called <b>services</b>.

<div id='id-ui-components-injected-services-iconfiguration-writer'/>

* ### IConfigurationWriter
Service providing possibility to store endpoint configuration. <b>Available only in confguration dialog.</b>

```csharp
public partial class ConfigurationDialog : Form
{
  private readonly IConfigurationReader _configurationReader;
  private readonly IConfigurationWriter _configurationWriter;

  public ConfigurationDialog()
  {
    InitializeComponent();
  }

  public ConfigurationDialog(IConfigurationReader configurationReader, IConfigurationWriter configurationWriter)
    : this()
  {
    _configurationWriter = configurationWriter;
    _configurationReader = configurationReader;
    txtAdress.Text = _configurationReader.GetConfiguration();
  }

  private void SaveConfiguration_Click(object sender, EventArgs e)
  {
    _configurationWriter.SaveConfiguration(textBox1.Text);
    DialogResult = DialogResult.OK;
  }
}
```

<div id='id-ui-components-injected-services-ilocal-storage'/>

* ### ILocalStorage
Service provide read/write storage for current running machine.

```csharp
public partial class WpfStatusControl : UserControl, IEndpointStatusControl
{
    private readonly ILocalStorage _localStorage;
    public WpfStatusControl() => InitializeComponent();
    public WpfStatusControl(ILocalStorage localStorage) : this()
    {
        _localStorage = localStorage;
    }

    public void DisplayStatus(object statusInformation){}

    public void OnStatusControlHidden(){}

    public void OnStatusControlShown()
    {
        var theme = _localStorage.ReadValue<object>("theme");
        cbxTheme.SelectedItem = cbxTheme.Items.OfType<ComboBoxItem>().SingleOrDefault(x => x.Content.Equals(theme));
    }

    private void cbxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cbxTheme.SelectedItem is ComboBoxItem item)
        {
            _localStorage.WriteValue("theme", item.Content);
        }
    }
}
```

<div id='id-ui-components-injected-services-isecurity-service'/>

* ### ISecurityService
Service provide usage of security mechanism hosted by Authorization/Authentication endpoint.

```csharp
public partial class WpfStatusControl : UserControl, IEndpointStatusControl
{
    private readonly ISecurityService _securityService;
    public WpfStatusControl() => InitializeComponent();
    public WpfStatusControl(ISecurityService securityService) : this() => _securityService = securityService;

    public void DisplayStatus(object statusInformation) { }
    public void OnStatusControlHidden() { }
    public void OnStatusControlShown() { }

    public void Logout(object sender, System.Windows.RoutedEventArgs e)
    {
        _securityService.SignOut();
    }

    public void Login(object sender, System.Windows.RoutedEventArgs e)
    {
        var isAdministrator = false;
        var authorized = _securityService.Authenticate(hashLoginAndPassword);
        if (authorized)
        {
            isAdministrator = _securityService.IsInRole("administrator");
        }
    }
}
```

<div id='id-ui-components-injected-services-ifileuploaderservice'/>

### IFileUploaderService
Service providing functionality of uploading files to endpoint backend server from client (configuration dialog or status control).

```csharp
public partial class FileUploadConfigurationDialog : Form
{
  private readonly IFileUploaderService _fileTransfer;

  public FileUploadConfigurationDialog()
  {
    InitializeComponent();
  }

  public FileUploadConfigurationDialog(IFileUploaderService fileTransfer) : this()
  {
    _fileTransfer = fileTransfer;
  }

  private async void btnUpload_Click(object sender, EventArgs e)
  {
    var result = openFileDialog1.ShowDialog();
    if(result == DialogResult.OK)
    {
      await _fileTransfer.UploadFilesAsync(new[] { new FileDescriptor() { Location = openFileDialog1.FileName } });

    }
    DialogResult = DialogResult.OK;
  }
}
```
<div id='id-ui-components-injected-services-ivirtualfilesystem'/>

### IVirtualFileSystem

Service provides information about the roots, folders and files available on the server (configuration or status control dialog).


```csharp
public interface IVirtualFileSystem
{
  /// Returns name of referencing file system.
  Task<string> GetFileSystemNameAsync();
  /// Returns an array of roots existing in referencing file 
  Task<IRootInfo[]> GetRootsAsync();
  /// Returns an array of directories existing in referencing file system.
  Task<IVirtualDirectoryInfo[]> GetDirectoriesAsync(IVirtualDirectoryInfo parent);
  /// Returns an array of files existing in referencing file system.
  Task<IVirtualFileInfo[]> GetFilesAsync(IVirtualDirectoryInfo parent, 
  string pattern);
  /// Returns whether a file under specified path exists.
  Task<bool> FileExistsAsync(string path);
  /// Returns whether a directory under specified path exists.
  Task<bool> DirectoryExistsAsync(string path);
  /// Creates directory.
  Task<bool> CreateDirectoryAsync(string path);
}

```

```csharp
public partial class VirtualFileSystemStatusControl : UserControl, IEndpointStatusControl
{
  private readonly IVirtualFileSystem _virtualFileSystem;
  public VirtualFileSystemStatusControl()
  {
    InitializeComponent();
  }
  public VirtualFileSystemStatusControl(IVirtualFileSystem virtualFileSystem, IRootInfo[] rootInfo) : this()
  {
    _virtualFileSystem = virtualFileSystem;
  }
  public void OnStatusControlHidden(){}

  public void OnStatusControlShown(){}

  public async void DisplayStatus(object statusInformation)
  {
    string filePath = @"C:\testDirectory\test.txt";
    string directoryPath = @"c:\testDirectory";
    var roots = await _virtualFileSystem.GetRootsAsync();
  }
}
```


<div id='id-ui-components-injected-istreamingservice'/>

* ### Streaming
See [IStreamingService](#id-injected-services-istreamingservice-context)


<div id='id-ioc'/>

## 12. IoC

ProconTEL engine offers access to implementation of internal services. Described mechanism is deliver by service <b>IServiceContext</b>.


<div id='id-middlewares'/>

## 13. Middlewares

ProconTEL engine offers dynamic configuration for input messages pipeline. Described mechanism is deliver in `IEndpointLifeTimeCycle.InitializeAsync(IMiddlewareBuilder)` method parameter. `IMiddlewareBuilder` allows registration of custom middlewares inside ProconTEL messages pipeline. It is possible to combine it with already exisiting ProconTEL built-in middlewares or completly replace ProconTEL built-in functionality. Complete list of possible registration options is shown below.

```csharp
  public interface IMiddlewareBuilder
  {
    IMiddlewareBuilder UseMiddleware(Func<IMiddlewareRequest, Func<Task>, Task> middleware);
    IMiddlewareBuilder UseMiddleware(Type middleware);
    IMiddlewareBuilder UseMiddleware<TMiddleware>();
    bool HasMiddlewares { get; }
    MiddlewareRequestDelegate Build();
    void Reset();

    IMiddlewareBuilder UseDefaultDeserializeMetadataMiddleware();
    IMiddlewareBuilder UseDefaultDeserializeMiddleware();
    IMiddlewareBuilder UseDefaultProcessMiddleware();
    IMiddlewareBuilder UseDefaultAcknowledgementMiddleware();
  }
```

### Example: adding interceptor middleware

Below example shows how to add additional middleware into existing in ProconTEL. Notice, method `next()` is necessary in each middleware. In code example you see additional logging added before and after message will be processed in `IHandler.HandleAsync()` method.

```csharp
public async Task InitializeAsync(IMiddlewareBuilder builder)
{
  builder.UseDefaultDeserializeMiddleware();
  builder.UseDefaultDeserializeMetadataMiddleware();
  builder.UseMiddleware(async (request, next) =>
  {
    _logger.Information($"Before processing message {request.Content.ContentId} by endpoint.");
    await next();
  });
  builder.UseDefaultProcessMiddleware();
  builder.UseMiddleware(async (request, next) =>
  {
    _logger.Information($"After processing message {request.Content.ContentId} by endpoint.");
    await next();
  });
  builder.UseDefaultAcknowledgementMiddleware();

  return;
}
```

### Example: replace ProconTEL built-in middlewares

Below example shows how to completely replace ProconTEL built-in middlewares. Notice, that still method `next()` is necessary. Code example, stores all incoming messages into database and because there is no other middleware registered, handling will be finished.

```csharp
public async Task InitializeAsync(IMiddlewareBuilder builder)
{
  builder.UseMiddleware(async (request, next) =>
  {
    try
    {
      var entity = new MessageEntity()
      {
        MessageId = request.Content.ContentId,
        Content = request.Content.SerializedContent,
        ProtocolId = request.Content.ProtocolId,
        Metadata = request.Content.SerializedMetadata,
      };
      await _databaseService.StoreAsync(entity);
    }
    catch (Exception ex)
    {
      _logger.Error($"Unable to store message with ID {request.Content.ContentId} in database.", ex);
    }
    await next();
  });

  _databaseService.Connect();
  if (!_databaseService.IsStorageTableAvailable())
    throw new Exception("Database table is not available.");

  return;
}
```


<div id='id-legacy-sdk'/>

## 14. Legacy Sdk

### Migration

For those who are familiar with previous ProconTEL SDK it's obvious that new SDK is breaking the compatibility. However, in order to make the migration less painfull we created _Legacy SDK_ which is build on new SDK, but preserves the old SDK conventions, names, classes (at least to some degree).

In order to migrate to Legacy SDK perform following steps:
* remove all existing ProconTEL reference
* install ProconTEL Legacy SDK nuget package
* replace:
  - `Endpoint` attribute with `EndpointMetadata` and add `using ProconTel.Sdk.Attributes;`, 
  - `using ProconTel.CommunicationCenter.Kernel;` with `using ProconTel.Sdk.Legacy;`
* generate `ctor` and pass all necessary parameters to base `ctor`, add `using ProconTel.Sdk.Services;` example
  ```csharp
  using ProconTel.Sdk.Services;

  public Endpoint(IMessageBus messageBus, ILogger logger, IRuntimeContext runtimeContext, IConfigurationReader configurationReader, 
    INotificationService notificationService, IReportService reportService)
    : base(messageBus, logger, runtimeContext, configurationReader, notificationService, reportService)
  {
  }
  ```

* add status control to endpoints:
  - add `using ProconTel.Sdk.UI.Attributes;` and `using ProconTel.Sdk.UI.Models;`
  - add `StatusControl` attribute to endpoints, example 
    ```csharp
    [StatusControl(typeof(StatusControl), EndpointStatusControlType.WinForms)]
    ```
  - remove `HasStatusControl` and `GetStatusControl` methods in status control class
  - add `using ProconTel.Sdk.UI.Models;`
  - remove `IEndpointStatusController Context` property
  - extend `ctor` with new parameter `IEndpointCommandSender`, example
    ```csharp
    private readonly IEndpointCommandSender _sender;
    public StatusControl(IEndpointCommandSender sender)
    {
      InitializeComponent();
      _sender = sender;
    }
    ```
  - replace `IEndpointStatusControl` methods with async version, example
    ```csharp
    public Task OnStatusControlHiddenAsync()
    {
      return Task.CompletedTask;
    }
    ```

* add configuration control to endpoints:
  - add `using ProconTel.Sdk.UI.Services;` and `using ProconTel.Sdk.UI.Models;`
  - add `ConfigurationDialog` attribute to endpoints, example
    ```csharp 
    [ConfigurationDialog(typeof(ConfigurationControl))]
    ```
  - remove `HasConfigurationControl` and `GetConfigurationControl` methods

* use new `_sender` variable instead of `Context` 
* when using `XmlProtocol` or `BinaryProtocol` install ProconTEL StandardEndpoints SDK nuget package
* add reference to `using ProconTel.Sdk.StandardEndpoints;` where it's necessar
* when using `ProconTel.Security.EndpointSecurity` class, make the necessary modifications described below:
  - Replace `IStatusDialogControler` with `IEndpointStatusControl`
  - Replace `EndpointSecurity` with `ISecurityService`

### Features
All features from Sdk which requires using attributes (i.e. Custom Menu Items) or can be used only in ui context (i.e. IVirtualFileSystem, ) are available for Sdk Legacy too.

### Features
All features from Sdk which requires using attributes (i.e. Custom Menu Items) or can be used only in ui context (i.e. IVirtualFileSystem, ) are available for Sdk Legacy too.  

<div id='id-testing'/>

## 15. Testing

<div id='id-deployment'/>

## 16. Deployment

<div id='id-deployment-github'/>

* ### Github
```csharp

```

<div id='id-deployment-gitlab'/>

* ### GitLab
```csharp

```
