using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects;

public class CoreProject : ClassLibraryProject
{
    public CoreProject(
        string name,
        string applicationPath,
        string applicationName = "Untitled",
        string prefix = "Core"
    )
        : base(name, applicationPath, applicationName, prefix)
    {
        _subDirectory = "/Core/";
    }

    public override ProjectGenerationStatus Generate()
    {
        var baseResult = base.Generate();

        var commonDir = _projectPath + "/Common";

        if (!Directory.Exists(commonDir))
            Directory.CreateDirectory(commonDir);

        var entitiesDir = commonDir + "/Entities";

        if (!Directory.Exists(entitiesDir))
            Directory.CreateDirectory(entitiesDir);

        var entityFilePath = entitiesDir + "/Entity.cs";
        var valueObjectFilePath = entitiesDir + "/ValueObject.cs";
        var entityBoilerplate = GenerateEntityBoilerplate();
        var valueObjectBoilerplate = GenerateValueObjectBoilerplate();
        File.WriteAllBytes(entityFilePath, Encoding.UTF8.GetBytes(entityBoilerplate));
        File.WriteAllBytes(valueObjectFilePath, Encoding.UTF8.GetBytes(valueObjectBoilerplate));

        return baseResult;
    }

    private string GenerateEntityBoilerplate() =>
        new StringBuilder()
            .AppendLine(string.Format("namespace {0}.Core.Common.Entities;", ApplicationName))
            .AppendLine()
            .AppendLine("public abstract class Entity<TId>")
            .AppendLine("{")
            .AppendLine("    public TId? Id { get; set; }")
            .AppendLine("}")
            .ToString();

    private string GenerateValueObjectBoilerplate() =>
        new StringBuilder()
            .AppendLine(string.Format("namespace {0}.Core.Common.Entities;", ApplicationName))
            .AppendLine()
            .AppendLine("public abstract class ValueObject")
            .AppendLine("{")
            .AppendLine("    protected static bool EqualOperator(ValueObject left, ValueObject right)")
            .AppendLine("    {")
            .AppendLine("        if (left is null ^ right is null)")
            .AppendLine("        {")
            .AppendLine("            return false;")
            .AppendLine("        }")
            .AppendLine()
            .AppendLine("        return left?.Equals(right!) != false;")
            .AppendLine("    }")
            .AppendLine()
            .AppendLine("    protected static bool NotEqualOperator(ValueObject left, ValueObject right)")
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
            .AppendLine("        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());")
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
