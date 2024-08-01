using FluentValidation;
using FluentValidation.Results;

namespace Caticket.SalesAPI.Web.Filters;

public class ValidationFilter<T>(IValidator<T> validator) : IEndpointFilter where T : class {
    private readonly IValidator<T> _validator = validator;

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (context.Arguments.FirstOrDefault(a => a?.GetType() == typeof(T)) is not T dto) 
            return await next(context);

        ValidationResult result = await _validator.ValidateAsync(dto);

        if(!result.IsValid) 
            return Results.Json(new { success = false, errors = result.Errors.Select(e => e.ErrorMessage).ToArray() }, statusCode: StatusCodes.Status400BadRequest);
        
        return await next(context);
    }
}