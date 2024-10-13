using bookApp.Models;
using FluentValidation;
using System.Text.RegularExpressions;

namespace bookApp.Validation
{
    public class BookPositionValidator : AbstractValidator<BookPosition>
    {
        private readonly BookAppContext _bookAppContext;

        public BookPositionValidator(BookAppContext bookAppContext)
        {
            this._bookAppContext = bookAppContext;
            RuleFor(bp => bp.SellingPrice)
                .NotEmpty()
                .When(x => x.IsTransferableToStore)
                .WithMessage("Sales Price is required when the item is available for sale.");

            //RuleFor(bp => bp.IsTransferableToStore)
            //    .Must(value => value == true)
            //    .When(x => 1<2)
            //    .WithMessage("IsTransferableToStore is required when the Sales Price is available for sale.");

            RuleFor(bp => bp.Book.ISBN).Custom((value, context) =>
            {
                if (value == null)
                {
                    context.AddFailure("ISBN cannot be empty");
                    return;
                }

                Regex isbnRegex = new Regex(@"^(?:\d{9}X|\d{10}|\d{3}-\d{1,5}-\d{1,7}-\d{1,6}-[\dX]|\d{13}|\d{3}-\d{10})$");
                if (!isbnRegex.IsMatch(value))
                {
                    context.AddFailure("Wrong ISBN format");
                    return;
                }

                var bookPosition = _bookAppContext.BookPositions.FirstOrDefault(bp => bp.Book.ISBN == value.Trim());
                if (bookPosition != null)
                {
                    context.AddFailure(@$"Book with {value} already exists");
                }
            });



        }


    }
}
