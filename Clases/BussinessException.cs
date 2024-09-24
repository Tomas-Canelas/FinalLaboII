public class BusinessException : Exception
{
    // Constructor que solo recibe el mensaje
    public BusinessException(string message) : base(message)
    {
    }

    // Constructor que recibe el mensaje y una InnerException
    public BusinessException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}