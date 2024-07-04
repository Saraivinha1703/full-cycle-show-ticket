namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class SpotAlreadyReservedException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot already reserved.", 
    innerException
) {}