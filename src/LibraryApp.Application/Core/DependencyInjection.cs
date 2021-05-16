namespace LibraryApp.Application.Core
{
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(typeof(ValidatorBehavior<,>).Assembly);

            services.AddScoped<IValidatorFactory, ValidatorFactory>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}