using FluentValidation;

namespace MovieStore.Operations.OrderOperations.GetOrder
{
    public class GetOrderDetailQueryValidator : AbstractValidator<GetOrderDetailQuery>
    {
        public GetOrderDetailQueryValidator()
        {
            RuleFor(request => request.OrderId).GreaterThan(0);

        }
    }
}
