using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class ParameterReplacerBoilerplate : ClassBoilerplate
{
    public ParameterReplacerBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using System.Linq.Expressions;")
        .AppendLine()
        .AppendLine("namespace DotnetProjectBoilerplate.Core.Common.Specifications;")
        .AppendLine()
        .AppendLine("public class ParameterReplacer : ExpressionVisitor")
        .AppendLine("{")
        .AppendLine("    private readonly ParameterExpression _parameter;")
        .AppendLine()
        .AppendLine("    protected override Expression VisitParameter(ParameterExpression node)")
        .AppendLine("    {")
        .AppendLine("        return base.VisitParameter(_parameter);")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    internal ParameterReplacer(ParameterExpression parameter)")
        .AppendLine("    {")
        .AppendLine("        _parameter = parameter;")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
