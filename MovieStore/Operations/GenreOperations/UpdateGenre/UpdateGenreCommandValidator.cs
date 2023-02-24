using FluentValidation;

namespace MovieStore.Operations.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommandValidator: AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(request => request.Model.Name).MinimumLength(4);
        }
    }
}
