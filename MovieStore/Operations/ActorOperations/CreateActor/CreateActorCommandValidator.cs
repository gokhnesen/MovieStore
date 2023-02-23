using FluentValidation;

namespace MovieStore.Operations.ActorOperations.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(request => request.Model.Surname).NotEmpty().MinimumLength(3).MaximumLength(15);
        }
    }
}
