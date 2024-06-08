using CarRental.Contract.Repository.Models;
using CarRental.Contract.Repository.Models.VnPay;
using CarRental.Core.Models.ChucVu;
using CarRental.Core.Models.HoaDonKyGui;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IHoaDonKyGuiService :
       Base.ICreateable<HoaDonKyGuiModel, string>,
       Base.IUpdateable<HoaDonKyGuiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HoaDonKyGuiEntity, string>,
       Base.ICounteable<HoaDonKyGuiModel, int>,
       Base.IPrintByID<HoaDonKyGuiEntity, string>
    {
        public Task CapNhatTrangThaiThanhToan(string Id);
        string CreatePaymentUrl(string idhoadon, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
        Task SavePaymentData(PaymentResponseModel collections);
    }
}
