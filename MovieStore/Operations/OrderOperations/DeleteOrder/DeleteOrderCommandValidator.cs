using FluentValidation;

namespace MovieStore.Operations.OrderOperations.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(request => request.OrderId).GreaterThan(0);
        }
    }
}
