using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Permission;
using CarRental.Core.Models.PhongBan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class PhongBanProfile : Profile
    {
        public PhongBanProfile()
        {
            CreateMap<PhongBanModel, PhongBanEntity>()
                .ForMember(x => x.IDPhongBan, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
