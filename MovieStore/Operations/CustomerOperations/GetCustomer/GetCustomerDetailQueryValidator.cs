using FluentValidation;

namespace MovieStore.Operations.CustomerOperations.GetCustomer
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator()
        {
            RuleFor(request => request.CustomerId).NotEmpty().GreaterThan(0);
      
        }
    }
}
