using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service.Base;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.SoDienThoai;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(ISoDienThoaiService))]
    public class SoDienThoaiService : Base.Service, ISoDienThoaiService
    {

        private readonly ISoDienThoaiRepository _sdtRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public SoDienThoaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _sdtRepository = serviceProvider.GetRequiredService<ISoDienThoaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(SoDienThoaiModel model, CancellationToken cancellationToken = default)
        {
            if (_sdtRepository.Get(_ => _.DauSo.Equals(model.DauSo) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.DauSo);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSoDienThoai.DAUSO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<SoDienThoaiEntity>(model);
            entity.DauSo = model.DauSo;
            _sdtRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.DauSo);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _sdtRepository.GetTracking(x => x.DauSo.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSoDienThoai.DAUSO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _sdtRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<SoDienThoaiEntity> GetAllAsync()
        {
            var entities = _sdtRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<SoDienThoaiEntity>)entities;
        }

        public SoDienThoaiEntity GetByKeyIdAsync(string id)
        {
            var entity = _sdtRepository.GetSingle(_ => _.DauSo.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, SoDienThoaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _sdtRepository.GetTracking(x => x.DauSo.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsSoDienThoai.DAUSO_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.DauSo != Id)
            {
                var isDuplicate = _sdtRepository.GetTracking(x => x.DauSo.Equals(model.DauSo) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsSoDienThoai.DAUSO_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _sdtRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public SoDienThoaiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public SoDienThoaiEntity GetByStrAsync(string sdt)
        {
            throw new NotImplementedException();
        }

        public UserEntity GetByUserNameAsync(RefreshTokenEntity model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<SoDienThoaiEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<SoDienThoaiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
