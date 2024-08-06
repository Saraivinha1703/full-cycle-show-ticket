namespace Caticket.PartnerAPI.Domain.Exceptions;

public class InvalidEnumerationException(
    string? message = null,
    Exception? innerException = null
) : Exception($"{message}: This key is invalid, check if it matches the key in the enumerator.", innerException) {

}