using System.Diagnostics;

namespace DotnetProjectBoilerplate.Core.Projects;

public class ClassLibraryProject : Project
{
    protected readonly string _srcPath;
    protected readonly string _projectPath;
    protected string _subDirectory = "";

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

        Process.Start(processStartInfo);

        processStartInfo.Arguments = string.Format(
            "sln {0} add {1}",
            ApplicationPath,
            _projectPath
        );

        Process.Start(processStartInfo);

        return new("Success", _projectPath);
    }
}
