using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.TokenOperations;

namespace MovieStore.Operations.CustomerOperations.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public RefreshTokenCommand(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate >DateTime.Now);
            if(customer != null)
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _context.SaveChanges();
                return token;

            }
            else
            {
                throw new InvalidOperationException("Valid bir refresh token bulunamadı");
            }
        }
    }

}

