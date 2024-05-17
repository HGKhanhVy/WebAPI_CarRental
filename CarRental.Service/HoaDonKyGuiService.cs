using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HoaDonKyGui;
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
    [ScopedDependency(ServiceType = typeof(IHoaDonKyGuiService))]
    public class HoaDonKyGuiService : Base.Service, IHoaDonKyGuiService
    {

        private readonly IHoaDonKyGuiRepository _hdkgRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HoaDonKyGuiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdkgRepository = serviceProvider.GetRequiredService<IHoaDonKyGuiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HoaDonKyGuiModel model, CancellationToken cancellationToken = default)
        {
            if (_hdkgRepository.Get(_ => _.IDHoaDonKyGui.Equals(model.IDHoaDonKyGui) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDHoaDonKyGui);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HoaDonKyGuiEntity>(model);
            entity.IDHoaDonKyGui = model.IDHoaDonKyGui;
            _hdkgRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDHoaDonKyGui);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHoaDonKyGui.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdkgRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HoaDonKyGuiEntity> GetAllAsync()
        {
            var entities = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HoaDonKyGuiEntity>)entities;
        }

        public HoaDonKyGuiEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdkgRepository.GetSingle(_ => _.IDHoaDonKyGui.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HoaDonKyGuiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHoaDonKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDHoaDonKyGui != Id)
            {
                var isDuplicate = _hdkgRepository.GetTracking(x => x.IDHoaDonKyGui.Equals(model.IDHoaDonKyGui) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _hdkgRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public HoaDonKyGuiEntity GetByStrAsync(string str)
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
        public HoaDonKyGuiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonKyGuiEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonKyGuiEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HoaDonKyGuiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
