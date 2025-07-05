namespace DotnetProjectBoilerplate.Core.Common.Exceptions;

public class InvalidInputException : CoreException
{
    private string _input;

    public InvalidInputException(string input)
    {
        _input = input;
    }

    public override string Message => string.Format("Input field {0} has incorrect format", _input);
}
