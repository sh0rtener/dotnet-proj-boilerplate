using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.WebApiBoilerplates;

public class WeatherControllerBoilerplate : ClassBoilerplate
{
    public WeatherControllerBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using Microsoft.AspNetCore.Mvc;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Presenters.WebApi.Controllers;", Namespace))
        .AppendLine()
        .AppendLine("[Route(\"api/weather\")]")
        .AppendLine("[ApiController]")
        .AppendLine("public class WeatherController : ControllerBase")
        .AppendLine("{")
        .AppendLine("   [HttpGet]")
        .AppendLine("   public async Task<IActionResult> GetWeather(CancellationToken cancellationToken)")
        .AppendLine("   {")
        .AppendLine("       // logic here")
        .AppendLine("       return Ok();")
        .AppendLine("   }")
        .AppendLine("}")
        .ToString();
}
