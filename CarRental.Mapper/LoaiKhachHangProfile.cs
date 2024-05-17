using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.LichXe;
using CarRental.Core.Models.LoaiKhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class LoaiKhachHangProfile : Profile
    {
        public LoaiKhachHangProfile()
        {
            CreateMap<LoaiKhachHangModel, LoaiKhachHangEntity>()
                .ForMember(x => x.IDLoaiKH, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
