---
Title: "ProconTEL WEB Endpoint Examples"
github_url: "https://github.com/Macrix/procontel.cli/edit/main/README.md"
Weight: 8
Description: >
  Use the ProconTelCli.exe command line
---

## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Available commands](#id-available-commands)
3. [Container commands](#id-container-commands)
4. [Endpoint commands](#id-endpoint-commands)
5. [Import commands](#id-import-commands)
6. [Plugin commands](#id-plugin-commands)
7. [Workspace commands](#id-workspace-commands)
8. [Exit Codes](#id-exit-codes)
 
 <div id='id-quick-introduction'/>

## 1. Quick introduction
The ProconTelCli  makes it easy to create and manage a ProconTel ecosystem. It already follows our best practices!

<div id='id-available-commands'/>

## 2. Available commands
To list available commands, either run ```.\ProconTelCli.exe``` with no parameters or execute ```.\ProconTelCLI.exe --help```

```csharp
ProconTelCLI is command line interface for managing ProconTEL server. THIS IS AN ALPHA RELEASE, YOU ARE USING IT AT YOUR OWN RISK.

Usage: procontelCLI [options] [command]

Options:
  -?|-h|--help  Show help information

Commands:
  container     Manage containers (channel or pools) running on ProconTEL server.
  endpoint      Manage endpoints running on ProconTEL server.
  import        Import PEX file.
  plugin        Manage plugins installed on ProconTEL server.
  workspace     Manage workspaces running on ProconTEL server.

Run 'procontelCLI [command] --help' for more information about a command.
```

<div id='id-container-commands'/>

## 3. Container commands

Create a pool called TestPool in workspace TestWorkspace.
```csharp
.\procontelcli.exe container new -p -w TestWorkspace TestPool
```
<br/>

Create a channel called TestChannel in workspace TestWorkspace.
```csharp
.\procontelcli.exe container new -w TestWorkspace TestChannel
```
to be continued...
<div id='id-endpoint-commands'/>

## 4. Endpoint commands

Create new endpoint called TestEndpoint in the channel called TestChannel from TestPlugin plugin on localhost
```csharp
.\procontelcli.exe endpoint new -c TestChannel -p TestPlugin.Endpoint@TestPlugin -s localhost
```
One remark: this: <b>TestPlugin.Endpoint@TestPlugin</b> hopefully will be replaced by something better in the newer version of ProcontelCLI. It's built as namespace of endpoint class @ name of plugin.

<br/>

Display list of endpoint running on connected ProconTel version.
```csharp
.\procontelcli.exe endpoint list -s localhost:9000
```
<br/>

Display parameters of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint params TestEndpoint -s localhost:9000
```
<br/>

Update parameter ActsAsProvider to ```true``` of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint params TestEndpoint -u="ActsAsProvider=true" -s localhost:9000
```
<br/>

Display internal configuration of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint config TestEndpoint -s localhost:9000
```
<br/>

Update internal configuration to ```CONFIGURATION_VALUE``` of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint config TestEndpoint -u="CONFIGURATION_VALUE" -s localhost:9000
```
<br/>

Load internal configuration from local file ```C:\configuration.txt``` of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint config TestEndpoint -f="C:\configuration.txt" -s localhost:9000
```
<br/>

Replace xml internal configuration property of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint config TestEndpoint -r-xml="PluginConfiguration/MethodName=NEW_VALUE" -s localhost:9000
```
<br/>

Replace json internal configuration property of endpoint called TestEndpoint.
```csharp
.\procontelcli.exe endpoint config TestEndpoint -r-json="PluginConfiguration.MethodName=NEW_VALUE" -s localhost:9000
```

<div id='id-import-commands'/>

## 5. Import commands
*Chapter in build*

<div id='id-plugin-commands'/>

## 6. Plugin commands
Install plugin called Test Plugin 
```csharp
.\procontelcli.exe plugin install D:\SampleProject\TestPlugin.dll
```
<br/>

Install plugin called Test Plugin with dependent an additional dll binaries 
```csharp
.\procontelcli.exe plugin install D:\SampleProject\TestPlugin.dll -f D:\SampleProject\contrib\|*.dll||R
```
Where 'R' is a flag to search for defined files recursively in mentioned path.

</br>

Install plugin called Test Plugin with dependent an additional dll binaries from two directories
(additional directories require adding next -f parameter)
```csharp
.\procontelcli.exe plugin install D:\SampleProject\TestPlugin.dll -f D:\SampleProject\contrib\|*.dll||R -f D:\SampleProject\additionalLibs\|*.dll||R
```
<br/>

Get information about installed plugin
```csharp
.\ProconTelCLI.exe plugin describe ExampleTelegramEndpoint
Plugin:
  FullName: ExampleTelegramEndpoint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
  Version: 1.0.0.0
  UpdateDate: 2021-03-23 12:33:59
  InstallDate: 2021-03-19 09:41:45
```

<div id='id-workspace-commands'/>

## 7. Workspace commands
Create new workspace called TestWorkspace
```csharp
.\procontelcli.exe workspace new TestWorkspace
```
<br/>

<div id='id-exit-codes'/>

## 8. Exit codes

Global exit codes
| Exit Code | Description |
| :---: | :---: |
| 0 | Success |
| 1 | Incorrect Command |
| 2 | Command Failure |

<br/>
Specific exit codes and description

| Exit Code | Description |
| :---: | :---: |
| 100 | Endpoint deos not exist |
| 101 | Container does not exist |
| 102 | Workspace does not exist |
| 103 | Plugin does not exist |
| 104 | Dependency does not exist |
| 105 | Destination container already contain avatar of selected endpoint |
| 106 | Destination container cannot be pool |
| 107 | Container is active |
| 108 | No avatar in container |
| 109 | No endpoint in container |
| 110 | Transfering plugin files failed |
| 111 | Upgrading plugin failed |
| 112 | Plugin validation failed |
| 113 | Pool cannot contain avatar |
| 114 | Wrong container type |

<br/>

to be continued...