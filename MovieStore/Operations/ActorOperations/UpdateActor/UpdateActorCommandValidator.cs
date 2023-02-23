using FluentValidation;

namespace MovieStore.Operations.ActorOperations.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty().MinimumLength(3).MaximumLength(15);
            RuleFor(request => request.Model.Surname).NotEmpty().MinimumLength(3).MaximumLength(15);


        }
    }
}
