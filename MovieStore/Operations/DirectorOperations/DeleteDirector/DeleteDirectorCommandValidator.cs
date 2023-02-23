using FluentValidation;

namespace MovieStore.Operations.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(request => request.DirectorId).GreaterThan(0);
        }
    }
}
