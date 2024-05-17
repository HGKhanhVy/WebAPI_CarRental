using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMLoaiKH;
using CarRental.Core.Models.KMLoaiXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class KMLoaiXeProfile : Profile
    {
        public KMLoaiXeProfile()
        {
            CreateMap<KMLoaiXeModel, KMLoaiXeEntity>()
                .ForMember(x => x.IDKhuyenMai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
