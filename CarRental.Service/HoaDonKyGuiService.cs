using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Repository.Models.VnPay;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HoaDonKyGui;
using CarRental.Core.Models.Login;
using CarRental.Service;
using DocumentFormat.OpenXml.Office2010.Excel;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using CarRental.Service.library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(IHoaDonKyGuiService))]
    public class HoaDonKyGuiService : Base.Service,IHoaDonKyGuiService
    {
        private readonly IConfiguration _configuration;
        private readonly IHoaDonKyGuiRepository _hdkgRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HoaDonKyGuiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdkgRepository = serviceProvider.GetRequiredService<IHoaDonKyGuiRepository>();
            _configuration = serviceProvider.GetRequiredService<IConfiguration>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HoaDonKyGuiModel model, CancellationToken cancellationToken = default)
        {
            if (_hdkgRepository.Get(_ => _.IDHoaDonKyGui.Equals(model.IDHoaDonKyGui) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDHoaDonKyGui);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            int count = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da Xoa") || _.TrangThai == null).ToList().Count();
            count += 1;
            string ma = "HOADONKG00" + count.ToString();
            string sohoadon = "0000" + count.ToString();
            model.IDHoaDonKyGui = ma;
            var entity = _mapper.Map<HoaDonKyGuiEntity>(model);
            entity.IDHoaDonKyGui = model.IDHoaDonKyGui;
            _hdkgRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDHoaDonKyGui);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHoaDonKyGui.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdkgRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HoaDonKyGuiEntity> GetAllAsync()
        {
            var entities = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HoaDonKyGuiEntity>)entities;
        }

        public HoaDonKyGuiEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdkgRepository.GetSingle(_ => _.IDHoaDonKyGui.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HoaDonKyGuiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHoaDonKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDHoaDonKyGui != Id)
            {
                var isDuplicate = _hdkgRepository.GetTracking(x => x.IDHoaDonKyGui.Equals(model.IDHoaDonKyGui) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hdkgRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public HoaDonKyGuiEntity GetByStrAsync(string str)
        {
            throw new NotImplementedException();
        }
        public UserEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }

        public string PrintByIDAsync(string id)
        {
            throw new NotImplementedException();
        }
        public HoaDonKyGuiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonKyGuiEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonKyGuiEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonKyGuiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public string CreatePaymentUrl(string idhoadon, HttpContext context)
        {
            var entity = _hdkgRepository.GetSingle(x => x.IDHoaDonKyGui.Equals(idhoadon) && !x.TrangThai.Equals("Da xoa"));
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, idhoadon);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_configuration["TimeZoneId"]);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = _configuration["PaymentCallBack:ReturnUrl"];

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)entity.TongThanhToan * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"{entity.IDHoaDonKyGui} {entity.IDHopDongKyGui} {entity.TongThanhToan}");
            pay.AddRequestData("vnp_OrderType", "Thanh toan");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }

        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VnPayLibrary();
            var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);

            return response;
        }

        public async Task SavePaymentData(PaymentResponseModel collections)
        {
            var pay = new VnPayLibrary();
            var orderInfo = collections.OrderDescription.Split(' ');
            if (collections.VnPayResponseCode == "00")
            {
                if (orderInfo.Length >= 3)
                {
                    var hoadonkygui = orderInfo[0]; // ID hóa đơn ký gửi
                    var hopdongkygui = orderInfo[1]; // ID hợp đồng ký gửi
                    var tongTienStr = orderInfo[2]; // Tổng số tiền

                    // Chuyển đổi tongTien từ chuỗi sang số
                    if (double.TryParse(tongTienStr, out double tongTien))
                    {
                        var hd = _hdkgRepository.GetSingle(x => x.IDHoaDonKyGui.Equals(hoadonkygui) && !x.TrangThai.Equals("Da xoa"));
                        if (hd != null)
                        {
                            hd.TongThanhToan = tongTien;
                            hd.TrangThaiThanhToan = "Da thanh toan";
                            hd.UpdateAt = DateTime.Now;
                            _hdkgRepository.Update(hd);
                            await UnitOfWork.SaveChangeAsync();
                        }
                        else
                        {
                            throw new Exception(message: "Không tìm thấy hóa đơn cần cập nhật!");
                        }
                    }
                    else
                    {
                        throw new Exception(message: "Không thể phân tích cú pháp tổng số tiền!");
                    }
                }
                else
                {
                    throw new Exception(message: "Thông tin đơn hàng không hợp lệ!");
                }
            }
            else
            {
                throw new Exception(message: "Lưu dữ liệu không thanh toán không thành công!");
            }
        }

        public async Task CapNhatTrangThaiThanhToan(string Id)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }

            // Kiểm tra nếu hợp đồng đã được thanh lý
            if (entity.TrangThai.Equals("Da thanh toan"))
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Hóa đơn đã được thanh toán", statusCode: StatusCodes.Status400BadRequest);
            }       
            entity.TrangThai = "Da thanh ly";
            _hdkgRepository.Update(entity);

            await UnitOfWork.SaveChangeAsync();
        }
    }
}
