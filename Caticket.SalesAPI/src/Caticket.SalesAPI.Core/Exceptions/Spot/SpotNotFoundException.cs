namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class SpotNotFoundException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot not found.", 
    innerException
) {}