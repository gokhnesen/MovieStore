using FluentValidation;

namespace MovieStore.Operations.GenreOperations.GetGenre
{
    public class GetGenreDetailQueryValidiator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidiator()
        {
            RuleFor(request => request.GenreId).GreaterThan(0);
        }
    }
}
