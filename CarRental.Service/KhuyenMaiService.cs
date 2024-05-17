﻿using AutoMapper;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KhuyenMai;
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
    [ScopedDependency(ServiceType = typeof(IKhuyenMaiService))]
    public class KhuyenMaiService : Base.Service, IKhuyenMaiService
    {

        private readonly IKhuyenMaiRepository _kmRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public KhuyenMaiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _kmRepository = serviceProvider.GetRequiredService<IKhuyenMaiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(KhuyenMaiModel model, CancellationToken cancellationToken = default)
        {
            if (_kmRepository.Get(_ => _.IDKhuyenMai.Equals(model.IDKhuyenMai) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDKhuyenMai);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<KhuyenMaiEntity>(model);
            entity.IDKhuyenMai = model.IDKhuyenMai;
            _kmRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDKhuyenMai);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _kmRepository.GetTracking(x => x.IDKhuyenMai.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _kmRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<KhuyenMaiEntity> GetAllAsync()
        {
            var entities = _kmRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<KhuyenMaiEntity>)entities;
        }
        public ICollection<KhuyenMaiEntity> GetAllAnotherAsync()
        {
            var entities = _kmRepository.Get(_ => _.ThoiGianKetThuc < DateTime.Now && !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<KhuyenMaiEntity>)entities;
        }

        public KhuyenMaiEntity GetByKeyIdAsync(string id)
        {
            var entity = _kmRepository.GetSingle(_ => _.IDKhuyenMai.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, KhuyenMaiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _kmRepository.GetTracking(x => x.IDKhuyenMai.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDKhuyenMai != Id)
            {
                var isDuplicate = _kmRepository.GetTracking(x => x.IDKhuyenMai.Equals(model.IDKhuyenMai) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _kmRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _kmRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public KhuyenMaiEntity GetByStrAsync(string str)
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
        public KhuyenMaiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<KhuyenMaiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
