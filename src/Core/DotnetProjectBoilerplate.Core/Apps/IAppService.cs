namespace DotnetProjectBoilerplate.Core.Apps;

public interface IAppService
{
    public App CreateApp(string appName, string appDir);
}
