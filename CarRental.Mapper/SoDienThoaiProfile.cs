using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.SoDienThoai;

namespace CarRental.Mapper
{
    public class SoDienThoaiProfile : Profile
    {
        public SoDienThoaiProfile()
        {
            CreateMap<SoDienThoaiModel, SoDienThoaiEntity>()
                .ForMember(x => x.DauSo, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
