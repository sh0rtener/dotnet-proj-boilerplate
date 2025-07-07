using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class ValidationExceptionBoilerplate : ClassBoilerplate
{
    public ValidationExceptionBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine(string.Format("namespace {0}.Application.Common.Exceptions;", Namespace))
        .AppendLine()
        .AppendLine("public class ValidationException : ApplicationException")
        .AppendLine("{")
        .AppendLine("    public Dictionary<string, string[]> Errors { get; }")
        .AppendLine()
        .AppendLine("    public ValidationException()")
        .AppendLine("        : base(\"Ошибка валидации модели. Смотрите подробнее ошибки и условия\")")
        .AppendLine("    {")
        .AppendLine("        Errors = new Dictionary<string, string[]>();")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public ValidationException(Dictionary<string, string[]> failures)")
        .AppendLine("        : this()")
        .AppendLine("    {")
        .AppendLine("        Errors = failures;")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
