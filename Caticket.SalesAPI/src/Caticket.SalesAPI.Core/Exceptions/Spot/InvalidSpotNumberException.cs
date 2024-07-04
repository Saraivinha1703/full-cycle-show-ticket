namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class InvalidSpotNumberException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Invalid Spot number.", 
    innerException
) {}