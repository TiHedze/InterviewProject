namespace LibraryApp.Application.Core
{
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IValidator? GetValidator(Type type)
        {
            object? validator = this.serviceProvider.GetService(type);

            return (validator == null) ? null : validator as IValidator;
        }

        public IValidator<T>? GetValidator<T>()
        {
            return this.serviceProvider.GetService<IValidator<T>>();
        }
    }
}