﻿using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HoaDonKyGui;
using CarRental.Core.Models.HopDongThueXe;
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
    [ScopedDependency(ServiceType = typeof(IHopDongThueXeService))]
    public class HopDongThueXeService : Base.Service, IHopDongThueXeService
    {

        private readonly IHopDongThueXeRepository _hdtxRepository;
        private readonly IXeRepository _xeRepository;
        private readonly IHopDongKyGuiRepository _hopdongkgRepository;
        private readonly IHoaDonKyGuiRepository _hdkgRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HopDongThueXeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdtxRepository = serviceProvider.GetRequiredService<IHopDongThueXeRepository>();
            _xeRepository = serviceProvider.GetRequiredService<IXeRepository>();
            _hopdongkgRepository = serviceProvider.GetRequiredService<IHopDongKyGuiRepository>();
            _hdkgRepository = serviceProvider.GetRequiredService<IHoaDonKyGuiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        //public Task<string> CreateAsync(HopDongThueXeModel model, CancellationToken cancellationToken = default)
        //{
        //    if (_hdtxRepository.Get(_ => _.IDHopDongThueXe.Equals(model.IDHopDongThueXe) && !_.TrangThai.Equals("Da xoa")).Any())
        //    {
        //        _logger.Information(ErrorCode.NotUnique, model.IDHopDongThueXe);
        //        throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongThueXe.HOPDONGTHUEXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
        //    }
        //    var entity = _mapper.Map<HopDongThueXeEntity>(model);
        //    entity.IDHopDongThueXe = model.IDHopDongThueXe;
        //    _hdtxRepository.Add(entity);
        //    UnitOfWork.SaveChange();
        //    return Task.FromResult(entity.IDHopDongThueXe);
        //}

        public Task<string> CreateAsync(HopDongThueXeModel model, CancellationToken cancellationToken = default)
        {
            if (_hdtxRepository.Get(_ => _.IDHopDongThueXe.Equals(model.IDHopDongThueXe) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDHopDongThueXe);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongThueXe.HOPDONGTHUEXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
           
            var xe = _xeRepository.Get(_ => _.IDXe.Equals(model.IDXe)
                && !_.TrangThai.Equals("Da xoa")).FirstOrDefault();

            if (xe == null)
            {
                _logger.Information(ErrorCode.NotFound, xe.IDXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Xe không tồn tại hoặc đã bị xóa.", statusCode: StatusCodes.Status404NotFound);
            }

            var hopdongkygui = _hopdongkgRepository.Get(_ => _.IDXe.Equals(xe.IDXe)
                && !_.TrangThai.Equals("Da xoa")).FirstOrDefault();

            if (hopdongkygui == null)
            {
                _logger.Information(ErrorCode.NotFound, xe.IDXe);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: "Hợp đồng ký gửi không tồn tại hoặc đã bị xóa.", statusCode: StatusCodes.Status404NotFound);
            }
            int count = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da Xoa") || _.TrangThai == null).ToList().Count();
            count += 1;
            string maKH = "HOADONKG00" + count.ToString();
            string So = "0000" + count.ToString();
            HoaDonKyGuiEntity hoadonkygui = new HoaDonKyGuiEntity
            {
                IDHoaDonKyGui = maKH,
                IDHopDongKyGui = hopdongkygui.IDHopDongKyGui,
                SoHoaDon = So,
                IDKhachHang = hopdongkygui.IDKhachHang,
                IDNhanVien = hopdongkygui.IDNhanVien,
                SoHoaDonThue = model.SoHopDong,
                NgayLap = DateTime.Now,
                TongThanhToan = model.GiaThue * hopdongkygui.PhanTramHoaHong / 100,
                TrangThaiThanhToan = "Chua thanh toan",
                HinhThucThanhToan = hopdongkygui.PhuongThucThanhToan,
                UpdateBy = "",
                UpdateAt = DateTime.Now,
            };
            var entity = _mapper.Map<HopDongThueXeEntity>(model);
            entity.IDHopDongThueXe = model.IDHopDongThueXe;
            _hdtxRepository.Add(entity);
            _hdkgRepository.Add(hoadonkygui);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDHopDongThueXe);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdtxRepository.GetTracking(x => x.IDHopDongThueXe.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongThueXe.HOPDONGTHUEXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdtxRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HopDongThueXeEntity> GetAllAsync()
        {
            var entities = _hdtxRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HopDongThueXeEntity>)entities;
        }

        public HopDongThueXeEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdtxRepository.GetSingle(_ => _.IDHopDongThueXe.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HopDongThueXeModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdtxRepository.GetTracking(x => x.IDHopDongThueXe.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongThueXe.HOPDONGTHUEXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDHopDongThueXe != Id)
            {
                var isDuplicate = _hdtxRepository.GetTracking(x => x.IDHopDongThueXe.Equals(model.IDHopDongThueXe) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongThueXe.HOPDONGTHUEXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
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
        public HopDongThueXeEntity GetByStrAsync(string str)
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
        public HopDongThueXeEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongThueXeEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongThueXeEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongThueXeEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
