namespace Core.Exceptions;

public class UserDoesntExistException : Exception
{
    public UserDoesntExistException()
        : base($"User doesnt exist!")
    {
    }
}