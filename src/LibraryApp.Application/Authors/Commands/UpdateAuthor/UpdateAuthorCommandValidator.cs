
namespace LibraryApp.Application.Authors.Commands.UpdateAuthor
{
    using FluentValidation;
    using LibraryApp.Application.Authors.Common;
    using LibraryApp.Application.Contract.Database;

    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public UpdateAuthorCommandValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.RuleFor(r => r.Id)
                .NotEmpty()
                .NotEmpty();

            this.RuleFor(r => r)
                .MustAsync(async (author, _, _) => await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(author.Id) is not null)
                .WithName("General")
                .WithMessage(AuthorValidationMessages.AuthorDoesntExist);

            this.RuleFor(r => r.FirstName)
                .NotEmpty();

            this.RuleFor(r => r.LastName)
                .NotEmpty();
        }
    }
}
