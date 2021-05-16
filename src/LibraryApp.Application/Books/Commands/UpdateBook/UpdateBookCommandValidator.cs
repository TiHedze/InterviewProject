namespace LibraryApp.Application.Books.Commands.UpdateBook
{
    using FluentValidation;
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {

            this.RuleFor(r => r.AuthorId)
                .NotEmpty();

            this.RuleFor(r => r.Id)
                .NotEmpty();

            this.RuleFor(r => r.Title)
                .NotEmpty();
        }
    }
}
