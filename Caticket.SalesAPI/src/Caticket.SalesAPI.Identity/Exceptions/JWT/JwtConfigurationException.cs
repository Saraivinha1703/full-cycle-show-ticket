namespace Caticket.SalesAPI.Identity.Exceptions.JWT;

public class JwtConfigurationException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"Error during JWT Configuration: {message}", 
    innerException
) 
{}