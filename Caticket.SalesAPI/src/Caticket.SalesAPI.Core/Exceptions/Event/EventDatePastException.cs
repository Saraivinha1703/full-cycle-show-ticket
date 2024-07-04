namespace Caticket.SalesAPI.Core.Exceptions.Event;

public class EventDatePastException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Event date must be in the future.", 
    innerException
);