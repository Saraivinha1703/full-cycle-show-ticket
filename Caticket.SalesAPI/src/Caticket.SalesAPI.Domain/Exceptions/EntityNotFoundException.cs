namespace Caticket.SalesAPI.Domain.Exceptions;

public class EntityNotFoundException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: This entity was not found.", 
    innerException
) {

}