using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.LoaiKhachHang;
using CarRental.Core.Models.LoaiXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class LoaiXeProfile : Profile
    {
        public LoaiXeProfile()
        {
            CreateMap<LoaiXeModel, LoaiXeEntity>()
                .ForMember(x => x.IDLoaiXe, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
