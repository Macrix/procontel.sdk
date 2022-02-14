---
Title: "ProconTEL WEB Endpoint Examples"
github_url: "https://github.com/Macrix/procontel.sdk/Samples/WebEndpoint/edit/main/README.md"
Weight: 8
Description: >
  Use the ProconTEL endpoint to host and manage your WEB application
---

## Table of Contents

1. [Quick introduction](#id-quick-introduction)
2. [Web endpoint settings](#id-endpoint-settings)
3. [Hosting static files](#hosting-static-files)
4. [Broadcasting messages using GET request](#id)
5. [Example of usage](#id)
 
 <div id='id-quick-introduction'/>

## 1. Quick introduction
Using ProconTEL, you can create an application that will provide communication between endpoints using HTTP request. You can also use ProconTEL endpoint to host some static web pages. The instruction describes how to solve the main issues with setup and hosting.

<div id='i#id-endpoint-settings'/>

## 2. Web endpoint settings
In the provided example the WebServerEndpoint is use the Startup and WebHostEndpoint class to configure ASP.NET controller. The setup configuration can be extended using the same configuration parameters as in the usual ASP.NET project.

<div id='i#hosting-static-files'/>

## 3. Hosting static files
It is possible to use the ProconTEL plugin to host static websites. For this purpose, the service AddSpaStaticFiles has been defined in the Startup class. Be able to display the page while installing the plugin, configure the path that contains the files of the website. The example configuration is shown below.

To publish your static files, follow the steps below
In the "Startup" class, set the name of the folder where the files will be located. In the example below, this is a folder named "WebApp". 

```csharp
services.AddSpaStaticFiles(options => { options.RootPath = "WebApp"; });
```

Copy the selected files to the selected folder
Install the plugin containing Web Endpoint
During plug-in installation, select the folder containing static files

![Fixed size array represented in XML with 2 elements filled and size set to 4 elements](./assets/fixed-size-array.png)

Then add an endpoint to the channel or pool and run it. 

<img></img>