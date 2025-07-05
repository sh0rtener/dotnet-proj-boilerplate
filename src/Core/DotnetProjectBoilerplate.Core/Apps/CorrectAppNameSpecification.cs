using System.Linq.Expressions;

namespace DotnetProjectBoilerplate.Core.Apps;

public class CorrectAppNameSpecification : Specification<string>
{
    private string _value;

    public CorrectAppNameSpecification(string value) => _value = value;

    public override Expression<Func<string, bool>> ToExpression() =>
        x => !string.IsNullOrEmpty(_value) && _value.Length >= 3 && _value.Length <= 50;
}
