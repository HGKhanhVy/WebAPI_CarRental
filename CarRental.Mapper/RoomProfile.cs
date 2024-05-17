using AutoMapper;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.QuanLyChuyenKhoan;
using CarRental.Core.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Mapper
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomModel, RoomEntity>()
                .ForMember(x => x.IDRoom, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
