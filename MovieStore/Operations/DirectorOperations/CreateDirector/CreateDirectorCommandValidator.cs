using FluentValidation;

namespace MovieStore.Operations.DirectorOperations.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(request => request.Model.Surname).NotEmpty().MinimumLength(3).MaximumLength(15);

        }
    }
}
