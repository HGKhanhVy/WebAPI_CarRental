using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ChucVu;
using CarRental.Core.Models.HoaDonKyGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class HoaDonKyGuiProfile : Profile
    {
        public HoaDonKyGuiProfile()
        {
            CreateMap<HoaDonKyGuiModel, HoaDonKyGuiEntity>()
                .ForMember(x => x.IDHoaDonKyGui, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
