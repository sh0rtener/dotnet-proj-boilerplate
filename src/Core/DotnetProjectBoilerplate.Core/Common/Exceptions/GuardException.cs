using DotnetProjectBoilerplate.Core.Common.Specifications;

namespace DotnetProjectBoilerplate.Core.Common.Exceptions;

public static class GuardException
{
    public static string ThrowIfInputIsInvalidFormat(
        Specification<string> specification,
        string input,
        string inputName
    )
    {
        if (!specification.ToExpression().Compile().Invoke(input))
            throw new InvalidInputException(inputName);

        return input;
    }

    public static string ThrowIfInvalidPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new DirectoryNotFoundException(path);

        if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            throw new DirectoryNotFoundException(path);

        Path.GetFullPath(path);
        return path;
    }
}
