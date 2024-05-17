using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Room;
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
    [ScopedDependency(ServiceType = typeof(IRoomService))]
    public class RoomService : Base.Service, IRoomService
    {

        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public RoomService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _roomRepository = serviceProvider.GetRequiredService<IRoomRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(RoomModel model, CancellationToken cancellationToken = default)
        {
            if (_roomRepository.Get(_ => _.IDRoom.Equals(model.IDRoom) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDRoom);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsRoom.ROOM_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<RoomEntity>(model);
            entity.IDRoom = model.IDRoom;
            _roomRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDRoom);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _roomRepository.GetTracking(x => x.IDRoom.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsRoom.ROOM_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _roomRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<RoomEntity> GetAllAsync()
        {
            var entities = _roomRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<RoomEntity>)entities;
        }

        public RoomEntity GetByKeyIdAsync(string id)
        {
            var entity = _roomRepository.GetSingle(_ => _.IDRoom.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, RoomModel model, CancellationToken cancellationToken = default)
        {
            var entity = _roomRepository.GetTracking(x => x.IDRoom.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsRoom.ROOM_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDRoom != Id)
            {
                var isDuplicate = _roomRepository.GetTracking(x => x.IDRoom.Equals(model.IDRoom) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsRoom.ROOM_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _roomRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _roomRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public Task UpdateStatusAsync()
        {
            throw new NotImplementedException();
        }
        public RoomEntity GetByStrAsync(string str)
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
        public RoomEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<RoomEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<RoomEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
