using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class DependencyInjectionBoilerplate : ClassBoilerplate
{
    public DependencyInjectionBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using System.Reflection;")
        .AppendLine(string.Format("using {0}.Application.Behaviours;", Namespace))
        .AppendLine("using MediatR;")
        .AppendLine("using Microsoft.Extensions.Configuration;")
        .AppendLine()
        .AppendLine("namespace Microsoft.Extensions.DependencyInjection;")
        .AppendLine()
        .AppendLine("public static class DependencyInjection")
        .AppendLine("{")
        .AppendLine("    public static IServiceCollection ConfigureApplication(this IServiceCollection services)")
        .AppendLine("    {")
        .AppendLine("        services.AddAutoMapper(Assembly.GetExecutingAssembly());")
        .AppendLine("        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());")
        .AppendLine()
        .AppendLine("        services.AddMediatR(cfg =>")
        .AppendLine("        {")
        .AppendLine("            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());")
        .AppendLine("            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));")
        .AppendLine("            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));")
        .AppendLine("        });")
        .AppendLine()
        .AppendLine("        return services;")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
