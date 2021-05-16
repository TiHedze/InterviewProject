namespace LibraryApp.Application.Authors.Commands.AddBook
{
    using FluentValidation;
    using LibraryApp.Application.Authors.Common;
    using LibraryApp.Application.Contract.Database;

    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        private readonly IUnitOfWork unitOfWork;
        public AddBookCommandValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.RuleFor(r => r)
                .MustAsync(async (book, _, _) => await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(book.AuthorId) is null)
                .WithName("General")
                .WithMessage(AuthorValidationMessages.AuthorDoesntExist);

            this.RuleFor(r => r.Title)
                .NotEmpty();
        }
    }
}