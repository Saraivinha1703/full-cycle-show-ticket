namespace Caticket.SalesAPI.Core.Exceptions.Spot;

public class SpotNameMustStartWithLetterException(
    string? message = null, 
    Exception? innerException = null
) : Exception(
    $"{message}: Spot name must start with an upper case letter.", 
    innerException
) {}