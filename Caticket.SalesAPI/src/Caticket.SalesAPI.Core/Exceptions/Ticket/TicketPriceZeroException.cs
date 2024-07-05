namespace Caticket.SalesAPI.Core.Exceptions.Ticket;

public class TicketPriceZeroException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Ticket price must be greater than zero", 
    innerException
) 
{ }