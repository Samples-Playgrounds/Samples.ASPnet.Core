/*
#########################################################################################
Installing

    Windows - powershell
        
        Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
        .\build.ps1

    Windows - cmd.exe prompt	
    
        powershell ^
            Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
        powershell ^
            .\build.ps1
    
    Mac OSX 

        rm -fr tools/; mkdir ./tools/ ; \
        cp cake.packages.config ./tools/packages.config ; \
        curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx ; \
        chmod +x ./build.sh ;
        ./build.sh

    Linux

        curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/linux
        chmod +x ./build.sh && ./build.sh

Running Cake to Build targets

    Windows

        tools\Cake\Cake.exe --verbosity=diagnostic --target=libs
        tools\Cake\Cake.exe --verbosity=diagnostic --target=nuget
        tools\Cake\Cake.exe --verbosity=diagnostic --target=samples

        
    Mac OSX 
    
        mono tools/Cake/Cake.exe --verbosity=diagnostic --target=libs
        mono tools/Cake/Cake.exe --verbosity=diagnostic --target=nuget

        mono tools/nunit.consolerunner/NUnit.ConsoleRunner/tools/nunit3-console.exe \

#########################################################################################
*/
#addin nuget:?package=Cake.Git

Dictionary<string, string> repositories = new Dictionary<string, string>
{
    {
        "001-samples",
        "https://github.com/aspnet/samples.git"
    },
    {
        "002-Entropy",
        "https://github.com/aspnet/Entropy.git"
    },
    {
        "003-Blazor-Hackathon",
        "https://github.com/aspnet/Blazor-Hackathon.git"
    },
    { 
        "010-Samples-SignalR", 
        "https://github.com/aspnet/SignalR-samples.git"
    },
    { 
        "011-AuthSamples", 
        "https://github.com/aspnet/AuthSamples.git" 
    },
    { 
        "101-StaticFiles", 
        "https://github.com/aspnet/StaticFiles.git" 
    },
    { 
        "102-MVC", 
        "https://github.com/aspnet/Mvc.git" 
    },
    { 
        "103-JavaScriptServices", 
        "https://github.com/aspnet/JavaScriptServices.git" 
    },
    { 
        "104-Blazor", 
        "https://github.com/aspnet/Blazor.git" 
    },
    { 
        "105-SignalR", 
        "https://github.com/aspnet/SignalR.git" 
    },
    { 
        "106-Session", 
        "https://github.com/aspnet/Session.git" 
    },
    { 
        "107-Security", 
        "https://github.com/aspnet/Security.git" 
    },
    { 
        "108-Routing", 
        "https://github.com/aspnet/Routing.git" 
    },
    { 
        "109-BasicMiddleware", 
        "https://github.com/aspnet/BasicMiddleware.git" 
    },
    { 
        "111-Logging", 
        "https://github.com/aspnet/Logging.git" 
    },
    { 
        "115-HttpClientFactory", 
        "https://github.com/aspnet/HttpClientFactory.git" 
    },
    { 
        "112-WebSockets", 
        "https://github.com/aspnet/WebSockets.git" 
    },
    { 
        "113-WebHooks", 
        "https://github.com/aspnet/WebHooks.git" 
    },
    {   
        "115-ResponseCaching", 
        "https://github.com/aspnet/ResponseCaching.git" 
    },
    { 
        "116-Localization", 
        "https://github.com/aspnet/Localization.git" 
    },
    { 
        "117-Identity", 
        "https://github.com/aspnet/Identity.git" 
    },
    { 
        "118-Hosting", 
        "https://github.com/aspnet/Hosting.git" 
    },
    { 
        "119-Diagnostics", 
        "https://github.com/aspnet/Diagnostics.git" 
    },
    { 
        "120-DataProtection", 
        "https://github.com/aspnet/DataProtection.git" 
    },
    { 
        "121-CORS", 
        "https://github.com/aspnet/CORS.git" 
    },
    { 
        "122-AzureIntegration", 
        "https://github.com/aspnet/AzureIntegration.git" 
    },
    { 
        "123-Proxy", 
        "https://github.com/aspnet/Proxy.git" 
    },
    {
        "124-MetaPackages", 
        "https://github.com/aspnet/MetaPackages.git" 
    },
    {
        "126-AADIntegration",
        "https://github.com/aspnet/AADIntegration.git"
    },
    {
        "221-MicrosoftConfigurationBuilders",
        "https://github.com/aspnet/MicrosoftConfigurationBuilders.git"
    },
    {
        "231-AspNetWebHooks",
        "https://github.com/aspnet/AspNetWebHooks.git"
    },
    {
        "211-Performance",
        "https://github.com/aspnet/Performance.git"
    },
};


Task("externals-git-clone")
.Does
(
    () =>
    {
        var directories = GetDirectories("./externals");
        CleanDirectories(directories);
        DeleteDirectories
                    (
                        directories,
                        new DeleteDirectorySettings()
                        {
                            Force = true,
                            Recursive = true,
                        }
                    );
        EnsureDirectoryExists("./externals/repos");
        foreach (KeyValuePair<string, string> repo in repositories)
        {
            Information($"git clone .....");
            Information($"         repo = {repo.Value}");
            Information($"         dir  = ./externals/repos/{repo.Key}");
            
            GitClone
                (
                    repo.Value, 
                    $"./externals/repos/{repo.Key}",
                    new GitCloneSettings
                    { 
                        RecurseSubmodules = true,
                    }
                );
        }
    }
);

RunTarget("externals-git-clone");

