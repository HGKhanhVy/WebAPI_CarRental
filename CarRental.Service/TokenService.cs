using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.Token;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(ITokenService))]
    public class TokenService : Base.Service, ITokenService, IRefreshTokenService, IAccessTokenService
    {

        private readonly ITokenRepository _tokenRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IAccessTokenRepository _accessTokenRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public TokenService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _tokenRepository = serviceProvider.GetRequiredService<ITokenRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public RefreshTokenEntity CheckExistsToken(TokenModel model)
        {
            throw new NotImplementedException();
        }

        public int SaveTokenToDB(string accessToken, string refreshToken, string idUser, string tokenID)
        {
            // Save db
            var tokenEntity = new TokenEntity
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
            _tokenRepository.Add(tokenEntity);
            UnitOfWork.SaveChange();

            var refreshTokenEntity = new RefreshTokenEntity
            {
                Token = refreshToken,
                IDUser = idUser,
                JwtID = tokenID,
                IsUsed = true,
                IsRevoked = false,
                ExpireAt = DateTime.UtcNow.AddHours(1)
            };
            _refreshTokenRepository.Add(refreshTokenEntity);
            UnitOfWork.SaveChange();

            var accessTokenEntity = new AccessTokenEntity
            {
                Token = accessToken,
                IDUser = idUser,
                IsUsed = true,
                IsRevoked = false,
                ExpireAt = DateTime.UtcNow.AddHours(1)
            };
            _accessTokenRepository.Add(accessTokenEntity);
            UnitOfWork.SaveChange();
            return 1;
        }
    }
}