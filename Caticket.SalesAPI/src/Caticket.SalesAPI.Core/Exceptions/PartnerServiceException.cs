namespace Caticket.SalesAPI.Core.Exceptions;

public class PartnerServiceException(
    string name, 
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"Something went wrong while calling the partner service at '{name}': {message}", 
    innerException
);