using FluentValidation;

namespace MovieStore.Operations.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(request => request.MovieId).GreaterThan(0);
        }
    }
}
