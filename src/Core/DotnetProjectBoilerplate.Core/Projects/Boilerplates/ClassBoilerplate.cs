namespace DotnetProjectBoilerplate.Core.Projects.Boilerplates;

public abstract class ClassBoilerplate : Boilerplate
{
    public string Namespace { get; private set; }

    public ClassBoilerplate(string namespaceName)
    {
        Namespace = namespaceName;
    }
}
