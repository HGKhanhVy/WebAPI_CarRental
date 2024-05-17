using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HopDongThueXe;
using CarRental.Core.Models.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class KhachHangProfile : Profile
    {
        public KhachHangProfile()
        {
            CreateMap<KhachHangModel, KhachHangEntity>()
                .ForMember(x => x.IDKhachHang, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
