using FluentValidation;

namespace MovieStore.Operations.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(request => request.Model.Name).NotEmpty();
            RuleFor(request => request.Model.Surname).NotEmpty();
        }
    }
}
