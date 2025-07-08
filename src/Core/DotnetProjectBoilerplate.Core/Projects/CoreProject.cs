using DotnetProjectBoilerplate.Core.Projects.Boilerplates;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

namespace DotnetProjectBoilerplate.Core.Projects;

public class CoreProject : ClassLibraryProject
{
    public override Dictionary<string, (string, Boilerplate)[]> BoilerplateMap { get; }

    public CoreProject(
        string name,
        string applicationPath,
        string applicationName = "Untitled",
        string prefix = "Core"
    )
        : base(name, applicationPath, applicationName, prefix)
    {
        _subDirectory = "/Core/";
        BoilerplateMap = new Dictionary<string, (string, Boilerplate)[]>()
        {
            {
                "/Common/Entities",
                [
                    ("Entity.cs", new EntityBoilerplate(ApplicationName)),
                    ("ValueObject.cs", new ValueObjectBoilerplate(ApplicationName)),
                ]
            },
            {
                "/Common/Exceptions",
                [("CoreException.cs", new CoreExceptionBoilerplate(ApplicationName))]
            },
            {
                "/Common/Specifications",
                [
                    ("ParameterReplacer.cs", new ParameterReplacerBoilerplate(ApplicationName)),
                    ("Specification.cs", new SpecificationBoilerplate(ApplicationName)),
                    ("AndSpecification.cs", new AndSpecificationBoilerplate(ApplicationName)),
                    ("OrSpecification.cs", new OrSpecificationBoilerplate(ApplicationName)),
                    ("NotSpecification.cs", new NotSpecificationBoilerplate(ApplicationName)),
                ]
            },
        };
    }

    public override ProjectGenerationStatus Generate()
    {
        var baseResult = base.Generate();
        return baseResult;
    }
}
