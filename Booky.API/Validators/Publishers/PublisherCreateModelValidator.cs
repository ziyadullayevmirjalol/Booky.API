using Booky.Domain.Models.Publisher;
using FluentValidation;

namespace Booky.API.Validators.Publishers;

public class PublisherCreateModelValidator : AbstractValidator<PublisherCreateModel>
{
    public PublisherCreateModelValidator()
    {
        RuleFor(publisher => publisher.Address)
            .NotNull()
            .NotEmpty()
            .WithMessage("Address is required!");

        RuleFor(publisher => publisher.Name)
           .NotNull()
           .NotEmpty()
           .WithMessage("Name is required!");

        RuleFor(publisher => publisher.ContactNumber)
           .NotNull()
           .NotEmpty()
           .WithMessage("Contact Number is required!");
    }
}
