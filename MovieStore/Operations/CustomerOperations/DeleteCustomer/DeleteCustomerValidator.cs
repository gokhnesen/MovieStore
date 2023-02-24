using FluentValidation;

namespace MovieStore.Operations.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerValidator()
        {
            RuleFor(request => request.CustomerId).GreaterThan(0);

        }
    }
}
