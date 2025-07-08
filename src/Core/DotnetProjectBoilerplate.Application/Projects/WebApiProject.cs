using System.Diagnostics;
using System.Text;
using DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.WebApiBoilerplates;
using DotnetProjectBoilerplate.Core.Projects;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects;

public class WebApiProject : Project
{
    protected readonly string _srcPath;
    protected readonly string _projectPath;
    protected string _subDirectory = "";
    public override Dictionary<string, (string, Boilerplate)[]> BoilerplateMap { get; }

    public WebApiProject(string name, string applicationPath, string applicationName = "Untitled")
        : base(name + ".WebApi", applicationPath, applicationName)
    {
        _srcPath = ApplicationPath + "/src";
        _projectPath = _srcPath + "/" + _subDirectory + Name;

        BoilerplateMap = new()
        {
            { "/", [("Program.cs", new ProgramBoilerplate(ApplicationName))] },
            {
                "/Controllers",
                [("WeatherController.cs", new WeatherControllerBoilerplate(ApplicationName))]
            },
            {
                "/Middlewares",
                [
                    (
                        "ExceptionHandlerMiddleware.cs",
                        new ExceptionHandlerMiddlewareBoilerplate(ApplicationName)
                    ),
                ]
            },
        };
    }

    public override void Destruct()
    {
        var processStartInfo = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            Arguments = string.Format("sln {0} remove {1}", ApplicationPath, _projectPath),
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = false,
        };

        Process.Start(processStartInfo)!.WaitForExit();

        if (Directory.Exists(_projectPath))
            Directory.Delete(_projectPath, true);
    }

    public override ProjectGenerationStatus Generate()
    {
        var processStartInfo = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = false,
            Arguments = string.Format("new webapi -n {0} -o {1}", Name, _projectPath),
            WindowStyle = ProcessWindowStyle.Hidden,
            RedirectStandardOutput = false,
        };

        Process.Start(processStartInfo)!.WaitForExit();

        if (File.Exists(_projectPath + "/Program.cs"))
            File.Delete(_projectPath + "Program.cs");

        processStartInfo.Arguments = string.Format(
            "sln {0} add {1}",
            ApplicationPath,
            _projectPath
        );

        Process.Start(processStartInfo)!.WaitForExit();

        foreach (var boilerplate in BoilerplateMap)
        {
            var dir = _projectPath + boilerplate.Key;

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            foreach (var file in boilerplate.Value)
            {
                var filePath = dir + "/" + file.Item1;
                var value = file.Item2.Build();

                File.WriteAllBytes(filePath, Encoding.UTF8.GetBytes(value));
            }
        }

        string[] packages = ["Microsoft.AspNetCore.Mvc", "Swashbuckle.AspNetCore", "Newtonsoft.Json"];

        foreach (var package in packages)
        {
            processStartInfo.Arguments = string.Format(
                "add {0} package {1}",
                _projectPath,
                package
            );
            Process.Start(processStartInfo)!.WaitForExit();
        }

        return new("Success", _projectPath);
    }
}
