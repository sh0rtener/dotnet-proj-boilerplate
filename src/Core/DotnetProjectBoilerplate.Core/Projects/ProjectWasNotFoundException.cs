using DotnetProjectBoilerplate.Core.Common.Exceptions;

namespace DotnetProjectBoilerplate.Core.Projects;

public class ProjectWasNotFoundException : CoreException
{
    public override string Message => "Project wasn`t found";
}
