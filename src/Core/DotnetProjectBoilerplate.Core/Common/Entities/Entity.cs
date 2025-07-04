namespace DotnetProjectBoilerplate.Core.Common.Entities;

public abstract class Entity<TId>
{
    public TId? Id { get; set; }
}
