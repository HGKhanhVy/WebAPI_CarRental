using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class ChucVuProfile : Profile
    {
        public ChucVuProfile()
        {
            CreateMap<ChucVuModel, ChucVuEntity>()
                .ForMember(x => x.IDChucVu, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
