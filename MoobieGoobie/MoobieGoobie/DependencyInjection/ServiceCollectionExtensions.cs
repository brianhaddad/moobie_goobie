using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MoobieGoobie.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddManyScoped<T>(this IServiceCollection services, IEnumerable<Assembly> assemblies) where T : class
        {
            var interfaceType = typeof(T);
            if (!interfaceType.IsInterface)
            {
                throw new RegistrationException($"Cannot scan for non-interface type {interfaceType.Name}.");
            }

            var registrations = new List<Type>();

            foreach (var assembly in assemblies)
            {
                var found = assembly.GetTypes().Where(t => !(t.IsInterface || t.IsAbstract) && t.GetInterfaces().Contains(interfaceType));
                foreach (var t in found)
                {
                    services.AddScoped(interfaceType, t);
                }
                registrations.AddRange(found);
            }

            if (!registrations.Any())
            {
                throw new RegistrationException($"No implementations of {interfaceType.Name} found in the provided assemblies.");
            }

            return services;
        }

        public static IServiceCollection AddManyScoped<T>(this IServiceCollection services, Assembly assembly) where T : class
            => services.AddManyScoped<T>(new[] { assembly });

        public static IServiceCollection AddManyScoped<T>(this IServiceCollection services) where T : class
            => services.AddManyScoped<T>(typeof(T).Assembly);
    }
}
