using FluentValidation;

namespace MovieStore.Operations.DirectorOperations.GetDirector
{
    public class GetDirectorQueryDetailValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorQueryDetailValidator()
        {
            RuleFor(request => request.DirectorId).GreaterThan(0);
        }
    }
}
