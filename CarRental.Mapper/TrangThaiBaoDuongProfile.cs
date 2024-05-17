using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.TienNghi;
using CarRental.Core.Models.TrangThaiBaoDuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class TrangThaiBaoDuongProfile : Profile
    {
        public TrangThaiBaoDuongProfile()
        {
            CreateMap<TrangThaiBaoDuongModel, TrangThaiBaoDuongEntity>()
                .ForMember(x => x.IDTrangThaiBD, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
