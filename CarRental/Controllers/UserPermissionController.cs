using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.UserPermission;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models;
using System.Security;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly IUserPermissionService _iUserPermissionService;

        public UserPermissionController(IUserPermissionService iUserPermissionService)
        {
            _iUserPermissionService = iUserPermissionService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.UserPermission.GetAllUserPermission)]
        public IActionResult GetAll()
        {
            var result = _iUserPermissionService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<UserPermissionEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.UserPermission.GetUserPermission)]
        public IActionResult GetUserPermissionById([FromRoute] string IDUser, [FromRoute] string IDPermission)
        {
            var data = _iUserPermissionService.GetByKeyIdAsync(IDUser, IDPermission);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsUserPermission.USERPERMISSION_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<UserPermissionEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.UserPermission.AddUserPermission)]
        public async Task<IActionResult> CreateUserPermission(UserPermissionModel model)
        {
            try
            {
                var result = await _iUserPermissionService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.UserPermission.UpdateUserPermission)]
        public async Task<IActionResult> UpdateUserPermission([FromRoute] string IDUser, [FromRoute] string IDPermission, UserPermissionModel model)
        {
            try
            {
                await _iUserPermissionService.UpdateAsync(IDUser, IDPermission, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsUserPermission.UPDATE_USERPERMISSION_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.UserPermission.DeleteUserPermission)]
        public async Task<IActionResult> DeleteUserPermission([FromRoute] string IDUser, [FromRoute] string IDPermission)
        {
            try
            {
                await _iUserPermissionService.DeleteAsync(IDUser, IDPermission, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsUserPermission.DELETE_USERPERMISSION_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route(WebApiEndpoint.UserPermission.CountUserPermission)]
        public async Task<IActionResult> CountUserPermission()
        {
            try
            {
                var result = await _iUserPermissionService.CountAsync();
                return Ok(new BaseResponseModel<int>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route(WebApiEndpoint.UserPermission.PrintAllUserPermissionByIDUser)]
        public IActionResult GetUserPermissionByIdUser([FromRoute] string IDUser)
        {
            var data = _iUserPermissionService.GetAllByKey1Async(IDUser);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsUserPermission.USERPERMISSION_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<UserPermissionEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.UserPermission.PrintAllUserPermissionByIDPer)]
        public IActionResult GetUserPermissionByIdPer([FromRoute] string IDPermission)
        {
            var data = _iUserPermissionService.GetAllByKey2Async(IDPermission);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsUserPermission.USERPERMISSION_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<UserPermissionEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
