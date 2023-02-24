using FluentValidation;

namespace MovieStore.Operations.OrderOperations.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(request => request.Model.CustomerId).GreaterThan(0);
            RuleFor(request => request.Model.TotalPrice).GreaterThan(0);
        }
    }
}
