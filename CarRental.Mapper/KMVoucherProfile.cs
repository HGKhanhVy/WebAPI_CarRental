using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMTrenHoaDon;
using CarRental.Core.Models.KMVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class KMVoucherProfile : Profile
    {
        public KMVoucherProfile()
        {
            CreateMap<KMVoucherModel, KMVoucherEntity>()
                .ForMember(x => x.IDKhuyenMai, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
