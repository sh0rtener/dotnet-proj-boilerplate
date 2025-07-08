using System.Linq.Expressions;

namespace DotnetProjectBoilerplate.Core.Common.Specifications;

public class OrSpecification<T> : Specification<T>
{
    private Specification<T> _left;
    private Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        var parameterExpression = Expression.Parameter(typeof(T));
        var orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
        orExpression = (BinaryExpression)
            new ParameterReplacer(parameterExpression).Visit(orExpression);

        return Expression.Lambda<Func<T, bool>>(orExpression, parameterExpression);
    }
}
