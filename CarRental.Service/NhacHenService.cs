using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.NhacHen;
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
    [ScopedDependency(ServiceType = typeof(INhacHenService))]
    public class NhacHenService : Base.Service, INhacHenService
    {

        private readonly INhacHenRepository _nhRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhacHenService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _nhRepository = serviceProvider.GetRequiredService<INhacHenRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NhacHenModel model, CancellationToken cancellationToken = default)
        {
            if (_nhRepository.Get(_ => _.IDNhacHen.Equals(model.IDNhacHen) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDNhacHen);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhacHen.NHACHEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhacHenEntity>(model);
            entity.IDNhacHen = model.IDNhacHen;
            _nhRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDNhacHen);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _nhRepository.GetTracking(x => x.IDNhacHen.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhacHen.NHACHEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _nhRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NhacHenEntity> GetAllAsync()
        {
            var entities = _nhRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<NhacHenEntity>)entities;
        }
        public NhacHenEntity GetByKeyIdAsync(string id)
        {
            var entity = _nhRepository.GetSingle(_ => _.IDNhacHen.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, NhacHenModel model, CancellationToken cancellationToken = default)
        {
            var entity = _nhRepository.GetTracking(x => x.IDNhacHen.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhacHen.NHACHEN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDNhacHen != Id)
            {
                var isDuplicate = _nhRepository.GetTracking(x => x.IDNhacHen.Equals(model.IDNhacHen) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhacHen.NHACHEN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _nhRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _nhRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public NhacHenEntity GetByStrAsync(string str)
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
        public NhacHenEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<NhacHenEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<NhacHenEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
