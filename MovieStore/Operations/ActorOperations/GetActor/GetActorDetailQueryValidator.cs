using FluentValidation;

namespace MovieStore.Operations.ActorOperations.GetActor
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(request => request.ActorId).GreaterThan(0);
        }
    }
}
