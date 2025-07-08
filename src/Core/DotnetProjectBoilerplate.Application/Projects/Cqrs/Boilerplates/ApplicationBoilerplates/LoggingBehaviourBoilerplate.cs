using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class LoggingBehaviourBoilerplate : ClassBoilerplate
{
    public LoggingBehaviourBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using MediatR;")
        .AppendLine("using Microsoft.Extensions.Logging;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Application.Behaviours;", Namespace))
        .AppendLine()
        .AppendLine("public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>")
        .AppendLine("    where TRequest : no")
        .AppendLine("{")
        .AppendLine("    private readonly ILogger<IRequest> _logger;")
        .AppendLine()
        .AppendLine("    public LoggingBehaviour(ILogger<IRequest> logger)")
        .AppendLine("    {")
        .AppendLine("        _logger = logger;")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public async Task<TResponse> Handle(")
        .AppendLine("        TRequest request,")
        .AppendLine("        RequestHandlerDelegate<TResponse> next,")
        .AppendLine("        CancellationToken cancellationToken")
        .AppendLine("    )")
        .AppendLine("    {")
        .AppendLine("        try")
        .AppendLine("        {")
        .AppendLine("            var requestName = typeof(TRequest).Name;")
        .AppendLine()
        .AppendLine("            _logger.LogInformation(")
        .AppendLine("                \"[UTC: {date}] Handle request {Name} {@Request}\",")
        .AppendLine("                DateTime.UtcNow,")
        .AppendLine("                requestName,")
        .AppendLine("                request")
        .AppendLine("            );")
        .AppendLine("            return await next();")
        .AppendLine("        }")
        .AppendLine("        catch (Exception ex)")
        .AppendLine("        {")
        .AppendLine("            var requestName = typeof(TRequest).Name;")
        .AppendLine()
        .AppendLine("            _logger.LogError(")
        .AppendLine("                ex,")
        .AppendLine("                $\"[UTC: {DateTime.UtcNow}] Exception for Request {requestName} {request}. ExceptionName: {ex.Message}\"")
        .AppendLine("            );")
        .AppendLine("            throw;")
        .AppendLine("        }")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
