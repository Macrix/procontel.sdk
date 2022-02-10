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
Using ProconTEL, you can create an application that will provide communication between endpoints using HTTP request. You can also use ProconTEL endpoint to host some static pages. The instruction describes how to solve the main issues with setup and hosting.

<div id='i#id-endpoint-settings'/>

## 2. Web endpoint settings
In the provided example the WebServerEndpoint is use the Startup and WebHostEndpoint class to configure ASP.NET controller. The setup configuration can be extended using the same configuration parameters as in the usual ASP.NET project.


<div id='i#hosting-static-files'/>

## 3. Hosting static files
It is possible to use the ProconTEL plugin to host static websites. For this purpose, the AddSpaStaticFiles service has been defined in the Startup class. Be able to display the page while installing the plugin, configure the path that contains the files of the website. The example configuration is shown below.

<img></img>

Then add an endpoint to the channel or pool and run it. 

<img></img>