using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class NotSpecificationBoilerplate : ClassBoilerplate
{
    public NotSpecificationBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using System.Linq.Expressions;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Core.Common.Specifications;", Namespace))
        .AppendLine()
        .AppendLine("public class NotSpecification<T> : Specification<T>")
        .AppendLine("{")
        .AppendLine("    private Specification<T> _spec;")
        .AppendLine()
        .AppendLine("    public NotSpecification(Specification<T> spec)")
        .AppendLine("    {")
        .AppendLine("        _spec = spec;")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public override Expression<Func<T, bool>> ToExpression()")
        .AppendLine("    {")
        .AppendLine("        return Expression.Lambda<Func<T, bool>>(")
        .AppendLine("            Expression.Not(_spec.ToExpression().Body),")
        .AppendLine("            _spec.ToExpression().Parameters.Single()")
        .AppendLine("        );")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
