using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.LoaiXe;
using CarRental.Core.Models.NhacHen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class NhacHenProfile : Profile
    {
        public NhacHenProfile()
        {
            CreateMap<NhacHenModel, NhacHenEntity>()
                .ForMember(x => x.IDNhacHen, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
