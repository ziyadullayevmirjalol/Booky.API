using Booky.Domain.Models.Review;
using FluentValidation;

namespace Booky.API.Validators.Reviiews;

public class ReviewCreateModelValidator : AbstractValidator<ReviewCreateModel>
{
    public ReviewCreateModelValidator()
    {
        RuleFor(review => review.Content)
           .NotNull()
           .NotEmpty()
           .WithMessage("Content is required!");

        RuleFor(review => review.Rating)
           .NotNull()
           .NotEmpty()
           .NotEqual(0)
           .WithMessage("Rating is required!");

        RuleFor(review => review.BookId)
           .NotNull()
           .NotEmpty()
           .NotEqual(0)
           .WithMessage("BookId is required!");
    }
}

public class ReviewUpdateModelValidator : AbstractValidator<ReviewUpdateModel>
{
    public ReviewUpdateModelValidator()
    {
        RuleFor(review => review.Content)
           .NotNull()
           .NotEmpty()
           .WithMessage("Content is required!");

        RuleFor(review => review.Rating)
           .NotNull()
           .NotEmpty()
           .NotEqual(0)
           .WithMessage("Rating is required!");
    }
}
