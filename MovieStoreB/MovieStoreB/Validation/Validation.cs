using FluentValidation;
using MovieStoreB.Models.DTO.Requests;
namespace MovieStoreB.Validation
{
    public class Validation : AbstractValidator<AddMovieRequest>
    {
        public Validation() {
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Year).NotEmpty().NotNull();
        }
    }
}
