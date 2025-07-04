using System.Linq.Expressions;

public abstract class Specification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public Specification<T> And(Specification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }

    public Specification<T> Or(Specification<T> specification)
    {
        return new OrSpecification<T>(this, specification);
    }

    public Specification<T> Not(Specification<T> specification)
    {
        return new NotSpecification<T>(specification);
    }

    public bool IsSatisfiedBy(T item)
    {
        Func<T, bool> predicate = ToExpression().Compile();
        return predicate(item);
    }
}