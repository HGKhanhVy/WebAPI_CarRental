using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Xe;
using CarRental.Core.Models.XeTienNghi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class XeTienNghiProfile : Profile
    {
        public XeTienNghiProfile()
        {
            CreateMap<XeTienNghiModel, XeTienNghiEntity>()
                .ForMember(x => x.IDXe, opt => opt.Ignore())
                .ForMember(x => x.IDTienNghi, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
