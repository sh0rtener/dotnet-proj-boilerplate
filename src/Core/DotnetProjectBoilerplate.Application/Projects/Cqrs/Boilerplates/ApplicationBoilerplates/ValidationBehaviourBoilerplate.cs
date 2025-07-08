using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class ValidationBehaviourBoilerplate : ClassBoilerplate
{
    public ValidationBehaviourBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using FluentValidation;")
        .AppendLine("using MediatR;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Application.Behaviours;", Namespace))
        .AppendLine()
        .AppendLine("public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>")
        .AppendLine("    where TRequest : notnull")
        .AppendLine("{")
        .AppendLine("    private readonly IEnumerable<IValidator<TRequest>> _validators;")
        .AppendLine()
        .AppendLine("    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)")
        .AppendLine("    {")
        .AppendLine("        _validators = validators;")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    public async Task<TResponse> Handle(")
        .AppendLine("        TRequest request,")
        .AppendLine("        RequestHandlerDelegate<TResponse> next,")
        .AppendLine("        CancellationToken cancellationToken")
        .AppendLine("    )")
        .AppendLine("    {")
        .AppendLine("        if (_validators.Any())")
        .AppendLine("        {")
        .AppendLine("            var context = new ValidationContext<TRequest>(request);")
        .AppendLine()
        .AppendLine("            var validationResult = await Task.WhenAll(")
        .AppendLine("                _validators.Select(v => v.ValidateAsync(context, cancellationToken))")
        .AppendLine("            );")
        .AppendLine()
        .AppendLine("            var failures = validationResult")
        .AppendLine("                .Where(r => r.Errors.Any())")
        .AppendLine("                .SelectMany(r => r.Errors)")
        .AppendLine("                .GroupBy(x => x.PropertyName, e => e.ErrorMessage)")
        .AppendLine("                .ToDictionary(f => f.Key, f => f.ToArray());")
        .AppendLine()
        .AppendLine("            if (failures.Any())")
        .AppendLine("                throw new Common.Exceptions.ValidationException(failures);")
        .AppendLine("        }")
        .AppendLine()
        .AppendLine("        return await next();")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
