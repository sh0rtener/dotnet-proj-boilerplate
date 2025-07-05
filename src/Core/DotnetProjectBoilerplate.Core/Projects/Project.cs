using DotnetProjectBoilerplate.Core.Common.Entities;

namespace DotnetProjectBoilerplate.Core.Projects;

public abstract class Project : Entity<Guid>
{
    public string ApplicationPath { get; private set; }
    public string ApplicationName { get; private set; } = "Untitled";
    public string Name { get; private set; }

    public Project(string name, string applicationPath, string applicationName = "Untitled")
    {
        Name = name;
        ApplicationPath = applicationPath;
        ApplicationName = applicationName;
    }

    public abstract ProjectGenerationStatus Generate();
    public abstract void Destruct();
}
