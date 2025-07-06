using System.Diagnostics;
using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Core.Projects;

public class ClassLibraryProject : Project
{
    protected readonly string _srcPath;
    protected readonly string _projectPath;
    protected string _subDirectory = "";

    public override Dictionary<string, (string, Boilerplate)[]> BoilerplateMap =>
        throw new NotImplementedException();

    public ClassLibraryProject(
        string name,
        string applicationPath,
        string applicationName = "Untitled",
        string prefix = "ClassLibrary"
    )
        : base(name + "." + prefix, applicationPath, applicationName)
    {
        _srcPath = ApplicationPath + "/src";
        _projectPath = _srcPath + "/" + _subDirectory + Name;
    }

    public override void Destruct()
    {
        var processStartInfo = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = true,
            Arguments = string.Format("sln {0} remove {1}", ApplicationPath, _projectPath),
            WindowStyle = ProcessWindowStyle.Hidden,
            // RedirectStandardOutput = false
        };

        Process.Start(processStartInfo);

        if (Directory.Exists(_projectPath))
            Directory.Delete(_projectPath, true);
    }

    public override ProjectGenerationStatus Generate()
    {
        var processStartInfo = new ProcessStartInfo("dotnet")
        {
            UseShellExecute = true,
            Arguments = string.Format("new classlib -n {0} -o {1}", Name, _projectPath),
            WindowStyle = ProcessWindowStyle.Hidden,
            // RedirectStandardOutput = false
        };

        Process.Start(processStartInfo)!.WaitForExit();

        processStartInfo.Arguments = string.Format(
            "sln {0} add {1}",
            ApplicationPath,
            _projectPath
        );

        Process.Start(processStartInfo);

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

        return new("Success", _projectPath);
    }
}
