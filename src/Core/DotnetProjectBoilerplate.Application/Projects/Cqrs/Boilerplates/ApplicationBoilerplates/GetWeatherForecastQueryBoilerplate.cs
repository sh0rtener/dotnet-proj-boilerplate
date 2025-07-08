using System.Text;
using DotnetProjectBoilerplate.Core.Projects.Boilerplates;

namespace DotnetProjectBoilerplate.Application.Projects.Cqrs.Boilerplates.ApplicationBoilerplates;

public class GetWeatherForecastQueryBoilerplate : ClassBoilerplate
{
    public GetWeatherForecastQueryBoilerplate(string namespaceName)
        : base(namespaceName) { }

    public override string Build() =>
        new StringBuilder()
        .AppendLine("using Automapper;")
        .AppendLine("using MediatR;")
        .AppendLine()
        .AppendLine(string.Format("namespace {0}.Core.Application.Features.Weather.GetWeather;", Namespace))
        .AppendLine()
        .AppendLine("public class GetWeatherQuery : IRequest<WeatherDto> { }")
        .AppendLine()
        .AppendLine("public class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, WeatherDto>")
        .AppendLine("{")
        .AppendLine("   public async Task<WeatherDto> Handle(GetWeatherQuery request, CancellationToken cancellationToken = default)")
        .AppendLine("   {")
        .AppendLine("       var weather = new Weather();")
        .AppendLine("       return weather;")
        .AppendLine("   }")
        .AppendLine("}")
        .ToString();
}
