namespace LibraryApp.Application.Books.Queries.GetBooksByTitle
{
    using FluentValidation;

    public class GetBooksByTitleQueryValidator : AbstractValidator<GetBooksByTitleQuery>
    {

        public GetBooksByTitleQueryValidator()
        {
            this.RuleFor(r => r.Page)
                .NotEmpty();

            this.RuleFor(r => r.Size)
                .NotEmpty();

            this.RuleFor(r => r.Title)
                .NotEmpty();
        }
    }
}