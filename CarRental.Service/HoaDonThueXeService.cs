using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HoaDonKyGui;
using CarRental.Core.Models.HoaDonThueXe;
using CarRental.Core.Models.Login;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(IHoaDonThueXeService))]
    public class HoaDonThueXeService : Base.Service, IHoaDonThueXeService
    {

        private readonly IHoaDonThueXeRepository _hdtxRepository;
        private readonly IHopDongThueXeRepository _hopdongtxRepository;
        private readonly IXeRepository _xeRepository;
        private readonly IHopDongKyGuiRepository _hopdongkgRepository;
        private readonly IHoaDonKyGuiRepository _hdkgRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HoaDonThueXeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdtxRepository = serviceProvider.GetRequiredService<IHoaDonThueXeRepository>();
            _hopdongtxRepository = serviceProvider.GetRequiredService<IHopDongThueXeRepository>();
            _xeRepository = serviceProvider.GetRequiredService<IXeRepository>();
            _hopdongkgRepository = serviceProvider.GetRequiredService<IHopDongKyGuiRepository>();
            _hdkgRepository = serviceProvider.GetRequiredService<IHoaDonKyGuiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        //public Task<string> CreateAsync(HoaDonThueXeModel model, CancellationToken cancellationToken = default)
        //{
        //    if (_hdtxRepository.Get(_ => _.IDHoaDonThueXe.Equals(model.IDHoaDonThueXe) && !_.TrangThai.Equals("Da xoa")).Any())
        //    {
        //        _logger.Information(ErrorCode.NotUnique, model.IDHoaDonThueXe);
        //        throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonThueXe.HOADONTHUEXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
        //    }
        //    var entity = _mapper.Map<HoaDonThueXeEntity>(model);
        //    entity.IDHoaDonThueXe = model.IDHoaDonThueXe;
        //    _hdtxRepository.Add(entity);
        //    UnitOfWork.SaveChange();
        //    return Task.FromResult(entity.IDHoaDonThueXe);
        //}


        public Task<string> CreateAsync(HoaDonThueXeModel model, CancellationToken cancellationToken = default)
        {
            if (_hdtxRepository.Get(_ => _.IDHoaDonThueXe.Equals(model.IDHoaDonThueXe) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDHoaDonThueXe);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonThueXe.HOADONTHUEXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var hopdongthuexe = _hopdongtxRepository.Get(_ => _.IDHopDongThueXe.Equals(model.IDHopDongThueXe)
        && !_.TrangThai.Equals("Da thanh ly")).FirstOrDefault();

            if (hopdongthuexe == null)
            {
                _logger.Information(ErrorCode.NotFound, model.IDHopDongThueXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Hợp đồng thuê xe không tồn tại hoặc đã thanh lý.", statusCode: StatusCodes.Status404NotFound);
            }

            var xe = _xeRepository.Get(_ => _.IDXe.Equals(hopdongthuexe.IDXe)
                && !_.TrangThai.Equals("Da xoa")).FirstOrDefault();

            if (xe == null)
            {
                _logger.Information(ErrorCode.NotFound, hopdongthuexe.IDXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Xe không tồn tại hoặc đã bị xóa.", statusCode: StatusCodes.Status404NotFound);
            }

            var hopdongkygui = _hopdongkgRepository.Get(_ => _.IDXe.Equals(xe.IDXe)
                && !_.TrangThai.Equals("Da xoa")).FirstOrDefault();

            if (hopdongkygui == null)
            {
                _logger.Information(ErrorCode.NotFound, xe.IDXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Hợp đồng ký gửi không tồn tại hoặc đã bị xóa.", statusCode: StatusCodes.Status404NotFound);
            }

            HoaDonKyGuiEntity hoadonkygui = new HoaDonKyGuiEntity
            {
                IDHoaDonKyGui = "",
                IDHopDongKyGui = hopdongkygui.IDHopDongKyGui,
                SoHoaDon = "",
                IDKhachHang = hopdongkygui.IDKhachHang,
                IDNhanVien = hopdongkygui.IDNhanVien,
                SoHoaDonThue = model.SoHoaDon,
                NgayLap = DateTime.Now,
                TongThanhToan = model.TongThanhToan * hopdongkygui.PhanTramHoaHong / 100,
                TrangThaiThanhToan = "Chua thanh toan",
                HinhThucThanhToan = hopdongkygui.PhuongThucThanhToan,
                UpdateBy = "",
                UpdateAt = DateTime.Now,
            };
            var entity = _mapper.Map<HoaDonThueXeEntity>(model);
            entity.IDHoaDonThueXe = model.IDHoaDonThueXe;
            _hdtxRepository.Add(entity);
            _hdkgRepository.Add(hoadonkygui);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDHoaDonThueXe);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdtxRepository.GetTracking(x => x.IDHoaDonThueXe.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonThueXe.HOADONTHUEXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdtxRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HoaDonThueXeEntity> GetAllAsync()
        {
            var entities = _hdtxRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HoaDonThueXeEntity>)entities;
        }

        public HoaDonThueXeEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdtxRepository.GetSingle(_ => _.IDHoaDonThueXe.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HoaDonThueXeModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdtxRepository.GetTracking(x => x.IDHoaDonThueXe.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonThueXe.HOADONTHUEXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDHoaDonThueXe != Id)
            {
                var isDuplicate = _hdtxRepository.GetTracking(x => x.IDHoaDonThueXe.Equals(model.IDHoaDonThueXe) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonThueXe.HOADONTHUEXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hdtxRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _hdtxRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public HoaDonThueXeEntity GetByStrAsync(string str)
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
        public HoaDonThueXeEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonThueXeEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonThueXeEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonThueXeEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
