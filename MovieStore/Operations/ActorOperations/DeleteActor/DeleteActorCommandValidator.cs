using FluentValidation;

namespace MovieStore.Operations.ActorOperations.DeleteActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(request => request.ActorId).GreaterThan(0);
        }
    }
}
