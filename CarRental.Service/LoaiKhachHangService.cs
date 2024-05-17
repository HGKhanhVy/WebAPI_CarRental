using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.LoaiKhachHang;
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
    [ScopedDependency(ServiceType = typeof(ILoaiKhachHangService))]
    public class LoaiKhachHangService : Base.Service, ILoaiKhachHangService
    {

        private readonly ILoaiKhachHangRepository _loaikhRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LoaiKhachHangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _loaikhRepository = serviceProvider.GetRequiredService<ILoaiKhachHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LoaiKhachHangModel model, CancellationToken cancellationToken = default)
        {
            if (_loaikhRepository.Get(_ => _.IDLoaiKH.Equals(model.IDLoaiKH) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDLoaiKH);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiKhachHang.LOAIKHACHHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LoaiKhachHangEntity>(model);
            entity.IDLoaiKH = model.IDLoaiKH;
            _loaikhRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDLoaiKH);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _loaikhRepository.GetTracking(x => x.IDLoaiKH.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiKhachHang.LOAIKHACHHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _loaikhRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LoaiKhachHangEntity> GetAllAsync()
        {
            var entities = _loaikhRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<LoaiKhachHangEntity>)entities;
        }
        public LoaiKhachHangEntity GetByKeyIdAsync(string id)
        {
            var entity = _loaikhRepository.GetSingle(_ => _.IDLoaiKH.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, LoaiKhachHangModel model, CancellationToken cancellationToken = default)
        {
            var entity = _loaikhRepository.GetTracking(x => x.IDLoaiKH.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiKhachHang.LOAIKHACHHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDLoaiKH != Id)
            {
                var isDuplicate = _loaikhRepository.GetTracking(x => x.IDLoaiKH.Equals(model.IDLoaiKH) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiKhachHang.LOAIKHACHHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _loaikhRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _loaikhRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public LoaiKhachHangEntity GetByStrAsync(string str)
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
        public LoaiKhachHangEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoaiKhachHangEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<LoaiKhachHangEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
