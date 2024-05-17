using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.ChucVu;
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
    [ScopedDependency(ServiceType = typeof(IChucVuService))]
    public class ChucVuService : Base.Service, IChucVuService
    {

        private readonly IChucVuRepository _cvRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ChucVuService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _cvRepository = serviceProvider.GetRequiredService<IChucVuRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(ChucVuModel model, CancellationToken cancellationToken = default)
        {
            if (_cvRepository.Get(_ => _.IDChucVu.Equals(model.IDChucVu) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDChucVu);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChucVu.CHUCVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ChucVuEntity>(model);
            entity.IDChucVu = model.IDChucVu;
            _cvRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDChucVu);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _cvRepository.GetTracking(x => x.IDChucVu.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChucVu.CHUCVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _cvRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ChucVuEntity> GetAllAsync()
        {
            var entities = _cvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<ChucVuEntity>)entities;
        }

        public ChucVuEntity GetByKeyIdAsync(string id)
        {
            var entity = _cvRepository.GetSingle(_ => _.IDChucVu.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, ChucVuModel model, CancellationToken cancellationToken = default)
        {
            var entity = _cvRepository.GetTracking(x => x.IDChucVu.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsChucVu.CHUCVU_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDChucVu != Id)
            {
                var isDuplicate = _cvRepository.GetTracking(x => x.IDChucVu.Equals(model.IDChucVu) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsChucVu.CHUCVU_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _cvRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _cvRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public ChucVuEntity GetByStrAsync(string str)
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
        public ChucVuEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<ChucVuEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<ChucVuEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<ChucVuEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
