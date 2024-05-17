using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.TrangThaiBaoDuong;
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
    [ScopedDependency(ServiceType = typeof(ITrangThaiBaoDuongService))]
    public class TrangThaiBaoDuongService : Base.Service, ITrangThaiBaoDuongService
    {

        private readonly ITrangThaiBaoDuongRepository _ttbdRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public TrangThaiBaoDuongService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _ttbdRepository = serviceProvider.GetRequiredService<ITrangThaiBaoDuongRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(TrangThaiBaoDuongModel model, CancellationToken cancellationToken = default)
        {
            if (_ttbdRepository.Get(_ => _.IDTrangThaiBD.Equals(model.IDTrangThaiBD) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDTrangThaiBD);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTrangThaiBaoDuong.TRANGTHAIBAODUONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<TrangThaiBaoDuongEntity>(model);
            entity.IDTrangThaiBD = model.IDTrangThaiBD;
            _ttbdRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDTrangThaiBD);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _ttbdRepository.GetTracking(x => x.IDTrangThaiBD.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTrangThaiBaoDuong.TRANGTHAIBAODUONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _ttbdRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<TrangThaiBaoDuongEntity> GetAllAsync()
        {
            var entities = _ttbdRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<TrangThaiBaoDuongEntity>)entities;
        }
        public ICollection<TrangThaiBaoDuongEntity> GetByKeyIdXeAsync(string idXe)
        {
            var entity = _ttbdRepository.Get(_ => _.IDXe.Equals(idXe) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public TrangThaiBaoDuongEntity GetByKeyIdAsync(string id)
        {
            var entity = _ttbdRepository.GetSingle(_ => _.IDTrangThaiBD.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, TrangThaiBaoDuongModel model, CancellationToken cancellationToken = default)
        {
            var entity = _ttbdRepository.GetTracking(x => x.IDTrangThaiBD.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsTrangThaiBaoDuong.TRANGTHAIBAODUONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDTrangThaiBD != Id)
            {
                var isDuplicate = _ttbdRepository.GetTracking(x => x.IDTrangThaiBD.Equals(model.IDTrangThaiBD) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsTrangThaiBaoDuong.TRANGTHAIBAODUONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _ttbdRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _ttbdRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public TrangThaiBaoDuongEntity GetByStrAsync(string str)
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
        public TrangThaiBaoDuongEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<TrangThaiBaoDuongEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TrangThaiBaoDuongEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
