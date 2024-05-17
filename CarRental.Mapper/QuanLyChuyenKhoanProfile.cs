using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.PhongBan;
using CarRental.Core.Models.QuanLyChuyenKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class QuanLyChuyenKhoanProfile : Profile
    {
        public QuanLyChuyenKhoanProfile()
        {
            CreateMap<QuanLyChuyenKhoanModel, QuanLyChuyenKhoanEntity>()
                .ForMember(x => x.IDQuanLyCK, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
