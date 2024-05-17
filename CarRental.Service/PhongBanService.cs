using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.PhongBan;
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
    [ScopedDependency(ServiceType = typeof(IPhongBanService))]
    public class PhongBanService : Base.Service, IPhongBanService
    {

        private readonly IPhongBanRepository _pbRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public PhongBanService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _pbRepository = serviceProvider.GetRequiredService<IPhongBanRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(PhongBanModel model, CancellationToken cancellationToken = default)
        {
            if (_pbRepository.Get(_ => _.IDPhongBan.Equals(model.IDPhongBan) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDPhongBan);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhongBan.PHONGBAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<PhongBanEntity>(model);
            entity.IDPhongBan = model.IDPhongBan;
            _pbRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDPhongBan);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _pbRepository.GetTracking(x => x.IDPhongBan.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhongBan.PHONGBAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _pbRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<PhongBanEntity> GetAllAsync()
        {
            var entities = _pbRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<PhongBanEntity>)entities;
        }
        public PhongBanEntity GetByKeyIdAsync(string id)
        {
            var entity = _pbRepository.GetSingle(_ => _.IDPhongBan.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, PhongBanModel model, CancellationToken cancellationToken = default)
        {
            var entity = _pbRepository.GetTracking(x => x.IDPhongBan.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsPhongBan.PHONGBAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDPhongBan != Id)
            {
                var isDuplicate = _pbRepository.GetTracking(x => x.IDPhongBan.Equals(model.IDPhongBan) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsPhongBan.PHONGBAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _pbRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _pbRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public PhongBanEntity GetByStrAsync(string str)
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
        public PhongBanEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<PhongBanEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<PhongBanEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
