namespace Caticket.PartnerAPI.Domain.Exceptions;

public class IdNotFoundException(string? preMessage = null, Exception? innerException = null) : Exception($"{preMessage}: Not able to return a entity for this Id", innerException) {}