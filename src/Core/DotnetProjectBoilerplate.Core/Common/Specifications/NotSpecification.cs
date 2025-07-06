using System.Linq.Expressions;

namespace DotnetProjectBoilerplate.Core.Common.Specifications;

public class NotSpecification<T> : Specification<T>
{
    private Specification<T> _spec;

    public NotSpecification(Specification<T> spec)
    {
        _spec = spec;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        return Expression.Lambda<Func<T, bool>>(
            Expression.Not(_spec.ToExpression().Body),
            _spec.ToExpression().Parameters.Single()
        );
    }
}
