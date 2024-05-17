using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HoaDonKyGui;
using CarRental.Core.Models.HoaDonThueXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class HoaDonThueXeProfile : Profile
    {
        public HoaDonThueXeProfile()
        {
            CreateMap<HoaDonThueXeModel, HoaDonThueXeEntity>()
                .ForMember(x => x.IDHoaDonThueXe, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
