using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.User;
using CarRental.Core.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            CreateMap<TokenModel, TokenEntity>()
                .ForMember(x => x.AccessToken, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
