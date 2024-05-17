using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.NhanVien;
using CarRental.Core.Models.PermissionDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class PermissionDetailProfile : Profile
    {
        public PermissionDetailProfile()
        {
            CreateMap<PermissionDetailModel, PermissionDetailEntity>()
                .ForMember(x => x.IDPermissionDetail, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
