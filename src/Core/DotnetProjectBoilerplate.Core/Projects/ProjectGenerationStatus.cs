using DotnetProjectBoilerplate.Core.Common.Entities;

namespace DotnetProjectBoilerplate.Core.Projects;

public class ProjectGenerationStatus : ValueObject
{
    private string _status;
    public string Status => _status;

    private string _path;
    public string Path => _path;

    public ProjectGenerationStatus(string status, string path)
    {
        _path = path;
        _status = status;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Status;
        yield return Path;
    }
}