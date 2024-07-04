namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class ShortSpotNameException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot name must be at least 2 characters long.", 
    innerException
) {}