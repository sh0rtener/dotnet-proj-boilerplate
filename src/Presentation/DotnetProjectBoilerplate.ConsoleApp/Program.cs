// See https://aka.ms/new-console-template for more information
using DotnetProjectBoilerplate.Application.Apps;
using DotnetProjectBoilerplate.Core.Apps;

Console.WriteLine("Hello, World!");

IAppService appService = new DddAppCreatorService();
var app = appService.CreateApp("Test", "/home/sh0rtener/projects/temp");

foreach (var project in app.Projects)
{
    project.Generate();
}
