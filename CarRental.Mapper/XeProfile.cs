using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.User;
using CarRental.Core.Models.Xe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class XeProfile : Profile
    {
        public XeProfile()
        {
            CreateMap<XeModel, XeEntity>()
                .ForMember(x => x.IDXe, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
