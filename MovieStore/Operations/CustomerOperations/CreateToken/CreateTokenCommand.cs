﻿using AutoMapper;
using MovieStore.DatabaseOperations;
using MovieStore.Entities;
using MovieStore.TokenOperations;

namespace MovieStore.Operations.CustomerOperations.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }

        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenCommand(IMovieStoreDbContext context, IMapper mapper,IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if(customer is not null)
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
                throw new InvalidOperationException("Kullanıcı adı - şifre hatalı");
            }
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        //public List<Order> Order { get; set; }
        //public List<Genre> FavoriteGenres { get; set; }

    }
}

