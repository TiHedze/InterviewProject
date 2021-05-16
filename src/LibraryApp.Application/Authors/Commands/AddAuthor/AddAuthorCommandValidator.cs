namespace LibraryApp.Application.Authors.Commands.AddAuthor
{
    using FluentValidation;
    using LibraryApp.Application.Authors.Common;
    using LibraryApp.Application.Contract.Database;
    using System.Threading.Tasks;

    public class AddAuthorCommandValidator : AbstractValidator<AddAuthorCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddAuthorCommandValidator(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.RuleFor(r => r)
                .MustAsync(async (dto, _, _) => await this.AuthorExistsAsync(dto.FirstName, dto.LastName))
                .WithName("General")
                .WithMessage(AuthorValidationMessages.AuthorAlreadyExists);

            this.RuleFor(r => r.FirstName)
                .NotEmpty();

            this.RuleFor(r => r.LastName)
                .NotEmpty();
        }

        public async Task<bool> AuthorExistsAsync(string firstName, string lastName)
        {
            return await this.unitOfWork.Authors.FindAuthorByFullNameAsync(firstName, lastName) is null;
        }
    }
}