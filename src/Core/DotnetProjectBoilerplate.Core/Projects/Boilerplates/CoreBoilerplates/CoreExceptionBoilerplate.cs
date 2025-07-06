using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class CoreExceptionBoilerplate : ClassBoilerplate
{
    public CoreExceptionBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine(string.Format("namespace {0}.Core.Common.Exceptions;", Namespace))
        .AppendLine()
        .AppendLine("public class CoreException : Exception { }")
        .ToString();
}
