using System.Diagnostics;
using DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;
using DotnetProjectBoilerplate.Core.Projects;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs;

public class ApplicationProject : ClassLibraryProject
{
    public override Dictionary<string, (string, Boilerplate)[]> BoilerplateMap { get; }

    public ApplicationProject(
        string name,
        string applicationPath,
        string applicationName = "Untitled",
        string prefix = "Application"
    )
        : base(name, applicationPath, applicationName, prefix)
    {
        _subDirectory = "/Application/";
        BoilerplateMap = new Dictionary<string, (string, Boilerplate)[]>()
        {
            {
                "/",
                [("DependencyInjection.cs", new DependencyInjectionBoilerplate(ApplicationName))]
            },
            { "/Common", [("IUnitOfWork.cs", new IUnitOfWorkBoilerplate(ApplicationName))] },
            {
                "/Common/Exceptions",
                [
                    (
                        "ApplicationException.cs",
                        new ApplicationExceptionBoilerplate(ApplicationName)
                    ),
                    ("ValidationException.cs", new ValidationExceptionBoilerplate(ApplicationName)),
                ]
            },
            {
                "/Common/Behaviours",
                [
                    ("ValidationBehaviour.cs", new ValidationBehaviourBoilerplate(ApplicationName)),
                    ("LoggingBehaviour.cs", new LoggingBehaviourBoilerplate(ApplicationName)),
                ]
            },
            {
                "/Features/Weather",
                [("WeatherForecastDto.cs", new WeatherForecastDtoBoilerplate(ApplicationName))]
            },
            {
                "/Features/Weather/GetWeather",
                [("GetWeatherQuery.cs", new GetWeatherForecastQueryBoilerplate(ApplicationName))]
            },
        };
    }

    public override ProjectGenerationStatus Generate()
    {
        var result = base.Generate();

        var processStartInfo = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            Arguments = string.Format("add package {0} AutoMapper", _projectPath),
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = false
        };

        Process.Start(processStartInfo)!.WaitForExit();

        string[] packages =
        [
            "FluentValidation",
            "FluentValidation.DependencyInjectionExtensions",
            "Microsoft.Extensions.Logging",
            "Microsoft.Extensions.Options.ConfigurationExtensions",
            "MediatR",
        ];

        foreach (var package in packages)
        {
            processStartInfo.Arguments = string.Format(
                "add {0} package {1}",
                _projectPath,
                package
            );
            Process.Start(processStartInfo)!.WaitForExit();
        }

        return result;
    }
}
