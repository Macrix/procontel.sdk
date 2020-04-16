# ProconTEL.Sdk


## Quick introduction
`ProconTEL.Sdk` is a modern .Net Standard sdk for port your business logic in [ProconTEL](http://procontel.com/) environment. The modular design and middleware oriented architecture makes the endpoint highly customizable while providing sensible default for topology, communication and extensions. Documentation for version 1.x of the is currently found under [`/docs`](https://macrix.eu/).

### Endpoint Builder blocks

#### ILifeTimeCycle


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

#### IHandler


```csharp

```

### Injected services

#### ILogger


```csharp

```

#### ISender


```csharp

```

### UI Components

We are able to bind and communicate user interface to hosted business logic. Supported fronted framework:
 - Angular
 - React
 - Wpf
 - WinForms
 
#### Configuration Dialog


```csharp

```

#### Status Control


```csharp

```

### CI && CD

 
#### Github


```csharp

```

#### Gitlab


```csharp

```
