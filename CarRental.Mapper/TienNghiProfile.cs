using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ThanhLyHopDong;
using CarRental.Core.Models.TienNghi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class TienNghiProfile : Profile
    {
        public TienNghiProfile()
        {
            CreateMap<TienNghiModel, TienNghiEntity>()
                .ForMember(x => x.IDTienNghi, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
