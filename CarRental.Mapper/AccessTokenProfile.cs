using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.AccessToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Models.AccessToken;
using CarRental.Contract.Repository.Models;

namespace CarRental.Mapper
{
    public class AccessTokenProfile : Profile
    {
        public AccessTokenProfile()
        {
            CreateMap<AccessTokenModel, AccessTokenEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
