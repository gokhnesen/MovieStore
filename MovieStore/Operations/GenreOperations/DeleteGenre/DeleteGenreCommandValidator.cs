using FluentValidation;

namespace MovieStore.Operations.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(request => request.GenreId).GreaterThan(0);
        }
    }
}
