using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.ThanhLyHopDong;
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
    [ScopedDependency(ServiceType = typeof(IThanhLyHopDongService))]
    public class ThanhLyHopDongService : Base.Service, IThanhLyHopDongService
    {

        private readonly IThanhLyHopDongRepository _tlRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ThanhLyHopDongService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _tlRepository = serviceProvider.GetRequiredService<IThanhLyHopDongRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(ThanhLyHopDongModel model, CancellationToken cancellationToken = default)
        {
            if (_tlRepository.Get(_ => _.IDThanhLy.Equals(model.IDThanhLy) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDThanhLy);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsThanhLyHopDong.THANHLYHOPDONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ThanhLyHopDongEntity>(model);
            entity.IDThanhLy = model.IDThanhLy;
            _tlRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDThanhLy);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _tlRepository.GetTracking(x => x.IDThanhLy.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsThanhLyHopDong.THANHLYHOPDONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _tlRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ThanhLyHopDongEntity> GetAllAsync()
        {
            var entities = _tlRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<ThanhLyHopDongEntity>)entities;
        }
        public ICollection<ThanhLyHopDongEntity> GetByKeyIdNhanVienAsync(string idNV)
        {
            var entity = _tlRepository.Get(_ => _.IDNhanVien.Equals(idNV) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }
        public ICollection<ThanhLyHopDongEntity> GetAllThamDinhThueAsync()
        {
            var entity = _tlRepository.Get(_ => _.TenThanhLy.Substring(0, 2).Equals("TX") && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }
        public ICollection<ThanhLyHopDongEntity> GetAllThamDinhKyGuiAsync()
        {
            var entity = _tlRepository.Get(_ => _.TenThanhLy.Substring(0, 2).Equals("KG") && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public ThanhLyHopDongEntity GetByKeyIdAsync(string id)
        {
            var entity = _tlRepository.GetSingle(_ => _.IDThanhLy.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, ThanhLyHopDongModel model, CancellationToken cancellationToken = default)
        {
            var entity = _tlRepository.GetTracking(x => x.IDThanhLy.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsThanhLyHopDong.THANHLYHOPDONG_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDThanhLy != Id)
            {
                var isDuplicate = _tlRepository.GetTracking(x => x.IDThanhLy.Equals(model.IDThanhLy) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsThanhLyHopDong.THANHLYHOPDONG_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _tlRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _tlRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public ThanhLyHopDongEntity GetByStrAsync(string str)
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
        public ThanhLyHopDongEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<ThanhLyHopDongEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<ThanhLyHopDongEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
