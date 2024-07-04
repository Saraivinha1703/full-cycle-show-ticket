namespace Caticket.SalesAPI.Core.Exceptions.Event;

public class EventNameRequiredException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Event name is required.", 
    innerException
);