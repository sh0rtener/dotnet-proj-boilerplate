using DotnetProjectBoilerplate.Application.Projects;
using DotnetProjectBoilerplate.Application.Projects.Cqrs;
using DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates;
using DotnetProjectBoilerplate.Core.Apps;
using DotnetProjectBoilerplate.Core.Projects;

namespace DotnetProjectBoilerplate.Application.Apps;

public class DddAppCreatorService : IAppService
{
    public App CreateApp(string appName, string appDir)
    {
        var app = new App(appName, appDir);
        app.Initialize();
        var core = new CoreProject(appName, appDir, appName);
        var application = new ApplicationProject(appName, appDir, appName);
        var infrastructure = new InfrastructureProject(appName, appDir, appName);
        var webapi = new WebApiProject(appName, appDir, appName);

        app.AddProject(core);
        app.AddProject(application);
        app.AddProject(infrastructure);
        app.AddProject(webapi);

        return app;
    }
}
