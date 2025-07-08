using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class IUnitOfWorkBoilerplate : ClassBoilerplate
{
    public IUnitOfWorkBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine(string.Format("namespace {0}.Core.Application.Common;", Namespace))
        .AppendLine()
        .AppendLine("public interface IUnitOfWork")
        .AppendLine("{")
        .AppendLine("    Task CommitAsync(CancellationToken cancellationToken = default);")
        .AppendLine("    Task RollbackAsync(CancellationToken cancellationToken = default);")
        .AppendLine("}")
        .ToString();
}
