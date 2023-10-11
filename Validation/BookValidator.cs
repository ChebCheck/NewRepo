using FluentValidation;
using FluentValidation.AspNetCore;
using WebApplication1.Models;

namespace WebApplication1.validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(book => book.Title)
                .MaximumLength(50)
                .NotNull()
                .NotEmpty()
                .WithMessage("Title is required and must be not longer then 50 characters.");

            RuleFor(book => book.Ganre)
                .Must(book => book.All(Char.IsLetter))
                .MaximumLength(50);

            RuleFor(book => book.Descriprtion)
                .MaximumLength(255);
        }

        public bool IsValid(Book book)
        {
            var result =  this.Validate(book);

            return result.IsValid;
        }
    }
}
