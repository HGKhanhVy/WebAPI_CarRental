using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KhachHang;
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
    [ScopedDependency(ServiceType = typeof(IKhachHangService))]
    public class KhachHangService : Base.Service, IKhachHangService
    {

        private readonly IKhachHangRepository _khRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhachHangService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _khRepository = serviceProvider.GetRequiredService<IKhachHangRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(KhachHangModel model, CancellationToken cancellationToken = default)
        {
            if (_khRepository.Get(_ => _.IDKhachHang.Equals(model.IDKhachHang) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDKhachHang);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACHHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhachHangEntity>(model);
            entity.IDKhachHang = model.IDKhachHang;
            _khRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDKhachHang);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _khRepository.GetTracking(x => x.IDKhachHang.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _khRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<KhachHangEntity> GetAllAsync()
        {
            var entities = _khRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<KhachHangEntity>)entities;
        }

        public KhachHangEntity GetByKeyIdAsync(string id)
        {
            var entity = _khRepository.GetSingle(_ => _.IDKhachHang.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, KhachHangModel model, CancellationToken cancellationToken = default)
        {
            var entity = _khRepository.GetTracking(x => x.IDKhachHang.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDKhachHang != Id)
            {
                var isDuplicate = _khRepository.GetTracking(x => x.IDKhachHang.Equals(model.IDKhachHang) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhachHang.KHACHHANG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _khRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _khRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public KhachHangEntity KhachHangLogin(string Email, string PassWord)
        {
            var entity = _khRepository.GetSingle(_ => _.Email.Equals(Email) && _.PassWord.Equals(PassWord) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }
        public KhachHangEntity GetByStrAsync(string str)
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
        public KhachHangEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public KhachHangEntity NhanVienLogin(string email, string mk)
        {
            throw new NotImplementedException();
        }

        public ICollection<KhachHangEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<KhachHangEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<KhachHangEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
