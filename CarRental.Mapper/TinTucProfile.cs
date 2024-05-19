using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.TinTuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class TinTucProfile : Profile
    {
        public TinTucProfile()
        {
            CreateMap<TinTucModel, TinTucEntity>()
                .ForMember(x => x.IDTinTuc, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
