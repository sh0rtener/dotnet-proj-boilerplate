using System.Linq.Expressions;

namespace DotnetProjectBoilerplate.Core.Common.Specifications;

public class ParameterReplacer : ExpressionVisitor
{
    private readonly ParameterExpression _parameter;

    protected override Expression VisitParameter(ParameterExpression node)
    {
        return base.VisitParameter(_parameter);
    }

    internal ParameterReplacer(ParameterExpression parameter)
    {
        _parameter = parameter;
    }
}
