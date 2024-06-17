﻿using MediatR;
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
}
