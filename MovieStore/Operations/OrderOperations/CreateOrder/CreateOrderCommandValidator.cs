using FluentValidation;

namespace MovieStore.Operations.OrderOperations.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(request => request.Model.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(request => request.Model.TotalPrice).NotEmpty();
        }
    }
}
