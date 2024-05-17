using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.LichXe;
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
    [ScopedDependency(ServiceType = typeof(ILichXeService))]
    public class LichXeService : Base.Service, ILichXeService
    {

        private readonly ILichXeRepository _lxRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public LichXeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _lxRepository = serviceProvider.GetRequiredService<ILichXeRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(LichXeModel model, CancellationToken cancellationToken = default)
        {
            if (_lxRepository.Get(_ => _.IDLichXe.Equals(model.IDLichXe) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDLichXe);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichXe.LICHXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<LichXeEntity>(model);
            entity.IDLichXe = model.IDLichXe;
            _lxRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDLichXe);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _lxRepository.GetTracking(x => x.IDLichXe.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichXe.LICHXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _lxRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<LichXeEntity> GetAllAsync()
        {
            var entities = _lxRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<LichXeEntity>)entities;
        }
        public ICollection<LichXeEntity> GetAllByAnotherKeyAsync(string idXe)
        {
            var entity = _lxRepository.Get(_ => _.IDXe.Equals(idXe) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public LichXeEntity GetByKeyIdAsync(string id)
        {
            var entity = _lxRepository.GetSingle(_ => _.IDLichXe.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, LichXeModel model, CancellationToken cancellationToken = default)
        {
            var entity = _lxRepository.GetTracking(x => x.IDLichXe.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsLichXe.LICHXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDLichXe != Id)
            {
                var isDuplicate = _lxRepository.GetTracking(x => x.IDLichXe.Equals(model.IDLichXe) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsLichXe.LICHXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _lxRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _lxRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public LichXeEntity GetByStrAsync(string str)
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
        public LichXeEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<LichXeEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }
    }
}
