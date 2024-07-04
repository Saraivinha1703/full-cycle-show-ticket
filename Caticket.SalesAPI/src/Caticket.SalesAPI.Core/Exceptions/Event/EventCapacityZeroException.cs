namespace Caticket.SalesAPI.Core.Exceptions.Event;

public class EventCapacityZeroException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Event capacity must be greater than zero.", 
    innerException
);