using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.SoDienThoai;
using CarRental.Core.Models.ThamDinhXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class ThamDinhXeProfile : Profile
    {
        public ThamDinhXeProfile()
        {
            CreateMap<ThamDinhXeModel, ThamDinhXeEntity>()
                .ForMember(x => x.IDThamDinh, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
