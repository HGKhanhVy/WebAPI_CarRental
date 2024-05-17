using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.PermissionDetail;
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
    [ScopedDependency(ServiceType = typeof(IPermissionDetailService))]
    public class PermissionDetailService : Base.Service, IPermissionDetailService
    {

        private readonly IPermissionDetailRepository _perRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PermissionDetailService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _perRepository = serviceProvider.GetRequiredService<IPermissionDetailRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(PermissionDetailModel model, CancellationToken cancellationToken = default)
        {
            if (_perRepository.Get(_ => _.IDPermissionDetail.Equals(model.IDPermissionDetail) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDPermissionDetail);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPermissionDetail.PERMISSIONDETAIL_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PermissionDetailEntity>(model);
            entity.IDPermissionDetail = model.IDPermissionDetail;
            _perRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDPermissionDetail);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _perRepository.GetTracking(x => x.IDPermissionDetail.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPermissionDetail.PERMISSIONDETAIL_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _perRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<PermissionDetailEntity> GetAllAsync()
        {
            var entities = _perRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<PermissionDetailEntity>)entities;
        }
        public ICollection<PermissionDetailEntity> GetAllByAnotherKeyAsync(string idPermission)
        {
            var entity = _perRepository.Get(_ => _.IDPermission.Equals(idPermission) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public PermissionDetailEntity GetByKeyIdAsync(string id)
        {
            var entity = _perRepository.GetSingle(_ => _.IDPermissionDetail.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, PermissionDetailModel model, CancellationToken cancellationToken = default)
        {
            var entity = _perRepository.GetTracking(x => x.IDPermissionDetail.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPermissionDetail.PERMISSIONDETAIL_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDPermissionDetail != Id)
            {
                var isDuplicate = _perRepository.GetTracking(x => x.IDPermissionDetail.Equals(model.IDPermissionDetail) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPermissionDetail.PERMISSIONDETAIL_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _perRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _perRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public PermissionDetailEntity GetByStrAsync(string str)
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
        public PermissionDetailEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<PermissionDetailEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }
    }
}
