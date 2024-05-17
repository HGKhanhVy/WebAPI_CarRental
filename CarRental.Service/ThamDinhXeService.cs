using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Login;
using CarRental.Core.Models.ThamDinhXe;
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
    [ScopedDependency(ServiceType = typeof(IThamDinhXeService))]
    public class ThamDinhXeService : Base.Service, IThamDinhXeService
    {

        private readonly IThamDinhXeRepository _tdRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public ThamDinhXeService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _tdRepository = serviceProvider.GetRequiredService<IThamDinhXeRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(ThamDinhXeModel model, CancellationToken cancellationToken = default)
        {
            if (_tdRepository.Get(_ => _.IDThamDinh.Equals(model.IDThamDinh) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDThamDinh);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsThamDinhXe.THAMDINHXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<ThamDinhXeEntity>(model);
            entity.IDThamDinh = model.IDThamDinh;
            _tdRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDThamDinh);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _tdRepository.GetTracking(x => x.IDThamDinh.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsThamDinhXe.THAMDINHXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _tdRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<ThamDinhXeEntity> GetAllAsync()
        {
            var entities = _tdRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<ThamDinhXeEntity>)entities;
        }
        
        

        public ThamDinhXeEntity GetByKeyIdAsync(string id)
        {
            var entity = _tdRepository.GetSingle(_ => _.IDThamDinh.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, ThamDinhXeModel model, CancellationToken cancellationToken = default)
        {
            var entity = _tdRepository.GetTracking(x => x.IDThamDinh.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsThamDinhXe.THAMDINHXE_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDThamDinh != Id)
            {
                var isDuplicate = _tdRepository.GetTracking(x => x.IDThamDinh.Equals(model.IDThamDinh) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsThamDinhXe.THAMDINHXE_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _tdRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _tdRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public ThamDinhXeEntity GetByStrAsync(string str)
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
        public ThamDinhXeEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public ICollection<ThamDinhXeEntity> GetAllThamDinhThueAsync()
        {
            var entity = _tdRepository.Get(_ => _.TenThamDinh.Substring(0, 2).Equals("TX") && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }
        public ICollection<ThamDinhXeEntity> GetAllThamDinhKyGuiAsync()
        {
            var entity = _tdRepository.Get(_ => _.TenThamDinh.Substring(0, 2).Equals("KG") && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public ICollection<ThamDinhXeEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }
        public ICollection<ThamDinhXeEntity> GetByKeyIdKhachHangAsync(string idKH)
        {
            var entity = _tdRepository.Get(_ => _.IDKhachHang.Equals(idKH) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }
        public ICollection<ThamDinhXeEntity> GetByKeyIdNhanVienAsync(string idNV)
        {
            var entity = _tdRepository.Get(_ => _.IDNhanVien.Equals(idNV) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }
        public ICollection<ThamDinhXeEntity> GetByKeyIdXeAsync(string idXe)
        {
            var entity = _tdRepository.Get(_ => _.IDXe.Equals(idXe) && !_.TrangThai.Equals("Da xoa")).ToList();
            return entity;
        }

        public ICollection<ThamDinhXeEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
