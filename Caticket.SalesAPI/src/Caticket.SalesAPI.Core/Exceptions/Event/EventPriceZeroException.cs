namespace Caticket.SalesAPI.Core.Exceptions.Event;

public class EventPriceZeroException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Event price must be greater than zero.", 
    innerException
);