using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.User;
using CarRental.Core.Models.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class UserPermissionProfile : Profile
    {
        public UserPermissionProfile()
        {
            CreateMap<UserPermissionModel, UserPermissionEntity>()
                .ForMember(x => x.IDUser, opt => opt.Ignore())
                .ForMember(x => x.IDPermission, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
