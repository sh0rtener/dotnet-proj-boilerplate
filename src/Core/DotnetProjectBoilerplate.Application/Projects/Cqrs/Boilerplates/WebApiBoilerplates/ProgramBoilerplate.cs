using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.WebApiBoilerplates;

public class ProgramBoilerplate : ClassBoilerplate
{
    public ProgramBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine(string.Format("using {0}.Presenters.WebApi.Middlewares;", Namespace))
        .AppendLine()
        .AppendLine("var builder = WebApplication.CreateBuilder(args);")
        .AppendLine()
        .AppendLine("builder.Services.AddEndpointsApiExplorer();")
        .AppendLine("builder.Services.AddControllers();")
        .AppendLine("builder.Services.AddSwaggerGen();")
        .AppendLine()
        .AppendLine("var app = builder.Build();")
        .AppendLine("app.UseSwagger();")
        .AppendLine("app.UseSwaggerUI();")
        .AppendLine("app.UseMiddleware<ExceptionHandlerMiddleware>();")
        .AppendLine("app.MapControllers();")
        .AppendLine()
        .AppendLine("app.Run();")
        .ToString();
}
