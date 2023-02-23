using FluentValidation;

namespace MovieStore.Operations.MovieOperations.GetMovie
{
    public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
    {
        public GetMovieDetailQueryValidator()
        {
            RuleFor(request => request.MovieId).GreaterThan(0);
        }
    }
}
