using AutoMapper;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.User;
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
    [ScopedDependency(ServiceType = typeof(IUserService))]
    public class UserService : Base.Service, IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public UserService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(UserModel model, CancellationToken cancellationToken = default)
        {
            if (_userRepository.Get(_ => _.IDUser.Equals(model.IDUser) || _.Email.Equals(model.Email) && !_.TrangThai.Equals("Da xoa")).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.IDUser);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsUser.USER_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<UserEntity>(model);
            entity.IDUser = model.IDUser;
            _userRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.IDUser);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _userRepository.GetTracking(x => x.IDUser.Equals(id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsUser.USER_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _userRepository.Delete(entity, isPhysicalDelete: isPhysical);
            entity.TrangThai = "Da xoa";
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<UserEntity> GetAllAsync()
        {
            var entities = _userRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            return (ICollection<UserEntity>)entities;
        }

        public UserEntity GetByKeyIdAsync(string id)
        {
            var entity = _userRepository.GetSingle(_ => _.IDUser.Equals(id) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }
        public UserEntity GetByKeyEmailAsync(string Email)
        {
            var entity = _userRepository.GetSingle(_ => _.Email.Equals(Email) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }

        public Task UpdateAsync(string Id, UserModel model, CancellationToken cancellationToken = default)
        {
            var entity = _userRepository.GetTracking(x => x.IDUser.Equals(Id) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsUser.USER_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.IDUser != Id)
            {
                var isDuplicate = _userRepository.GetTracking(x => x.IDUser.Equals(model.IDUser) && !x.TrangThai.Equals("Da xoa")).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsUser.USER_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _userRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public Task<int> CountAsync()
        {
            var entities = _userRepository.Get(_ => !_.TrangThai.Equals("Da xoa")).ToList();
            int count = 0;
            foreach (var entity in entities)
                count++;
            return Task.FromResult(count);
        }
        public UserEntity UserLogin(string Email, string PassWord)
        {
            var entity = _userRepository.GetSingle(_ => _.Email.Equals(Email) && _.PassWord.Equals(PassWord) && !_.TrangThai.Equals("Da xoa"));
            return entity;
        }
        public UserEntity GetByStrAsync(string str)
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
        public UserEntity GetByLoginAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public UserEntity NhanVienLogin(string email, string mk)
        {
            throw new NotImplementedException();
        }

        public UserEntity KhachHangLogin(string email, string mk)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByAnotherKeyAsync(string idAnother, bool isPhysical, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserEntity> GetAllAnotherAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<UserEntity> GetAllByAnotherKeyAsync(string str)
        {
            throw new NotImplementedException();
        }
    }
}
