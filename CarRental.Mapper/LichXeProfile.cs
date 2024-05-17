using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMVoucher;
using CarRental.Core.Models.LichXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class LichXeProfile : Profile
    {
        public LichXeProfile()
        {
            CreateMap<LichXeModel, LichXeEntity>()
                .ForMember(x => x.IDLichXe, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
