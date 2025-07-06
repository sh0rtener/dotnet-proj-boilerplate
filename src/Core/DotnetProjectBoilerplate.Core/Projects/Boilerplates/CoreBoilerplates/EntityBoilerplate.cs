using System.Text;

namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates.CoreBoilerplates;

public class EntityBoilerplate : ClassBoilerplate
{
    public EntityBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
            .AppendLine(string.Format("namespace {0}.Core.Common.Entities;", Namespace))
            .AppendLine()
            .AppendLine("public abstract class Entity<TId>")
            .AppendLine("{")
            .AppendLine("    public TId? Id { get; set; }")
            .AppendLine("}")
            .ToString();
}
