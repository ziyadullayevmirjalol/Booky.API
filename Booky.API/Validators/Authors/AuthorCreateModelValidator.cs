using Booky.API.Models.Author;
using FluentValidation;

namespace Booky.API.Validators.Authors;

public class AuthorCreateModelValidator : AbstractValidator<AuthorCreateModel>
{
    public AuthorCreateModelValidator()
    {
        RuleFor(author => author.FirstName)
        .NotNull()
        .NotEmpty()
        .WithMessage("Firstname is required!");

        RuleFor(author => author.LastName)
        .NotNull()
        .NotEmpty()
        .WithMessage("Lastname is required!");
    }
}
