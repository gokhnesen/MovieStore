using FluentValidation;

namespace MovieStore.Operations.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty();
            RuleFor(request => request.Model.Surname).NotEmpty();
            RuleFor(request => request.Model.Movies).NotEmpty();

        }
    }
}
