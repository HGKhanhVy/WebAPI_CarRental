using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.NhacHen;
using CarRental.Core.Models.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class NhanVienProfile : Profile
    {
        public NhanVienProfile()
        {
            CreateMap<NhanVienModel, NhanVienEntity>()
                .ForMember(x => x.IDNhanVien, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
