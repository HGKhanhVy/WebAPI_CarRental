using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginModel, LoginEntity>()
                .ForMember(x => x.Email, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
