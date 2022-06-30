namespace Core.Exceptions;

public class ProductDoesntExistException : Exception
{
    public ProductDoesntExistException()
        : base($"Product doesnt exist!")
    {
    }
}