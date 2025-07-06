using DotnetProjectBoilerplate.Core.Common.Entities;
using DotnetProjectBoilerplate.Core.Common.Exceptions;
using DotnetProjectBoilerplate.Core.Projects;

namespace DotnetProjectBoilerplate.Core.Apps;

public class App : Entity<int>
{
    private List<Project> _projects = [];
    public string Name { get; private set; }
    public string Path { get; private set; } = "";
    public bool UseVsc { get; set; } = false;
    public IReadOnlyCollection<Project> Projects => _projects;

    public App(string name, string path = "")
    {
        Name = GuardException.ThrowIfInputIsInvalidFormat(
            new CorrectAppNameSpecification(name),
            name,
            nameof(name)
        );

        Path = GuardException.ThrowIfInvalidPath(path);
    }

    public void AddProject(Project project)
    {
        _projects.Add(project);
    }

    public void RemoveProject(Guid projectId)
    {
        var project =
            _projects.FirstOrDefault(x => x.Id == projectId)
            ?? throw new ProjectWasNotFoundException();

        project.Destruct();
        _projects.Remove(project);
    }
}
