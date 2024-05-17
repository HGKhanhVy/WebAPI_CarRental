using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.LoaiXe;
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
    [ScopedDependency(ServiceType = typeof(ILoaiXeService))]
    public class LoaiXeService : Base.Service, ILoaiXeService
    {

        private readonly ILoaiXeRepository _loaixeRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LoaiXeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _loaixeRepository = serviceProvider.GetRequiredService<ILoaiXeRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LoaiXeModel model, CancellationToken cancellationToken = default)
        {
            if (_loaixeRepository.Get(_ => _.IDLoaiXe.Equals(model.IDLoaiXe) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDLoaiXe);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiXe.LOAIXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LoaiXeEntity>(model);
            entity.IDLoaiXe = model.IDLoaiXe;
            _loaixeRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDLoaiXe);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _loaixeRepository.GetTracking(x => x.IDLoaiXe.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiXe.LOAIXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _loaixeRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LoaiXeEntity> GetAllAsync()
        {
            var entities = _loaixeRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<LoaiXeEntity>)entities;
        }
        public LoaiXeEntity GetByKeyIdAsync(string id)
        {
            var entity = _loaixeRepository.GetSingle(_ => _.IDLoaiXe.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, LoaiXeModel model, CancellationToken cancellationToken = default)
        {
            var entity = _loaixeRepository.GetTracking(x => x.IDLoaiXe.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLoaiXe.LOAIXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDLoaiXe != Id)
            {
                var isDuplicate = _loaixeRepository.GetTracking(x => x.IDLoaiXe.Equals(model.IDLoaiXe) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLoaiXe.LOAIXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _loaixeRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _loaixeRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public LoaiXeEntity GetByStrAsync(string str)
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
        public LoaiXeEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoaiXeEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<LoaiXeEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
