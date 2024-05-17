using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Permission;
using CarRental.Core.Models.PermissionDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionModel, PermissionEntity>()
                .ForMember(x => x.IDPermission, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
