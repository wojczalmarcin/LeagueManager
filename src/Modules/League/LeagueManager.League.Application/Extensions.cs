using FluentValidation.Results;
using LeagueManager.Shared.Abstractions.Domain;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeagueManager.League.Application;
public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }

    internal static ValidationResult Map(this DomainValidationResult validationResult)
        => new(validationResult.ValidationErrors.
            Select(x => new ValidationFailure(string.Empty, x)));
}
