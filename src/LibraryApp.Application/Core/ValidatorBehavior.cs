namespace LibraryApp.Application.Core
{
    using FluentValidation;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ValidatorBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IValidatorFactory validatorFactory;

        public ValidatorBehavior(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            IValidator<TRequest> validator = this.validatorFactory.GetValidator<TRequest>();

            if (validator != null)
            {
                await validator.ValidateAndThrowAsync(request);
            }

            return await next();
        }
    }
}