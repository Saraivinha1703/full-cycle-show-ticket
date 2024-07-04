namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class SpotNameRequiredException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot name is required.", 
    innerException
);