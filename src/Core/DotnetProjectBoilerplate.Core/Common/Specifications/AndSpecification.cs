using System.Linq.Expressions;

namespace DotnetProjectBoilerplate.Core.Common.Specifications;

public class AndSpecification<T> : Specification<T>
{
    private Specification<T> _left;
    private Specification<T> _right;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        var parameterExpression = Expression.Parameter(typeof(T));
        var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
        andExpression = (BinaryExpression)
            new ParameterReplacer(parameterExpression).Visit(andExpression);

        return Expression.Lambda<Func<T, bool>>(andExpression, parameterExpression);
    }
}
