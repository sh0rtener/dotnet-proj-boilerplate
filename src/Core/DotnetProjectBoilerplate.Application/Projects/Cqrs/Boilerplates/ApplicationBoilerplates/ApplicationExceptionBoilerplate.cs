using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class ApplicationExceptionBoilerplate : ClassBoilerplate
{
    public ApplicationExceptionBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine(string.Format("namespace {0}.Application.Common.Exceptions;", Namespace))
        .AppendLine()
        .AppendLine("public class ApplicationException : Exception")
        .AppendLine("{")
        .AppendLine("    public ApplicationException(string text) : base(text) { }")
        .AppendLine("}")
        .ToString();
}
