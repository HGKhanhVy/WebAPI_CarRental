using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HopDongKyGui;
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
    [ScopedDependency(ServiceType = typeof(IHopDongKyGuiService))]
    public class HopDongKyGuiService : Base.Service, IHopDongKyGuiService
    {

        private readonly IHopDongKyGuiRepository _hdkgRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public HopDongKyGuiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _hdkgRepository = serviceProvider.GetRequiredService<IHopDongKyGuiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(HopDongKyGuiModel model, CancellationToken cancellationToken = default)
        {
            if (_hdkgRepository.Get(_ => _.IDHopDongKyGui.Equals(model.IDHopDongKyGui) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDHopDongKyGui);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<HopDongKyGuiEntity>(model);
            entity.IDHopDongKyGui = model.IDHopDongKyGui;
            _hdkgRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDHopDongKyGui);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _hdkgRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<HopDongKyGuiEntity> GetAllAsync()
        {
            var entities = _hdkgRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<HopDongKyGuiEntity>)entities;
        }

        public HopDongKyGuiEntity GetByKeyIdAsync(string id)
        {
            var entity = _hdkgRepository.GetSingle(_ => _.IDHopDongKyGui.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, HopDongKyGuiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDHopDongKyGui != Id)
            {
                var isDuplicate = _hdkgRepository.GetTracking(x => x.IDHopDongKyGui.Equals(model.IDHopDongKyGui) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
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
        public HopDongKyGuiEntity GetByStrAsync(string str)
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
        public HopDongKyGuiEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongKyGuiEntity> GetKhuyenMaiChuaHetHanAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongKyGuiEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<HopDongKyGuiEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
