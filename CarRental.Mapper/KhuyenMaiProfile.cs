using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KhachHang;
using CarRental.Core.Models.KhuyenMai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class KhuyenMaiProfile : Profile
    {
        public KhuyenMaiProfile()
        {
            CreateMap<KhuyenMaiModel, KhuyenMaiEntity>()
                .ForMember(x => x.IDKhuyenMai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
