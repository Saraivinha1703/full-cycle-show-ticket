namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class SpotNameMustEndWithNumberException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot name must end with a number.", 
    innerException
) {}