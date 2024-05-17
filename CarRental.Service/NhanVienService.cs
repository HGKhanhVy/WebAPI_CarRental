using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.NhanVien;
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
    [ScopedDependency(ServiceType = typeof(INhanVienService))]
    public class NhanVienService : Base.Service, INhanVienService
    {

        private readonly INhanVienRepository _nvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhanVienService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nvRepository = serviceProvider.GetRequiredService<INhanVienRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NhanVienModel model, CancellationToken cancellationToken = default)
        {
            if (_nvRepository.Get(_ => _.IDNhanVien.Equals(model.IDNhanVien) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDNhanVien);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVien.NHANVIEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhanVienEntity>(model);
            entity.IDNhanVien = model.IDNhanVien;
            _nvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDNhanVien);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nvRepository.GetTracking(x => x.IDNhanVien.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVien.NHANVIEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NhanVienEntity> GetAllAsync()
        {
            var entities = _nvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<NhanVienEntity>)entities;
        }

        public NhanVienEntity GetByKeyIdAsync(string id)
        {
            var entity = _nvRepository.GetSingle(_ => _.IDNhanVien.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, NhanVienModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nvRepository.GetTracking(x => x.IDNhanVien.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVien.NHANVIEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDNhanVien != Id)
            {
                var isDuplicate = _nvRepository.GetTracking(x => x.IDNhanVien.Equals(model.IDNhanVien) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVien.NHANVIEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _nvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public NhanVienEntity NhanVienLogin(string Email, string PassWord)
        {
            var entity = _nvRepository.GetSingle(_ => _.Email.Equals(Email) && _.PassWord.Equals(PassWord) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }
        public NhanVienEntity GetByStrAsync(string str)
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
        public NhanVienEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public NhanVienEntity KhachHangLogin(string email, string mk)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<NhanVienEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<NhanVienEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
