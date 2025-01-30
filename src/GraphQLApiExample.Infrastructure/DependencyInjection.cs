using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQLApiExample.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<CleanArchitectureDbContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("CleanArchitectureContext"),
            //        b => b.MigrationsAssembly(typeof(CleanArchitectureDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            //services.AddScoped<ICleanArchitectureDbContext>(provider => provider.GetService<CleanArchitectureDbContext>());

            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            //services.AddScoped<IJwtService, JwtService>();
            //services.AddScoped<IPasswordService, PasswordService>();
            //services.AddScoped<IArticleRepository, ArticleRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
