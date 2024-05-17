using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.QuanLyChuyenKhoan;
using CarRental.Core.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IRoomService :
       Base.ICreateable<RoomModel, string>,
       Base.IUpdateable<RoomModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<RoomEntity, string>,
       Base.ICounteable<RoomModel, int>
    {
    }
}
