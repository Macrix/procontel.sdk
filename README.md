# ProconTEL.Sdk


## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Compatibility matrix](#id-compatibility-matrix)
3. [Feature comparison](#id-feature-comparison)
4. [Builder blocks](#id-builder-blocks)
    1. [EndpointMetadata](#id-builder-blocks-endpoint-metadata)
	  2. [ILifeTimeCycle](#id-builder-blocks-ilife-time-cycle)
    3. [IHandler](#id-builder-blocks-ihandler)
	  4. [IMessageMetadataProvider](#id-builder-blocks-imessage-metadata-provider)
	  5. [ICommandHandler](#id-builder-blocks-icommand-handler)
	  6. [IConfigurationCommandHandler](#id-builder-blocks-iconfiguration-command-handler)
    7. [IOnlineConfigurationUpdate](#id-builder-blocks-ionline-configuration-update)
    8. [IOnlineUpgradeLifetimeCycle](#id-builder-blocks-ionline-upgrade-life-time-cycle)
    9. [IAuthorization](#id-builder-blocks-iauthorization)
    10. [IAuthentication](#id-builder-blocks-iauthentication)
5. [Injected services](#id-injected-services)
    1. [ILogger](#id-injected-services-ilogger)
    2. [IMessageBus](#id-injected-services-imessage-bus)
    3. [IConfigurationReader](#id-injected-services-iconfiguration-reader)
    4. [IRuntimeContext](#id-injected-services-iruntime-context)
    5. [IMetadataContext](#id-injected-services-imetadata-context)
    6. [INotificationService](#id-injected-services-inotification-service)
    7. [IMetricsService](#id-injected-services-imetrics-service)
    8. [IServiceContext](#id-injected-services-iservice-context)
6. [Advanced concepts](#id-advanced-concepts)
    1. [Supported protocols](#id-advanced-concepts-protocols)
    2. [IMessageBus](#id-advanced-concepts-message-bus)
7. [UI Components](#id-ui-components)
    1. [Configuration Dialog](#id-ui-components-configuration-dialog)
    2. [Status Control](#id-ui-components-status-control)
8. [Injected services for UI Components](#id-injected-services-ui-components)
    1. [ILocalStorage](#id-ui-components-injected-services-ilocal-storage)
    2. [ISecurityService](#id-ui-components-injected-services-isecurity-service)
9. [IoC](#id-ioc)
10. [Legacy Sdk](#id-legacy-sdk)
11. [Testing](#id-testing)
12. [Deployment](#id-deployment)
    1. [Github](#id-deployment-github)
    2. [GitLab](#id-deployment-gitlab)

<div id='id-quick-introduction'/>

## 1. Quick introduction

`ProconTEL.Sdk` is a modern .NET Standard SDK for porting your business logic with [ProconTEL](http://procontel.com/) environment. The modular design and middleware oriented architecture makes the endpoint highly customizable while providing sensible default for topology, communication and extensions. Documentation for version 1.x is currently available under [`docs`](https://macrix.eu/).

<div id='id-compatibility-matrix'/>

## 2. Compatibility matrix
As SDK version may change, we provide SDK compatibility matrix which shows which SDK versions is supported by which *ProconTEL Engine*.
| *ProconTEL Engine* version | *ProconTEL SDK* version  | 
| :---:  |:---:|
| 3.0 | 0. |

<div id='id-feature-comparison'/>

## 3. Feature Comparison
Table below lists feature available in *ProconTEL Engine 2.x SDK* and compares it with features available in new SDK under *ProconTEL Engine 3.x*. Features are described with hints as it was available in *Engine 2.x*.
| Feature         | Engine 2.x SDK | SDK 0.4<br>  | SDK 0.5<br>  | SDK 0.6<br>*Current*  | SDK 1.0<br>*Planned* | SDK Legacy 1.0<br>*Planned* |
| :---  |:---:|:---:|:---:|:---:|:---:|:---:|
| Broadcast message                                                                                      | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Send message                                                                                           | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Attach metadata with message when broadcast/send                                                       | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Handle message<br>`SubscriberStrategy.AcceptsContent()`, `SubscriberStrategy.ProcessContent()`         | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Handle metadata information of received message<br>`ContentInfo`                                       | ✓ | - | ✓ | ✓ | ✓ | ✓ |
| Expose details of send/broadcasted messages<br>`ProviderStrategy.ProvidingContentDetails`              | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Expose details of send/broadcasted messages in attribute                                               | - | - | - | - | ✓ | - |
| Handle supported protocols<br>`SubscriberStrategy.SubscribingProtocols`                                | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Acknowledge processed message<br>`SubscriberStrategy.AcknowledgeContent()`                             | ✓ | ✓ | ✓ | ✓ | ✓ | - |
| Automatic acknowledge<br>`SubscriberStrategy.AutomaticContentAcknowledge`                              | ✓ | - | - | - | - | - |
| Life cycle mechanism<br>`ChannelEndpointBase.Initialize()`, `ChannelEndpointBase.Terminate()`          | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| On-line upgrade<br>`ChannelEndpointBase.OnBeforeUpgrade()`, `ChannelEndpointBase.OnAfterUpgrade()`     | ✓ | - | ✓ | ✓ | ✓ | ✓ |
| Reading endpoint configuration<br>`ChannelEndpointBase.GetConfiguration()`                             | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Handle endpoint configuration changes in runtime<br>`ChannelEndpointBase.OnConfigurationUpdated()`     | ✓ | - | - |- | ✓ | ✓ |
| Logger<br>*all `Logger.Debug()`, `Logger.Error()`, etc. methods                                        | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Custom log source location information<br>`ILogMessageOrigin` support                                  | ✓ | - | - |- | - | - |
| Endpoint metadata<br>`ChannelEndpointBase.Id`, `ChannelEndpointBase.CustomId`, etc.                    | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Endpoint type<br>`ChannelEndpointBase.ActsAsProvider`, `ChannelEndpointBase.ActsAsSubscriber`          | ✓ | ✓ | ✓ | ✓ | ✓ |✓ |
| Broadcast/Send stream in endpoint<br>`ChannelEndpointBase.BroadcastContent(Stream, StreamReleaseCallbackHandler)` | ✓ | - | - |- | ✓ | ✓ |
| Handle stream in endpoint                                                                              | ✓ | - | - |- | ✓ | ✓ |
| Send stream to UI status control                                                                       | ✓ | - | ✓ |✓ | ✓ | - |
| Handle stream in UI status control                                                                     | ✓ | - | - | - | ✓ | ✓ |
| Custom actions while endpoint is imported<br>`ChannelEndpointBase.ImportContentDirectory()`            | ✓ | - | - | - | ✓ | ✓ |
| Custom actions while endpoint is exported<br>`ChannelEndpointBase.ExportContentDirectory()`            | ✓ | - | - | - |✓ | ✓ |
| Avatar connected event<br>`ChannelEndpointBase.AvatarConnected()`                                      | ✓ | - | - | **IN PROGRESS** |✓ | ✓ |
| Avatar disconnected event<br>`ChannelEndpointBase.AvatarDisconnected()`                                | ✓ | - | - | **IN PROGRESS** |✓ | ✓ |
| Read and save avatars subscribed messages<br>`SubscriberStrategy.AddSubscribedContent()`               | ✓ | - | - | **IN PROGRESS** |✓ | ✓ |
| ~~Read/save avatars configuration<br>`IEndpointConfigurationController.GetAvatarConfiguration()`~~     | ✓ | - | - | - | - | - |
| Report custom warning<br>`ICommunicationChannel.ReportEndpointWarning()`                               | ✓ | - | - | - | ✓ | ✓ |
| Clear custom warning<br>`ICommunicationChannel.ClearEndpointWarnings()`                                | ✓ | - | - | - | ✓ | ✓ |
| `RequestLastContent()`                                                                                 | ✓ | - | - | **IN PROGRESS** |✓ | ✓ |
| `RequestMissedContents()`                                                                              | ✓ | - | - | **IN PROGRESS** | ✓ | ✓ |
| Configuration dialog (WinForms)                                                                        | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Read and store endpoint configuration in conf. dialog                                                  | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Send command from conf. dialog<br>`SendCommandToServerEndpoint()`                                      | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Access remote file system from conf. dialog                                                            | ✓ | - | ✓ | ✓ | ✓ | ✓ |
| Send files from conf. dialog                                                                           | ✓ | - | ✓ | ✓ | ✓ | ✓ |
| Conf. dialog available while endpoint is active                                                        | ✓ | - | ✓ | ✓ | ✓ | ✓ |
| Endpoint status control (WinForms, WPF)                                                                | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Send command from status control<br>`SendCommandToServerEndpoint()`                                    | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Notification from endpoint to status control                                                           | ✓ | ✓ | ✓ | ✓ | ✓ | ✓ |
| Send files from status control                                                                         | ✓ | - | - | **IN PROGRESS** | ✓ | ✓ |
| Access remote file system from statuc control                                                          | ✓ | - | - | **IN PROGRESS** | ✓ | ✓ |
| State manager for status control                                                                       | ✓ | - | - | **IN PROGRESS** | ✓ | ✓ |
| Custom menu items (exposed in *Communication Console*)                                                 | ✓ | - | - | - | ✓ | ✓ |
| `IAuthenticationEndpoint`                                                                              | ✓ | - | - | **IN PROGRESS** | ✓ | ✓ |
| `IAuthorizationEndpoint`                                                                               | ✓ | - | - | **IN PROGRESS** | ✓ | ✓ |
| Custom queues definitions                                                                              | ✓ | - | - | - | - | - |
| Override services implementation                                                                       | - | - | - | - | ✓ | - |
| Asynchronous methods (`async`)                                                                         | - | - | - | - | ✓ | - |
| ~~After initialization method `AfterActivate()`~~                                                      | ✓ | - | - | - | - | ✓ |
| ~~Information about other endpoints available in channel<br>`ChannelSubscriberDetails`, `ChannelProviderDetails`, `ChannelProviderContentDetails`, `ChannelSubscriberIds`, `ChannelProviderIds`~~ | ✓ | - | - | - | - | - |
| ~~Custom endpoint remove confirmation dialog<br>`ChannelEndpointBase.GetRemoveConfirmationDialog()`~~  | ✓ | - | - | - | - | - |
| ~~Divide/merge configuration when endpoint is moved, split (avatar + endpoint) or merged (remove avatar and replace with endpoint from pool)~~ | ✓ | - | - | - | - | - |

<div id='id-builder-blocks'/>

## 4. Builder blocks

To create endpoint we need to decorate C# class with the `EndpointMetadata` attribute. To keep ProconTEL environment clear we strongly recommended to use self describing property `Name` in attribute. `ProconTEL.Sdk` delivers builder blocks which gives developer possibilities to extend endpoint functionality. To use builder block endpoint has to implement one of interfaces. Each interface represents endpoint behavior and it can be mixed freely. `EndpointMetadata` contains property `SupportedRoles` which is promise of endpoint communication posobilities.

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

    public void ConfigurationChanged() => _logger.Information($"Configuration was changed. Current values: {_configurationReader.GetConfiguration()})");
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
    public bool CanUpgrade() => true;

    public void UpgradeFinished() => _logger.Information($"Update endpoint finished (id: {_runtimeContext.MetadataContext.Id})");
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

<div id='id-injected-services'/>

## 5. Injected services

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

    public RichEndpint(
      ILogger logger,
      IMessageBus messageBus,
      IConfigurationReader configurationReader,
      IRuntimeContext runtimeContext,
      IServiceContext serviceContext)
    {
      _logger = logger;
      _messageBus = messageBus;
      _configurationReader = configurationReader;
      _runtimeContext = runtimeContext;
      _serviceContext = serviceContext;
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

<div id='id-advanced-concepts'/>

## 6. Advanced concepts

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

<div id='id-ui-components'/>

## 7. UI Components

We are able to bind and communicate user interface to hosted business logic.

<div id='id-ui-components-configuration-dialog'/>
 
* ### Configuration Dialog
Procontel.Sdk provide few features:
- <b>read endpoint configuration,</b>
- <b>write endpoint configuration,</b>
- <b>send command to deactivated endpoint (does not have full access to endpoint resource )</b>

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

<div id='id-ui-components-status-control'/>

* ### Status Control
Procontel.Sdk provide few features:
- <b>send command to endpoint,</b>
- <b>send notification from endpoint to frontend (push notification)</b>
- <b>read/write storage for current running machine</b>
- <b>use endpoint authorization/authentication mechanism</b>

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

<div id='id-injected-services-ui-components' />

## 8. Injected services for ui components

ProconTEL environment provide set of features available via dependency injection. To use this mechanism developer has to use appropriate interface in control or provider constructor. In ProconTEL naming conventions this interfaces called <b>services</b>.

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
          var authorized = _securityService.Authenticate(hashLoginAdpassword);
          if (authorized)
          {
              isAdministrator = _securityService.IsInRole("administrator");
          }
      }
  }
```

<div id='id-ioc'/>

## 9. IoC

ProconTEL engine offers access to implementation of internal services. Described mechanism is deliver by service <b>IServiceContext</b>.
<div id='id-legacy-sdk'/>

## 10. Legacy Sdk

<div id='id-testing'/>

## 11. Testing

<div id='id-deployment'/>

## 12. Deployment

<div id='id-deployment-github'/>

* ### Github
```csharp

```

<div id='id-deployment-gitlab'/>

* ### GitLab
```csharp

```
