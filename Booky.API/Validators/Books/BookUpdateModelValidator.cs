using Booky.Domain.Models.Book;
using FluentValidation;

namespace Booky.API.Validators.Books;

public class BookUpdateModelValidator : AbstractValidator<BookUpdateModel>
{
    public BookUpdateModelValidator()
    {
        RuleFor(book => book.Title)
         .NotNull()
         .NotEmpty()
         .WithMessage("Title is required!");

        RuleFor(book => book.Genre)
         .NotNull()
         .NotEmpty()
         .WithMessage("Genre is required!");
    }
}