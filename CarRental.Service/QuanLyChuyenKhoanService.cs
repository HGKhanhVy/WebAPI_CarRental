using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.QuanLyChuyenKhoan;
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
    [ScopedDependency(ServiceType = typeof(IQuanLyChuyenKhoanService))]
    public class QuanLyChuyenKhoanService : Base.Service, IQuanLyChuyenKhoanService
    {

        private readonly IQuanLyChuyenKhoanRepository _qlckRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public QuanLyChuyenKhoanService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _qlckRepository = serviceProvider.GetRequiredService<IQuanLyChuyenKhoanRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(QuanLyChuyenKhoanModel model, CancellationToken cancellationToken = default)
        {
            if (_qlckRepository.Get(_ => _.IDQuanLyCK.Equals(model.IDQuanLyCK) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDQuanLyCK);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsQuanLyChuyenKhoan.QLCHUYENKHOAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<QuanLyChuyenKhoanEntity>(model);
            entity.IDQuanLyCK = model.IDQuanLyCK;
            _qlckRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDQuanLyCK);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _qlckRepository.GetTracking(x => x.IDQuanLyCK.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsQuanLyChuyenKhoan.QLCHUYENKHOAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _qlckRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<QuanLyChuyenKhoanEntity> GetAllAsync()
        {
            var entities = _qlckRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<QuanLyChuyenKhoanEntity>)entities;
        }
        public QuanLyChuyenKhoanEntity GetByKeyIdAsync(string id)
        {
            var entity = _qlckRepository.GetSingle(_ => _.IDQuanLyCK.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, QuanLyChuyenKhoanModel model, CancellationToken cancellationToken = default)
        {
            var entity = _qlckRepository.GetTracking(x => x.IDQuanLyCK.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsQuanLyChuyenKhoan.QLCHUYENKHOAN_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDQuanLyCK != Id)
            {
                var isDuplicate = _qlckRepository.GetTracking(x => x.IDQuanLyCK.Equals(model.IDQuanLyCK) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsQuanLyChuyenKhoan.QLCHUYENKHOAN_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _qlckRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _qlckRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public QuanLyChuyenKhoanEntity GetByStrAsync(string str)
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
        public QuanLyChuyenKhoanEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<QuanLyChuyenKhoanEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<QuanLyChuyenKhoanEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
