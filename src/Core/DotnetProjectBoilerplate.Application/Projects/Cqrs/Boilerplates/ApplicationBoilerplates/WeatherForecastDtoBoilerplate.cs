using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class WeatherForecastDtoBoilerplate : ClassBoilerplate
{
    public WeatherForecastDtoBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine(string.Format("namespace {0}.Application.Features.Weather;", Namespace))
        .AppendLine()
        .AppendLine("public class WeatherForecastDto")
        .AppendLine("{")
        .AppendLine("   public int Temperature { get; set; } = 30; ")
        .AppendLine("}")
        .ToString();
}
