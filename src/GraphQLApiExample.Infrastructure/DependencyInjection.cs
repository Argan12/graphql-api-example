using GraphQLApiExample.Application.Common.Interfaces;
using GraphQLApiExample.Infrastructure.Entities;
using GraphQLApiExample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLApiExample.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GraphQLApiExampleDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(GraphQLApiExampleDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
