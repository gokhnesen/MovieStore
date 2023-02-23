using FluentValidation;

namespace MovieStore.Operations.MovieOperations.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(request => request.Model.Actor).NotEmpty();
        }
    }
}
