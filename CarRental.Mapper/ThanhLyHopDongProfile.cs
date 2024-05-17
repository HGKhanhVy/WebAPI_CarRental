using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ThamDinhXe;
using CarRental.Core.Models.ThanhLyHopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class ThanhLyHopDongProfile : Profile
    {
        public ThanhLyHopDongProfile()
        {
            CreateMap<ThanhLyHopDongModel, ThanhLyHopDongEntity>()
                .ForMember(x => x.IDThanhLy, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
