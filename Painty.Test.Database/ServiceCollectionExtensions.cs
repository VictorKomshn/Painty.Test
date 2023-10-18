using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;
using Painty.Test.Database.Context;
using Painty.Test.Database.Options;
using Painty.Test.Database.Repositories;
using Painty.Test.Database.Repositories.Abstract;

namespace Painty.Test.Database
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>();
            services.AddSingleton(provider =>
            {
                var postgresOptions = new DatabaseOptions();
                config.Bind(DatabaseOptions.SectionName, postgresOptions);
                var connectionBuilder = new NpgsqlConnectionStringBuilder
                {
                    Host = postgresOptions.Host,
                    Port = postgresOptions.Port,
                    Username = postgresOptions.Username,
                    Password = postgresOptions.Password,
                    Database = postgresOptions.Database,

                };

                var builder = new DbContextOptionsBuilder<DataContext>()
                    .UseNpgsql(connectionBuilder.ToString()).EnableSensitiveDataLogging();

                return builder.Options;
            });


            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            var provider = services.BuildServiceProvider();
            var postgresOptions = provider.GetRequiredService<IOptions<DatabaseOptions>>().Value;

            //using var scope = provider.CreateScope();
            //using var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            //dataContext.Database.EnsureCreated();

            return services;
        }
    }
}
