using FluentValidation;

namespace MovieStore.Operations.CustomerOperations.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(request => request.Model.Password).NotEmpty();
            RuleFor(request => request.Model.Name).NotEmpty();
            RuleFor(request => request.Model.Email).NotEmpty();
            RuleFor(request => request.Model.Surname).NotEmpty();

        }
    }
}
