using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.UserPermission;
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
    [ScopedDependency(ServiceType = typeof(IUserPermissionService))]
    public class UserPermissionService : Base.Service, IUserPermissionService
    {

        private readonly IUserPermissionRepository _uperpRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public UserPermissionService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _uperpRepository = serviceProvider.GetRequiredService<IUserPermissionRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _uperpRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(UserPermissionModel model, CancellationToken cancellationToken = default)
        {
            if (_uperpRepository.Get(_ => _.IDUser.Equals(model.IDUser) && _.IDPermission.Equals(model.IDPermission) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDUser + " - " + model.IDPermission);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsUserPermission.USERPERMISSION_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<UserPermissionEntity>(model);
            entity.IDUser = model.IDUser;
            entity.IDPermission = model.IDPermission;
            _uperpRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDUser + " - " + entity.IDPermission);
        }

        public Task DeleteAsync(string idUser, string idPer, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _uperpRepository.GetTracking(x => x.IDUser.Equals(idUser) && x.IDPermission.Equals(idPer) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, idUser + " - " + idPer);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsUserPermission.USERPERMISSION_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _uperpRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<UserPermissionEntity> GetAllAsync()
        {
            var entities = _uperpRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<UserPermissionEntity>)entities;
        }

        public UserPermissionEntity GetByKeyIdAsync(string idUser, string idPer)
        {
            var entity = _uperpRepository.GetSingle(_ => _.IDUser.Equals(idUser) && _.IDPermission.Equals(idPer) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string idUser, string idPer, UserPermissionModel model, CancellationToken cancellationToken = default)
        {
            var entity = _uperpRepository.GetTracking(x => x.IDUser.Equals(idUser) && x.IDPermission.Equals(idPer) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, idUser + " - " + idPer);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsUserPermission.USERPERMISSION_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDUser != idUser && model.IDPermission != idPer)
            {
                var isDuplicate = _uperpRepository.GetTracking(x => x.IDUser.Equals(model.IDUser) && x.IDPermission.Equals(model.IDPermission) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, idUser);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsUserPermission.USERPERMISSION_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _uperpRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<UserPermissionEntity> GetAllByKey1Async(string idUser)
        {
            var entities = _uperpRepository.Get(_ => _.IDUser.Equals(idUser)).ToList();
            return (ICollection<UserPermissionEntity>)entities;
        }

        public ICollection<UserPermissionEntity> GetAllByKey2Async(string idPer)
        {
            var entities = _uperpRepository.Get(_ => _.IDPermission.Equals(idPer)).ToList();
            return (ICollection<UserPermissionEntity>)entities;
        }

       
    }
}
