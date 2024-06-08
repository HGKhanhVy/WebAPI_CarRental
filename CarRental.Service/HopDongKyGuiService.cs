using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HopDongKyGui;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.ThanhLyHopDong;
using DocumentFormat.OpenXml.Packaging;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarRental.Core.Constants.WebApiEndpoint;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(IHopDongKyGuiService))]
    public class HopDongKyGuiService : Base.Service, IHopDongKyGuiService
    {

        private readonly IHopDongKyGuiRepository _hdkgRepository;
        private readonly IXeRepository _xeRepository;
        private readonly IKhachHangRepository _khachHangRepository;
        private readonly IHopDongThueXeRepository _hdtxReposRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HopDongKyGuiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdkgRepository = serviceProvider.GetRequiredService<IHopDongKyGuiRepository>();
            _hdtxReposRepository = serviceProvider.GetRequiredService<IHopDongThueXeRepository>();
            _xeRepository = serviceProvider.GetRequiredService<IXeRepository>();
            _khachHangRepository = serviceProvider.GetRequiredService<IKhachHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HopDongKyGuiModel model, CancellationToken cancellationToken = default)
        {
            if (_hdkgRepository.Get(_ => _.IDHopDongKyGui.Equals(model.IDHopDongKyGui) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDHopDongKyGui);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HopDongKyGuiEntity>(model);
            entity.IDHopDongKyGui = model.IDHopDongKyGui;
            _hdkgRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDHopDongKyGui);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdkgRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HopDongKyGuiEntity> GetAllAsync()
        {
            var entities = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HopDongKyGuiEntity>)entities;
        }

        public HopDongKyGuiEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdkgRepository.GetSingle(_ => _.IDHopDongKyGui.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HopDongKyGuiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDHopDongKyGui != Id)
            {
                var isDuplicate = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(model.IDHopDongKyGui) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
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
        public HopDongKyGuiEntity GetByStrAsync(string str)
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
        public HopDongKyGuiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongKyGuiEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongKyGuiEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongKyGuiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public FileContentResult PrintHopDong(string id)
        {
            var hopdong = _hdkgRepository.GetSingle(_ => _.IDHopDongKyGui.Equals(id) && !_.TrangThai.Equals("Da xoa"));

            var khachhang = _khachHangRepository.Get(_ => _.IDKhachHang.Equals(hopdong.IDKhachHang)
            && !_.TrangThai.Equals("Da xoa")).FirstOrDefault();

            var xe = _xeRepository.Get(_ => _.IDXe.Equals(hopdong.IDXe)
            && !_.TrangThai.Equals("Da xoa")).FirstOrDefault();

            var homNay = DateTime.Now;
            //string templatePath = "CarRental\\Template\\mau-hop-dong-gui-xe.docx";
            //string filledTemplatePath = "CarRental\\Template\\TempFilled.docx";
            //System.IO.File.Copy(templatePath, filledTemplatePath, true);
            string currentDirectory = Directory.GetCurrentDirectory();
            string templatePath = Path.Combine(currentDirectory, "Template", "mau-hop-dong-gui-xe.docx");
            string filledTemplatePath = Path.Combine(currentDirectory, "Template", "TempFilled.docx");

            string SoHopDong = "SoHopDong";
            string NgayHienTai = "NgayHienTai";
            string HoTen = "HoTen";
            string DiaChi = "DiaChi";
            string CanCuocCongDan = "CanCuocCongDan";
            string SoDienThoai = "SoDienThoai";
            string DonGia = "DonGia";
            string SoCho = "SoCho";
            string LoaiXe = "LoaiXe";
            string BienKiemSoat = "BienKiemSoat";
            string NgayBatDau = "NgayBatDau";
            string NgayKetThuc = "NgayKetThuc";
            using (var document = WordprocessingDocument.Open(filledTemplatePath, true))
            {
                var mainPart = document.MainDocumentPart;
                var body = mainPart.Document.Body;
                var paragraphs = body.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();
                foreach (var paragraph in paragraphs)
                {
                    foreach (var run in paragraph.Elements<DocumentFormat.OpenXml.Wordprocessing.Run>())
                    {
                        foreach (var text in run.Elements<DocumentFormat.OpenXml.Wordprocessing.Text>())
                        {
                            if (text.Text.Contains(SoHopDong))
                                text.Text = text.Text.Replace(SoHopDong, hopdong.SoHopDong);
                            else
                            if (text.Text.Contains(NgayHienTai))
                            {
                                text.Text = $"ngày {homNay.Day} tháng {homNay.Month} năm {homNay.Year}";

                            }
                            else
                            if (text.Text.Contains(HoTen))
                                text.Text = text.Text.Replace(HoTen, khachhang.HoTen);

                            else
                            if (text.Text.Contains(DiaChi))
                                text.Text = text.Text.Replace(DiaChi, khachhang.DiaChiHienTai);
                            else
                            if (text.Text.Contains(CanCuocCongDan))
                                text.Text = text.Text.Replace(CanCuocCongDan, khachhang.CCCD);
                            else
                            if (text.Text.Contains(SoDienThoai))
                                text.Text = text.Text.Replace(SoDienThoai, khachhang.SoDienThoai);
                            else
                             if (text.Text.Contains(SoCho))
                                text.Text = text.Text.Replace(SoCho, xe.SoChoNgoi.ToString());
                            else
                            if (text.Text.Contains(LoaiXe))
                                text.Text = text.Text.Replace(LoaiXe, xe.TenXe);
                            else
                            if (text.Text.Contains(BienKiemSoat))
                                text.Text = text.Text.Replace(BienKiemSoat, xe.BienSoXe);
                            else
                            if (text.Text.Contains(DonGia))
                                text.Text = text.Text.Replace(DonGia, xe.GiaThue.ToString());
                            else
                            if (text.Text.Contains(NgayBatDau))
                                text.Text = text.Text.Replace(NgayBatDau, hopdong.NgayHieuLuc.ToString("dd/MM/yyyy"));
                            else
                            if (text.Text.Contains(NgayKetThuc))
                                text.Text = text.Text.Replace(NgayKetThuc, hopdong.NgayHetHan.ToString("dd/MM/yyyy"));
                        }
                    }
                }

                mainPart.Document.Save();
            }
            var fileBytes = System.IO.File.ReadAllBytes(filledTemplatePath);
            return new FileContentResult(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {
                FileDownloadName = "BaoCao.docx"
            };
        }

        public int getIDHopDongKyGui()
        {
            return _hdkgRepository.Get(_ => _.TrangThai == null && !_.TrangThai.Equals("Da xoa")).ToList().Count();
        }

        public async Task ThanhLyHopDong(string Id)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }

            // Kiểm tra nếu hợp đồng đã được thanh lý
            if (entity.TrangThai.Equals("Da thanh ly"))
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Hợp đồng ký gửi đã được thanh lý trước đó.", statusCode: StatusCodes.Status400BadRequest);
            }

            var xe = _xeRepository.GetSingle(_ => _.IDXe.Equals(entity.IDXe));
            if (xe == null)
            {
                _logger.Information(ErrorCode.NotFound, entity.IDXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Xe không tồn tại.", statusCode: StatusCodes.Status404NotFound);
            }

            var hopdongthue = _hdtxReposRepository.Get(_ => _.IDXe.Equals(xe.IDXe)).ToList();
            if (hopdongthue.Any(hd => hd.TrangThai != "Da thanh ly"))
            {
                _logger.Information(ErrorCode.NotFound, $"Không thể thanh lý hợp đồng ký gửi vì có hợp đồng thuê chưa được thanh lý.");
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Không thể thanh lý hợp đồng ký gửi vì có hợp đồng thuê chưa được thanh lý.", statusCode: StatusCodes.Status400BadRequest);
            }        
            entity.TrangThai = "Da thanh ly";
            xe.TrangThai = "Da thanh ly";
            _hdkgRepository.Update(entity);
            _xeRepository.Update(xe);

            await UnitOfWork.SaveChangeAsync();
        }

        public async Task DuyetHopDong(string Id)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }

            // Kiểm tra nếu hợp đồng đã được thanh lý
            if (entity.TrangThai != null && entity.TrangThai.Equals("Da duyet"))
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Hợp đồng ký gửi đã được duyệt trước đó.", statusCode: StatusCodes.Status400BadRequest);
            }

            var xe = _xeRepository.GetSingle(_ => _.IDXe.Equals(entity.IDXe));
            if (xe == null)
            {
                _logger.Information(ErrorCode.NotFound, entity.IDXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Xe không tồn tại.", statusCode: StatusCodes.Status404NotFound);
            }

            entity.TrangThai = "Da duyet";
            xe.TrangThai = "Da duyet";
            _hdkgRepository.Update(entity);
            _xeRepository.Update(xe);

            await UnitOfWork.SaveChangeAsync();
        }
    }
}
