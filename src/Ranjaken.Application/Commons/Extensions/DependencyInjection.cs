using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ranjaken.Application.Commons.Utils.Behaviors;
using Ranjaken.Application.Features.Users.Command.CreatePlayer;
using System.Reflection;

namespace Ranjaken.Application.Commons.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Features.Players.Query.GetPlayerById.GetPlayerByIdQuery).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreatePlayerCommand).Assembly);
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}