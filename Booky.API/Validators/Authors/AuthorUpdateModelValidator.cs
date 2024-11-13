using Booky.Domain.Models.Author;
using FluentValidation;

namespace Booky.API.Validators.Authors;

public class AuthorUpdateModelValidator : AbstractValidator<AuthorUpdateModel>
{
    public AuthorUpdateModelValidator()
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
