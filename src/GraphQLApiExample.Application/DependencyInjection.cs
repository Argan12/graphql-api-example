using FluentValidation;
using GraphQLApiExample.Application.Features.Articles.Handlers.Mutations;
using GraphQLApiExample.Application.Features.Articles.Handlers.Queries;
using GraphQLApiExample.Application.Features.User.Handlers.Mutations;
using GraphQLApiExample.Application.Features.User.Handlers.Queries;
using GraphQLApiExample.Application.Features.User.Types.Validators;
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

            // Article resources
            services.AddScoped<ArticleMutationHandler>();
            services.AddScoped<ArticleQueryHandler>();

            // Validators
            services.AddValidatorsFromAssemblyContaining<ArticleInputValidator>();
        }
    }
}
