---
Title: "ProconTEL SDK"
github_url: "https://github.com/Macrix/procontel.sdk/edit/master/README.md"
Weight: 8
Description: >
  Learn how to use the ProconTEL SDK
---

## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Compatibility matrix](#id-compatibility-matrix)
3. [SDK major changes](#id-sdk-major-changes)
4. [Builder blocks](#id-builder-blocks)
	* [IEndpointLifeTimeCycle](#id-builder-blocks-ilife-time-cycle)
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
5. [Injected services](#id-injected-services)
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
6. [Providers](#id-providers)
	  * [IMessageMetadataProvider](#id-providers-imessage-metadata-provider)
7. [Attributes](#id-attributes)
	  * [EndpointMetadata Attribute](#id-attributes-endpoint-metadata)
    * [MessageMetadata Attribute](#id-attributes-message-metadata)
    * [MessageMetadataProvider Attribute](#id-attributes-message-metadata-provider)
8. [Advanced concepts](#id-advanced-concepts)
    * [Supported protocols](#id-advanced-concepts-protocols)
    * [Persistent messages](#id-advanced-concepts-persistent-messages)
9. [UI Components](#id-ui-components)
    * [Configuration Dialog](#id-ui-components-configuration-dialog)
    * [Status Control](#id-ui-components-status-control)
    * [Updating a status of control](#id-ui-update-status-control)
    * [Custom Menu Items](#id-ui-custom-menu-items)
10. [Injected services for UI Components](#id-injected-services-ui-components)
    * [IConfigurationWriter](#id-ui-components-injected-services-iconfiguration-writer)
    * [ILocalStorage](#id-ui-components-injected-services-ilocal-storage)
    * [ISecurityService](#id-ui-components-injected-services-isecurity-service)
    * [IFileUploaderService](#id-ui-components-injected-services-ifileuploaderservice)
    * [IVirtualFileSystem](#id-ui-components-injected-services-ivirtualfilesystem)
    * [Streaming](#id-ui-components-injected-istreamingservice)
11. [IoC](#id-ioc)
12. [Middlewares](#id-middlewares)
13. [Legacy Sdk](#id-legacy-sdk)
14. [Standard Endpoints](#id-standard-endpoints)



<div id='id-quick-introduction'/>

## 1. Quick introduction

`ProconTEL.Sdk` is a modern .NET Standard SDK for porting your business logic with [ProconTEL](http://procontel.com/) environment. The modular design and middleware oriented architecture makes the endpoint highly customizable while providing sensible default for topology, communication and extensions. Documentation for version 1.x is currently available under [`docs`](https://macrix.eu/).

<div id='id-compatibility-matrix'/>

## 2. Compatibility matrix
As SDK version may change, we provide SDK compatibility matrix which shows which SDK versions is supported by which *ProconTEL Engine*.
| *ProconTEL SDK* version  | *ProconTEL Engine* major version(s) | 
| :---:  |:---:|
| 1.0.7-preview1 | 3.4.1 |
| 1.0.6 | 3.4.0 RC |
| 1.0.5 | 3.0.17 - 3.3.8 |
| 1.0.4 | 3.0.16 |
| 1.0.3 | 3.0.15 |
| 1.0.2 | 3.0.13 - 3.0.14 |
| 1.0.1 | 3.0.11 - 3.0.12 |
| 1.0.0 | 3.0.9 - 3.0.10 |
| 0.11.0 | 3.0.8 |
| 0.10.0 | 3.0.7 |
| 0.9.0 | 3.0.6 |
| 0.8.0 | 3.0.5 |
| 0.7.0 | 3.0.4 |
| 0.6.0 | 3.0.3 |
| 0.5.0 | 3.0.2 |

<div id='id-feature-comparison'/>

## 3. SDK major changes

### SDK 1.0.7-preview1
| Task ID | Topic | Changes |
| :---|:---|:---|
| PS-1223 | IReportService | Changed the type of endpointId from string to GuidId |
| PS-1420 | WCF Encription | Merged all security features implemented in version 3.3.8.5 |

### SDK 1.0.6
| Task ID | Topic | Changes |
| :---|:---|:---|
| PS-1230 | Legacy.Logging.Logger | Added possibility to set an instance inside the endpoint created in the new SDK |
| PS-1254 | ICommandHandler | Added TaskCanceledException handling in HandleCommandAsync when the function returns null |

<div id='id-builder-blocks'/>

## 4. Builder blocks

<div id='id-builder-blocks-ilife-time-cycle'/>

* ### IEndpointLifeTimeCycle
A endpoint has a lifecycle managed by ProconTEL. ProconTEL.Sdk offers interface `IEndpointLifeTimeCycle` that provide visibility into these key life moments and the ability to act when they occur. It also allows customization of default ProconTEL input pipeline for receiving messages. For more information see [Middlewares](#id-middlewares).
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

    public Task AfterActivateAsync()
    {
      _logger.Information("After Activate");
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

`IHandler` is common communication interface which provide receiving data from another endpoint. We can filter incoming messages by implement method `IHandler.CanHandle`. 
Asynchronous method `HandleAsync` is responsible for processing data. <b>This execution is a blocking call (synchronous).</b> No execution will take place on the current thread until current processing returns some acknowledgement. <b>We will not process new messages until the current processing is completed.</b>
We support few acknowledgement types : Ack, Retry, Reject. Handler implementation has to return acknowledgement (mandatory), but sender can ignore it (obligatory).

```csharp
  [EndpointMetadata(Name = "Handler", SupportedRoles = SupportedRoles.Subscriber)]
  [DefaultProtocol]
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
Interface `ICommandHandler` support handling messages from Status Control Component. Processing approach is similar like in [IHandler](#id-builder-blocks-ihandler).

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

Interface `IConfigurationCommandHandler` support handling messages from Configuration Dialog Component. Configuration Command Handler mechanism will soon be deprecated.

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

Interface `IOnlineConfigurationUpdate` support observe configuration changed notification. To read current configuration version use `IConfigurationReader` service injection.

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

Interface `IOnlineUpgradeLifetimeCycle` support visibility into upgrade plugin process and the ability to act when they occur.
The plugin has to possess a .NET strong name(add key.snk to your soultion).

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

`IAvatarInsight` is an interface that allows to handle avatar connection and disconnection events in avatar source endpoint.

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

Interface `IFileHandler` allows handling of uploaded files from client to server backend.

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

Interface `IAuthorization` provide authorization mechanism.

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

Interface `IAuthentication` provide authentication mechanism.

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

Interface `IExportable` is used to save some custom files in exported pex file. Method `ImportContentDirectoryAsync` should be used to recreate stored files to disk, method `ExportContentDirectoryAsync` for serialize files into byte array that will be stored in pex file. 

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

In some cases endpoint can ask for messages that were delivered, but not acknowledged. Handling that event can be done by `IRequestMissedContent` interface.

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

In some cases endpoint can ask for last sent messages in channel, to handle that event `IRequestLastContent` was introduced.

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

## 5. Injected services

ProconTEL environment provide set of features available via dependency injection. To use this mechanism developer has to use appropriate interface in endpoint constructor. In ProconTEL naming conventions these interfaces are called <b>services</b>.

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

Service provide allows access to implementation of internal services registred by ProconTEL Engine and registered by endpoint. For more details see [IoC](#id-ioc).

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

## 6. Providers

<div id='id-providers-imessage-metadata-provider'/>

* ### IMessageMetadataProvider

Interface `IMessageMetadataProvider` provide mechanism to define runtime mutable list of sending message metadata. However, this provider should be used only in case when list of provided messages can be obtined only in runtime. In all other cases, [`MessageMetadata` attribute](#id-attributes-message-metadata) should be used, to declare provided messages in a static way.

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

## 7. Attributes

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

`MessageMetadata` attribute is used to declare an information about single message that might be provided by endpoint. Multiple attributes can be used. Using `MessageMetadata` attribute is the recommended way of declaring information about messages provided by endpoint.

This is simple example how we can decorate endpoint class as provider of message with ID `message_id`.
```csharp
[MessageMetadata("message_id", "Message caption")]
[EndpointMetadataAttribute(Name = "Empty", SupportedRoles = SupportedRoles.Both)]
public class EmptyEndpoint
{
}
```

<div id='id-attributes-message-metadata-provider' />

* ### MessageMetadataProvider Attribute 

In case when it is not possible to declare type of message IDs provided by endpoint in a declarative way, `MessageMetadataProvider` attribute can be used. It allows to define a provider which can execute a custom code to obtain the list of provided messages. However, it is possible to use `MessageMetadataProvider` it should be used only when required in favor of `MessageMetadata` attribute.

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

## 8. Advanced concepts

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

## 9. UI Components

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
      var result = _endpointCommandSender.SendCommandAsync(txtCommand.Text);
      txtConsole.Text = (result as Task<object>).Result.ToString();
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

<div id='id-ui-update-status-control' />

* ### Updating a status of control

In many cases status control can pretend to work with a delay or be not responding at all, this is connected with a way of calling updates on the endpoint side. To update status control we are using <b>NotifyUI</b> method which is only a facade for WCF update status methods. To make it more sufficient, there is a tool called <b>SmartMethodInvoker</b> which is helping to manage all calls.

The <b>SmartMethodInvoker</b> is a tool which registers all calls and runs them in the background task. The way of execution depends on <b>InvokePolicy</b> settings, there are two options <b>InvokeIfNotBusy</b> and <b>InvokeAlways</b>. The type of policy is passed in constructor and is immutable during object life. All synchronization work is done in the background.

In <b>InvokeIfNotBusy</b> mode of invocation all registered methods are stored in dictionary, the value is just a method itself and the key is given during registration. In the meantime, the background task is executing all registered methods in a few steps. The first step is to take all available (already registered) methods. The second one is about calling all of them one by one. The last step is to wait a given period of time before it starts the whole process again from the first step. Because only executing task is waiting and registration is available at this time, there is possibility to register a new bunch of methods. It also means that some of them can be replaced without being called in case of usage of the same key many times.

In <b>InvokeAlways</b> mode the methods are registered in a queue, so there is no chance to replace anything, it also means that all of the registered methods have to be executed eventually. In this case, background task is executing methods one by one without any waiting.

The <b>UpdateStatusControl</b> is using both of the <b>SmartMethodInvoker</b> modes, the indicator is a flag <b>ensureDelivery</b>. It basically means that if the flag is set to true, the InvokeAlways policy is used, and the <b>InvokeIfNotBusy</b> in opposite case. The standard delay in <b>InvokeIfNotBusy</b> mode can be changed in <b>ServerConfigurationManager</b> in section <b>Administration Service</b> in field <b>Callback Delay</b>.

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

## 10. Injected services for UI components

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
Data stored by this interface can be found in 
```
...\AppData\Local\Macrix\ProconTEL\{Version Number}\EndpointStatus
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

## 11. IoC

ProconTEL Engine offers access to implementation of internal services. Described mechanism is deliver by service `IServiceContext` and allows to resolve any service that was previosly registered. What is also possible is that endpoint can register it's own custom services. This is possible by implementing a static method in endpoint class with following signature `Configure(IApplicationBuilder)`.

Service `IApplicationBuilder` allows registering custom services implementation under specified interfaces. It is possible to register service to be resolved to just one single instance with method `IApplicationBuilder.UseInstance<TImplementation>(TImplementation)` or `IApplicationBuilder.UseInstance<TImplementation, TInterface>(TImplementation)`.

Example belows shows how to register custom service into ProconTEL IoC and resolve it along with other ProconTEL services.

```csharp
[EndpointMetadata(Name = "Example IoC endpoint", SupportedRoles = SupportedRoles.Provider)]
public class ExampleIoCEndpoint
{
  public static void Configure(IApplicationBuilder builder)
  {
    builder.Use<DatabaseService, IDatabaseReaderService>();
    builder.Use<ConfigurationDeserializer, IConfigurationDeserializer>();
  }

  private readonly ILogger _logger;
  private readonly IDatabaseReaderService _databaseService;

  // let ProocnTEL IoC resolve required services including custom ones
  public ExampleIoCEndpoint(ILogger logger, IDatabaseReaderService databaseService)
  {
    _logger = logger;
    _databaseService = databaseService;
  }
}

class DatabaseService : IDatabaseReaderService
{
  private readonly ILogger _logger;
  private readonly IDatabaseServiceConfiguration _configuration;

  // let ProocnTEL IoC resolve required services for custom service
  public DatabaseService(IConfigurationDeserializer configurationDeserializer, ILogger logger)
  {
    _logger = logger;
    _configuration = configurationDeserializer.Get<DatabaseAccessConfiguration, IDatabaseServiceConfiguration>();
    
    // TODO: establish database connection based on parameters from configuration
  }
}

public class ConfigurationDeserializer : IConfigurationDeserializer
{
  private readonly IConfigurationReader _reader;

  // let ProocnTEL IoC resolve required services for custom service
  public ConfigurationDeserializer(IConfigurationReader reader) => _reader = reader;
}

```

Service `IServiceContext` can be also very useful in scenario where developers would like to use their own IoC framework or when they are forced to use one, like provided by [AspNetCore DI](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0). Example below shows how to combine _AspNetCore DI_ with _ProconTEL IoC_ by registering ProconTEL `ILogger` inside _AspNetCore DI_.

```csharp
public class ExampleWebEndpoint : IEndpointLifeTimeCycle, IHandler
{
  private IWebHost _host;
  private readonly IServiceContext _ctx;

  public ExampleWebEndpoint(IServiceContext ctx)
  {
    _ctx = ctx;
  }

  public Task InitializeAsync(IMiddlewareBuilder builder)
  {
    _host =
      Microsoft.AspNetCore.WebHost.CreateDefaultBuilder()
        .ConfigureServices(ioc =>
        {
          ioc.AddTransient(ctx => ctx.GetService<IServiceContext>().Resolve<Func<ProconTel.Sdk.Services.ILogger>>()());
        })
        .UseStartup<Startup>()
        .Build();

    return _host.StartAsync();
  }
}
```
More information about `IServiceContext` can be found in [injected services chapter](#id-injected-services-iservice-context)


<div id='id-middlewares'/>

## 12. Middlewares

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

## 13. Legacy Sdk

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
  - add reference to `using ProconTel.Sdk.StandardEndpoints;` where it's necessary
* when using `ProconTel.Security.EndpointSecurity` class, make the necessary modifications described below:
  - Replace `IStatusDialogControler` with `IEndpointStatusControl`
  - Replace `EndpointSecurity` with `ISecurityService`

### Features
All features from Sdk which requires using attributes (i.e. Custom Menu Items) or can be used only in UI context (i.e. IVirtualFileSystem) are available for SDK Legacy too.


<div id='id-standard-endpoints'/>

## 14. Standard Endpoints

This section describes how to receive and send telegrams that are processed by _ProconTEL Standard Endpoints_.

All custom definitions that are required to work with telegrams and _ProconTEL Standard Endpoints_ can be found in assembly/nuget package called `ProconTel.Sdk.StandardEndpoints`. Use this package instead of direct references to old SDK like `ProconTel.CommunicationCenter.Kernel`.

### Complete example

In the samples you can find a complete example of [receiving](samples/TelegramHandling/TelegramHandlingEndpoints/TelegramReceiverEndpoint.cs) and [sending](samples/TelegramHandling/TelegramHandlingEndpoints/TelegramSenderEndpoint.cs) telegrams using custom endpoints written using ProconTEL SDK. Example consits of 3 parts:
* [Telegram definitions](samples/TelegramHandling/TelegramDefinitions) project with Excel, _Developer Studio_ project file and C# telegram classes
* [Example telegram receiver](samples/TelegramHandling/TelegramHandlingEndpoints/TelegramReceiverEndpoint.cs)
* [Example telegram sender](samples/TelegramHandling/TelegramHandlingEndpoints/TelegramSenderEndpoint.cs)



