using AngleSharp.Io;
using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Models;
using CarRental.Core.Models.Token;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(IRefreshTokenService))]
    public class RefreshTokenService : Base.Service, IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public RefreshTokenService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _refreshTokenRepository = serviceProvider.GetRequiredService<IRefreshTokenRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public RefreshTokenEntity CheckExistsToken(TokenModel model)
        {
            var storedToken = _refreshTokenRepository.GetTracking(x => x.Token.Equals(model.RefreshToken)).FirstOrDefault();
            if (storedToken == null)
            {
                return null;
            }
            return storedToken;
        }
    }
}
