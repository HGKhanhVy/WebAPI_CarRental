using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.Permission;
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
    [ScopedDependency(ServiceType = typeof(IPermissionService))]
    public class PermissionService : Base.Service, IPermissionService
    {

        private readonly IPermissionRepository _perRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PermissionService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _perRepository = serviceProvider.GetRequiredService<IPermissionRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(PermissionModel model, CancellationToken cancellationToken = default)
        {
            if (_perRepository.Get(_ => _.IDPermission.Equals(model.IDPermission) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDPermission);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPermission.PERMISSION_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PermissionEntity>(model);
            entity.IDPermission = model.IDPermission;
            _perRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDPermission);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _perRepository.GetTracking(x => x.IDPermission.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPermission.PERMISSION_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _perRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<PermissionEntity> GetAllAsync()
        {
            var entities = _perRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<PermissionEntity>)entities;
        }
        public PermissionEntity GetByKeyIdAsync(string id)
        {
            var entity = _perRepository.GetSingle(_ => _.IDPermission.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, PermissionModel model, CancellationToken cancellationToken = default)
        {
            var entity = _perRepository.GetTracking(x => x.IDPermission.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPermission.PERMISSION_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDPermission != Id)
            {
                var isDuplicate = _perRepository.GetTracking(x => x.IDPermission.Equals(model.IDPermission) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPermission.PERMISSION_EXISTED, statusCode: StatusCodes.Status400BadRequest);
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
        public PermissionEntity GetByStrAsync(string str)
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
        public PermissionEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<PermissionEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<PermissionEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
