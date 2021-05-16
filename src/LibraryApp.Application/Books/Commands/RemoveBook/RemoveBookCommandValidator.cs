namespace LibraryApp.Application.Books.Commands.RemoveBook
{
    using FluentValidation;
    using LibraryApp.Application.Authors.Common;
    using LibraryApp.Application.Contract.Database;
    using System;

    public class RemoveBookCommandValidator : AbstractValidator<RemoveBookCommand>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveBookCommandValidator(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            this.RuleFor(r => r)
                .MustAsync(async (command, _, _) => await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(command.AuthorId) is null)
                .WithName("General")
                .WithMessage(AuthorValidationMessages.AuthorDoesntExist);

            this.RuleFor(r => r)
                .MustAsync(async (command, _, _) => await this.unitOfWork.Books.FindBookByIdSafeAsync(command.Id) is null)
                .WithName("General")
                .WithMessage(AuthorBookValidationMessages.BookDoesntExist);

            this.RuleFor(r => r)
                .MustAsync(async (command, _, _) =>
                {
                    var author = await this.unitOfWork.Authors.FindAuthorByIdSafeAsync(command.AuthorId);

                    var book = await this.unitOfWork.Books.FindBookByIdSafeAsync(command.Id);

                    var exists = author.Books.Contains(book);

                    return author is null && book is null && !exists;
                })
                .WithName("General")
                .WithMessage(AuthorBookValidationMessages.WrongAuthorBookCombination);
             
        }
    }
}
