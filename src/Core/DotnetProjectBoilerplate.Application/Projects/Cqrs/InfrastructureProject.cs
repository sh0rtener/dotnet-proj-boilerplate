using DotnetProjectBoilerplate.Core.Projects;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates;

public class InfrastructureProject : ClassLibraryProject
{
    public override Dictionary<string, (string, Boilerplate)[]> BoilerplateMap { get; }

    public InfrastructureProject(
        string name,
        string applicationPath,
        string applicationName = "Untitled",
        string prefix = "Infrastructure"
    )
        : base(name, applicationPath, applicationName, prefix)
    {
        BoilerplateMap = new Dictionary<string, (string, Boilerplate)[]>()
        {
            { "/Infrastructure/Persistense", [] },
        };
    }
}
