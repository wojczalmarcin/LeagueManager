using FluentValidation;
using FluentValidation.Results;
using System.Reflection;

namespace LeagueManager.WebApi;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public class ValidateAttribute : Attribute
{
}

public static class ValidationFilters
{
    public static EndpointFilterDelegate FluentValidationFilterFactory(EndpointFilterFactoryContext context, EndpointFilterDelegate next)
    {
        var validators = GetValidators(context.MethodInfo, context.ApplicationServices);

        if (validators.Any())
        {
            return async invocationContext =>
            {
                var finalVlidationResult = new ValidationResult();

                foreach (var (validator, paramIndex) in validators)
                {
                    var result = await validator.ValidateAsync(
                        new ValidationContext<object>(invocationContext.Arguments[paramIndex]!));
                    finalVlidationResult.Errors.AddRange(result.Errors);
                }
                
                if (!finalVlidationResult.IsValid)
                {
                    return Results.ValidationProblem(finalVlidationResult.ToDictionary());
                }
                return await next(invocationContext);
            };
        }

        return invocationContext => next(invocationContext);
    }


    private static IEnumerable<(IValidator validator, int paramIndex)> GetValidators(MethodInfo methodInfo, IServiceProvider serviceProvider)
    {
        var parameters = methodInfo.GetParameters();

        foreach (var parameter in parameters)
        {
            var paramType = parameter.GetType();
            var validatorType = typeof(IValidator<>).MakeGenericType(paramType);
            var validator = serviceProvider.GetService(validatorType);

            if (validator is not null)
                yield return ((IValidator)validator, parameter.Position);
        }
    }
}