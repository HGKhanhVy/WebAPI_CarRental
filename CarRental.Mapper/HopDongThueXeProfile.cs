using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HopDongKyGui;
using CarRental.Core.Models.HopDongThueXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class HopDongThueXeProfile : Profile
    {
        public HopDongThueXeProfile()
        {
            CreateMap<HopDongThueXeModel, HopDongThueXeEntity>()
                .ForMember(x => x.IDHopDongThueXe, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
