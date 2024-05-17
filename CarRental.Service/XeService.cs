using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Xe;
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
    [ScopedDependency(ServiceType = typeof(IXeService))]
    public class XeService : Base.Service, IXeService
    {

        private readonly IXeRepository _xeRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public XeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _xeRepository = serviceProvider.GetRequiredService<IXeRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(XeModel model, CancellationToken cancellationToken = default)
        {
            if (_xeRepository.Get(_ => _.IDXe.Equals(model.IDXe) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDXe);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsXe.XE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<XeEntity>(model);
            entity.IDXe = model.IDXe;
            _xeRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDXe);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _xeRepository.GetTracking(x => x.IDXe.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsXe.XE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _xeRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<XeEntity> GetAllAsync()
        {
            var entities = _xeRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<XeEntity>)entities;
        }
        public XeEntity GetByKeyIdAsync(string id)
        {
            var entity = _xeRepository.GetSingle(_ => _.IDXe.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }
        public ICollection<XeEntity> GetAllByAnotherKeyAsync(string idLoaiXe)
        {
            var entity = _xeRepository.Get(_ => _.IDLoaiXe.Equals(idLoaiXe) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public Task UpdateAsync(string Id, XeModel model, CancellationToken cancellationToken = default)
        {
            var entity = _xeRepository.GetTracking(x => x.IDXe.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsXe.XE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDXe != Id)
            {
                var isDuplicate = _xeRepository.GetTracking(x => x.IDXe.Equals(model.IDXe) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsXe.XE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _xeRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _xeRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public XeEntity GetByStrAsync(string str)
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
        public XeEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<XeEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }
    }
}
