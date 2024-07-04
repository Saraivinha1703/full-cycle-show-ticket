namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class InvalidSpotQuantityException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot quantity must be greater than zero.", 
    innerException
) { }