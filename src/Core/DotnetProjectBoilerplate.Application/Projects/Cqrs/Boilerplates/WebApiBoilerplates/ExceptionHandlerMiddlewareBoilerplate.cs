using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.WebApiBoilerplates;

public class ExceptionHandlerMiddlewareBoilerplate : ClassBoilerplate
{
    public ExceptionHandlerMiddlewareBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using Newtonsoft.Json;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Presenters.WebApi.Middlewares;", Namespace))
        .AppendLine()
        .AppendLine("public class ExceptionHandlerMiddleware(RequestDelegate next)")
        .AppendLine("{")
        .AppendLine("    public async Task InvokeAsync(HttpContext context)")
        .AppendLine("    {")
        .AppendLine("        try")
        .AppendLine("        {")
        .AppendLine("            await next(context);")
        .AppendLine("        }")
        .AppendLine("        catch (InvalidDataException ex)")
        .AppendLine("        {")
        .AppendLine("            ErrorModel model = new() { Message = ex.Message };")
        .AppendLine("            await HandleAsync(context, model);")
        .AppendLine("        }")
        .AppendLine("        catch (Exception)")
        .AppendLine("        {")
        .AppendLine("            ErrorModel model = new() { Message = \"Internal server Error\" };")
        .AppendLine()
        .AppendLine("            context.Response.ContentType = \"application/json\";")
        .AppendLine("            context.Response.StatusCode = 500;")
        .AppendLine()
        .AppendLine("            var result = JsonConvert.SerializeObject(model);")
        .AppendLine()
        .AppendLine("            await context.Response.WriteAsync(result);")
        .AppendLine("        }")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    private async Task HandleAsync(HttpContext context, ErrorModel model)")
        .AppendLine("    {")
        .AppendLine("        context.Response.ContentType = \"application/json\";")
        .AppendLine("        context.Response.StatusCode = 400;")
        .AppendLine()
        .AppendLine("        var result = JsonConvert.SerializeObject(model);")
        .AppendLine()
        .AppendLine("        await context.Response.WriteAsync(result);")
        .AppendLine("    }")
        .AppendLine()
        .AppendLine("    private class ErrorModel")
        .AppendLine("    {")
        .AppendLine("        [JsonProperty(\"message\")]")
        .AppendLine("        public string? Message { get; set; }")
        .AppendLine()
        .AppendLine("        [JsonProperty(\"Errors\")]")
        .AppendLine("        public Dictionary<string, string[]> Errors { get; set; } = new();")
        .AppendLine("    }")
        .AppendLine("}")
        .ToString();
}
