using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.TrangThaiBaoDuong;
using CarRental.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserEntity>()
                .ForMember(x => x.IDUser, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
