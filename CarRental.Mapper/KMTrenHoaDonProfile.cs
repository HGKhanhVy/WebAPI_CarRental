using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMLoaiXe;
using CarRental.Core.Models.KMTrenHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class KMTrenHoaDonProfile : Profile
    {
        public KMTrenHoaDonProfile()
        {
            CreateMap<KMTrenHoaDonModel, KMTrenHoaDonEntity>()
                .ForMember(x => x.IDKhuyenMai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
