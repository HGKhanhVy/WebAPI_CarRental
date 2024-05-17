using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KhuyenMai;
using CarRental.Core.Models.KMLoaiKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class KMLoaiKHProfile : Profile
    {
        public KMLoaiKHProfile()
        {
            CreateMap<KMLoaiKHModel, KMLoaiKHEntity>()
                .ForMember(x => x.IDKhuyenMai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
