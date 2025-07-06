using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class ValueObjectBoilerplate : ClassBoilerplate
{
    public ValueObjectBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
            .AppendLine(string.Format("namespace {0}.Core.Common.Entities;", Namespace))
            .AppendLine()
            .AppendLine("public abstract class ValueObject")
            .AppendLine("{")
            .AppendLine(
                "    protected static bool EqualOperator(ValueObject left, ValueObject right)"
            )
            .AppendLine("    {")
            .AppendLine("        if (left is null ^ right is null)")
            .AppendLine("        {")
            .AppendLine("            return false;")
            .AppendLine("        }")
            .AppendLine()
            .AppendLine("        return left?.Equals(right!) != false;")
            .AppendLine("    }")
            .AppendLine()
            .AppendLine(
                "    protected static bool NotEqualOperator(ValueObject left, ValueObject right)"
            )
            .AppendLine("    {")
            .AppendLine("        return !(EqualOperator(left, right));")
            .AppendLine("    }")
            .AppendLine()
            .AppendLine("    protected abstract IEnumerable<object> GetEqualityComponents();")
            .AppendLine()
            .AppendLine("    public override bool Equals(object? obj)")
            .AppendLine("    {")
            .AppendLine("        if (obj == null || obj.GetType() != GetType())")
            .AppendLine("        {")
            .AppendLine("            return false;")
            .AppendLine("        }")
            .AppendLine()
            .AppendLine("        var other = (ValueObject)obj;")
            .AppendLine(
                "        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());"
            )
            .AppendLine("    }")
            .AppendLine()
            .AppendLine("    public override int GetHashCode()")
            .AppendLine("    {")
            .AppendLine("        var hash = new HashCode();")
            .AppendLine("        foreach (var component in GetEqualityComponents())")
            .AppendLine("        {")
            .AppendLine("            hash.Add(component);")
            .AppendLine("        }")
            .AppendLine()
            .AppendLine("        return hash.ToHashCode();")
            .AppendLine("    }")
            .AppendLine("}")
            .ToString();
}
