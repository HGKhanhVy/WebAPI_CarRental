using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.TienNghi;
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
    [ScopedDependency(ServiceType = typeof(ITienNghiService))]
    public class TienNghiService : Base.Service, ITienNghiService
    {

        private readonly ITienNghiRepository _tnRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public TienNghiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _tnRepository = serviceProvider.GetRequiredService<ITienNghiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(TienNghiModel model, CancellationToken cancellationToken = default)
        {
            if (_tnRepository.Get(_ => _.IDTienNghi.Equals(model.IDTienNghi) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDTienNghi);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTienNghi.TIENNGHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<TienNghiEntity>(model);
            entity.IDTienNghi = model.IDTienNghi;
            _tnRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDTienNghi);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _tnRepository.GetTracking(x => x.IDTienNghi.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTienNghi.TIENNGHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _tnRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<TienNghiEntity> GetAllAsync()
        {
            var entities = _tnRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<TienNghiEntity>)entities;
        }

        public TienNghiEntity GetByKeyIdAsync(string id)
        {
            var entity = _tnRepository.GetSingle(_ => _.IDTienNghi.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, TienNghiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _tnRepository.GetTracking(x => x.IDTienNghi.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTienNghi.TIENNGHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDTienNghi != Id)
            {
                var isDuplicate = _tnRepository.GetTracking(x => x.IDTienNghi.Equals(model.IDTienNghi) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTienNghi.TIENNGHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _tnRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _tnRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public TienNghiEntity GetByStrAsync(string str)
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
        public TienNghiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<TienNghiEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TienNghiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
