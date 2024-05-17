using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.XeTienNghi;
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
    [ScopedDependency(ServiceType = typeof(IXeTienNghiService))]
    public class XeTienNghiService : Base.Service, IXeTienNghiService
    {

        private readonly IXeTienNghiRepository _xetnRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public XeTienNghiService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _xetnRepository = serviceProvider.GetRequiredService<IXeTienNghiRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<int> CountAsync()
        {
            var entities = _xetnRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }

        public Task<string> CreateAsync(XeTienNghiModel model, CancellationToken cancellationToken = default)
        {
            if (_xetnRepository.Get(_ => _.IDXe.Equals(model.IDXe) && _.IDTienNghi.Equals(model.IDTienNghi) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDXe + " - " + model.IDTienNghi);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<XeTienNghiEntity>(model);
            entity.IDXe = model.IDXe;
            entity.IDTienNghi = model.IDTienNghi;
            _xetnRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDXe + " - " + entity.IDTienNghi);
        }

        public Task DeleteAsync(string idXe, string idTienNghi, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _xetnRepository.GetTracking(x => x.IDXe.Equals(idXe) && x.IDTienNghi.Equals(idTienNghi) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, idXe + " - " + idTienNghi);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _xetnRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<XeTienNghiEntity> GetAllAsync()
        {
            var entities = _xetnRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<XeTienNghiEntity>)entities;
        }

        public XeTienNghiEntity GetByKeyIdAsync(string idXe, string idTienNghi)
        {
            var entity = _xetnRepository.GetSingle(_ => _.IDXe.Equals(idXe) && _.IDTienNghi.Equals(idTienNghi) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string idXe, string idTienNghi, XeTienNghiModel model, CancellationToken cancellationToken = default)
        {
            var entity = _xetnRepository.GetTracking(x => x.IDXe.Equals(idXe) && x.IDTienNghi.Equals(idTienNghi) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, idXe + " - " + idTienNghi);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDXe != idXe && model.IDTienNghi != idTienNghi)
            {
                var isDuplicate = _xetnRepository.GetTracking(x => x.IDXe.Equals(model.IDXe) && x.IDTienNghi.Equals(model.IDTienNghi) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, idXe);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _xetnRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<XeTienNghiEntity> GetAllByKey1Async(string idXe)
        {
            var entities = _xetnRepository.Get(_ => _.IDXe.Equals(idXe)).ToList();
            return (ICollection<XeTienNghiEntity>)entities;
        }

        public ICollection<XeTienNghiEntity> GetAllByKey2Async(string idTienNghi)
        {
            var entities = _xetnRepository.Get(_ => _.IDTienNghi.Equals(idTienNghi)).ToList();
            return (ICollection<XeTienNghiEntity>)entities;
        }


    }
}
