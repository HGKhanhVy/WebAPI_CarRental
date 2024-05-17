using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HoaDonKyGui;
using CarRental.Core.Models.HopDongKyGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class HopDongKyGuiProfile : Profile
    {
        public HopDongKyGuiProfile()
        {
            CreateMap<HopDongKyGuiModel, HopDongKyGuiEntity>()
                .ForMember(x => x.IDHopDongKyGui, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
