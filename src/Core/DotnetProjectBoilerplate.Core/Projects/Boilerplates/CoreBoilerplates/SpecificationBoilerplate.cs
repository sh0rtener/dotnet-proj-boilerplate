using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class SpecificationBoilerplate : ClassBoilerplate
{
    public SpecificationBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using System.Linq.Expressions;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Core.Common.Specifications;", Namespace))
        .AppendLine()
        .AppendLine("public abstract class Specification<T>")
        .AppendLine("{")
        .AppendLine("    public abstract Expression<Func<T, bool>> ToExpression();")
        .AppendLine()
        .AppendLine("    public Specification<T> And(Specification<T> specification)")
        .AppendLine("    {")
        .AppendLine("        return new AndSpecification<T>(this, specification);")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public Specification<T> Or(Specification<T> specification)")
        .AppendLine("    {")
        .AppendLine("        return new OrSpecification<T>(this, specification);")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public Specification<T> Not(Specification<T> specification)")
        .AppendLine("    {")
        .AppendLine("        return new NotSpecification<T>(specification);")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public bool IsSatisfiedBy(T item)")
        .AppendLine("    {")
        .AppendLine("        Func<T, bool> predicate = ToExpression().Compile();")
        .AppendLine("        return predicate(item);")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
