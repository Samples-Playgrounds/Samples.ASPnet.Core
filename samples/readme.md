# ASP.net Core and SignalR

## Setup

1.  Project (*.csproj)

```    
    <PackageReference Include="Microsoft.AspNetCore.SignalR" Version="1.0.0-alpha1-final" /> 
```

.NET CLI 

```
    dotnet add package Microsoft.AspNetCore.SignalR --version 1.0.0-alpha1-final 
```

```
  <!--
  =============================================================================================
    SignalR
  -->  
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.SignalR" Version="1.0.0-alpha1-final" />
  </ItemGroup>
  <ItemGroup>
    <Folder Include="wwwroot\scripts\" />
  </ItemGroup>
  <ItemGroup>
    <Folder Include="APISignalR\" />
  </ItemGroup>
  <!--
    SignalR
  =============================================================================================
  -->  
```
2.  Setup SignalR.Hub


```
    using System;

    namespace Empty.SignalR.APISignalR
    {
        public class HubChat : Microsoft.AspNetCore.SignalR.Hub
        {
            public System.Threading.Tasks.Task Send(string message)
            {
                return Clients.All.InvokeAsync("Send", message);
            }
        }
    }
```

3.  install JavaScript SignalR client[s] module

```
    export PROJECT=Empty.SignalR
    export NODE_MODULE=signalr-js-npm-module
    rm -fr $NODE_MODULE
    mkdir $NODE_MODULE
    cd $NODE_MODULE
    npm install @aspnet/signalr-client
    cd ..
    cp \
        $NODE_MODULE/node_modules/\@aspnet/signalr-client/dist/browser/signalr-client-1.0.0-alpha2-final.js \
        $PROJECT/wwwroot/scripts/signalr-client.js 
```




## References / Links

*   https://blogs.msdn.microsoft.com/webdev/2017/09/14/announcing-signalr-for-asp-net-core-2-0/

*   https://blogs.msdn.microsoft.com/webdev/2017/10/09/announcing-signalr-for-asp-net-core-alpha-2/
