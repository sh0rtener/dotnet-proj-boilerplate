using DotnetProjectBoilerplate.Application.Apps;
using DotnetProjectBoilerplate.Core.Apps;

var appMap = new Dictionary<string, IAppService>() { { "Ddd", new DddAppCreatorService() } };

while (true)
{
    Console.WriteLine("Choose project what you want:");
    int i = 1;
    foreach (var app in appMap.Keys)
    {
        Console.WriteLine("{0}) {1}", i, app);
    }

    Console.WriteLine("Write your choose here (write q to exit): ");
    var value = Console.ReadLine() ?? "";

    if (value.Equals("q"))
        break;

    if (!appMap.ContainsKey(value))
    {
        Console.WriteLine("Try again");
    }
    else
    {
        var service = appMap[value];

        Console.WriteLine("Write name of your app: ");
        var appName = Console.ReadLine();

        Console.WriteLine("Write a path of your app: ");
        var appPath = Console.ReadLine();

        var app = service.CreateApp(appName, appPath);

        foreach (var project in app.Projects)
            project.Generate();
    }

    Console.Clear();
}
