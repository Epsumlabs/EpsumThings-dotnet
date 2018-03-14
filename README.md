# EpsumThings-dotnet
EpsumThings DotNet SDK for developers and hobbyists alike for using EpsumThings IoT platform

# Installation
You can install this package from nuget manager console by using the following line. 
```
PM> Install-Package EpsumThings -Version 0.0.1-beta
```
# Example Code
```C#
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

Accounts user = new Accounts("username", "secret_key", "App_Id");
JavaScriptSerializer serializer = new JavaScriptSerializer();
string jsonString = serializer.Serialize(Things.UserProfile(user));
string data = JsonConvert.DeserializeObject(jsonString).ToString();
Console.Write(data);
```
# Note
Add a reference of System.Web.Extensions in your project

# About
EpsumThings (Beta) is an IoT platform developed at **Epsum Labs Private Limited** for people like you to taste the sweetness of IoT with minimal effort.

Get registered at http://things.epsumlabs.com to explore the IoT platform.
