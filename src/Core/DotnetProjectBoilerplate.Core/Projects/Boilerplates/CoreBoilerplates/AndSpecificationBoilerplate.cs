using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class AndSpecificationBoilerplate : ClassBoilerplate
{
    public AndSpecificationBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using System.Linq.Expressions;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Core.Common.Specifications;", Namespace))
        .AppendLine()
        .AppendLine("public class AndSpecification<T> : Specification<T>")
        .AppendLine("{")
        .AppendLine("    private Specification<T> _left;")
        .AppendLine("    private Specification<T> _right;")
        .AppendLine()
        .AppendLine("    public AndSpecification(Specification<T> left, Specification<T> right)")
        .AppendLine("    {")
        .AppendLine("        _left = left;")
        .AppendLine("        _right = right;")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public override Expression<Func<T, bool>> ToExpression()")
        .AppendLine("    {")
        .AppendLine("        var leftExpression = _left.ToExpression();")
        .AppendLine("        var rightExpression = _right.ToExpression();")
        .AppendLine("        var parameterExpression = Expression.Parameter(typeof(T));")
        .AppendLine("        var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);")
        .AppendLine("        andExpression = (BinaryExpression)")
        .AppendLine("            new ParameterReplacer(parameterExpression).Visit(andExpression);")
        .AppendLine()
        .AppendLine("        return Expression.Lambda<Func<T, bool>>(andExpression, parameterExpression);")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
