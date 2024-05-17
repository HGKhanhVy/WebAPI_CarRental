using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.RefreshToken;
using CarRental.Core.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class RefreshTokenProfile : Profile
    {
        public RefreshTokenProfile()
        {
            CreateMap<RefreshTokenModel, RefreshTokenEntity>()
                .ForMember(x => x.IDUser, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
