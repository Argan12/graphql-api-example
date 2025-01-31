using GraphQLApiExample.Application.Features.User.Handlers.Mutations;
using GraphQLApiExample.Application.Features.User.Handlers.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLApiExample.Application
{
    public static class DependencyInjection
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            // User resources
            services.AddScoped<UserMutationHandler>();
            services.AddScoped<UserQueryHandler>();
        }
    }
}
