# ProconTEL.Sdk


## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Feature Comparison](#id-feature-comparison)
3. [Builder blocks](#id-builder-blocks)
    3.1. [ILifeTimeCycle](#id-builder-blocks-ilife-time-cycle)
    3.2. [IHandler](#id-builder-blocks-ihandler)
4. [Injected services](#id-injected-services)
    4.1. [ILogger](#id-injected-services-ilogger)
    4.2. [ISender](#id-injected-services-isender)
5. [UI Components](#id-ui-components)
    5.1. [Configuration Dialog](#id-ui-components-configuration-dialog)
    5.2. [Status Control](#id-ui-components-status-control)
6. [Deployment](#id-deployment)
    6.1. [Github](#id-deployment-github)
    6.2. [GitLab](#id-deployment-gitlab)

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

### 3.1. ILifeTimeCycle
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

### 3.2. IHandler
```csharp

```

<div id='id-injected-services'/>

## 4. Injected services

<div id='id-injected-services-ilogger'/>

### 4.1. ILogger
```csharp

```

<div id='id-injected-services-idender'/>

### 4.2. ISender
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
 
### 5.1. Configuration Dialog
```csharp

```

<div id='id-ui-components-status-control'/>

### 5.2. Status Control
```csharp

```

<div id='id-deployment'/>

## 6. Deployment

<div id='id-deployment-github'/>

### 6.1 Github
```csharp

```

<div id='id-deployment-gitlub'/>

### 6.2 GitLab
```csharp

```
