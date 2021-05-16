namespace LibraryApp.Infrastructure.Database.Core
{
    using LibraryApp.Application.Contract.Database;
    using LibraryApp.Infrastructure.Database.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            DatabaseSettings? settings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();

            if (settings is null)
            {
                throw new System.Exception();
            }

            services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(settings.ConnectionString, configuration =>
                    configuration.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName))
                );

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }

    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
}