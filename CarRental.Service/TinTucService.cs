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
using CarRental.Core.Models.TinTuc;

namespace CarRental.Service
{
    [ScopedDependency(ServiceType = typeof(ITinTucService))]
    public class TinTucService : Base.Service, ITinTucService
    {

        private readonly ITinTucRepository _tinRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public TinTucService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _tinRepository = serviceProvider.GetRequiredService<ITinTucRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(TinTucModel model, CancellationToken cancellationToken = default)
        {
            if (_tinRepository.Get(_ => _.IDTinTuc.Equals(model.IDTinTuc) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDTinTuc);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTinTuc.TINTUC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            int count = _tinRepository.Get(_ => !_.TrangThai.Equals("Da Xoa") || _.TrangThai == null).ToList().Count();
            count += 1;
            string maKH = "TT00" + count.ToString();
            model.IDTinTuc = maKH;
            var entity = _mapper.Map<TinTucEntity>(model);
            entity.IDTinTuc = model.IDTinTuc;
            _tinRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDTinTuc);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _tinRepository.GetTracking(x => x.IDTinTuc.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTinTuc.TINTUC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _tinRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<TinTucEntity> GetAllAsync()
        {
            var entities = _tinRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<TinTucEntity>)entities;
        }

        public TinTucEntity GetByKeyIdAsync(string id)
        {
            var entity = _tinRepository.GetSingle(_ => _.IDTinTuc.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, TinTucModel model, CancellationToken cancellationToken = default)
        {
            var entity = _tinRepository.GetTracking(x => x.IDTinTuc.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTinTuc.TINTUC_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDTinTuc != Id)
            {
                var isDuplicate = _tinRepository.GetTracking(x => x.IDTinTuc.Equals(model.IDTinTuc) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTinTuc.TINTUC_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _tinRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public TinTucEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public TinTucEntity GetByStrAsync(string sdt)
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

        public ICollection<TinTucEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TinTucEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
