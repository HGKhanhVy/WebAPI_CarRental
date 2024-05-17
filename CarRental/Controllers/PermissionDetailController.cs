using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.PermissionDetail;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class PermissionDetailController : ControllerBase
    {
        private readonly IPermissionDetailService _iPermissionDetailService;

        public PermissionDetailController(IPermissionDetailService iPermissionDetailService)
        {
            _iPermissionDetailService = iPermissionDetailService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.PermissionDetail.GetAllPermissionDetail)]
        public IActionResult GetAll()
        {
            var result = _iPermissionDetailService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PermissionDetailEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PermissionDetail.GetPermissionDetail)]
        public IActionResult GetPermissionDetailById([FromRoute] string IDPermissionDetail)
        {
            var data = _iPermissionDetailService.GetByKeyIdAsync(IDPermissionDetail);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsPermissionDetail.PERMISSIONDETAIL_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PermissionDetailEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PermissionDetail.PrintAllPermissionDetailByIDPermission)]
        public IActionResult GetAllPermissionDetailByIDXe([FromRoute] string IDPermission)
        {
            var data = _iPermissionDetailService.GetAllByAnotherKeyAsync(IDPermission);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsPermissionDetail.PERMISSIONDETAIL_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<PermissionDetailEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PermissionDetail.AddPermissionDetail)]
        public async Task<IActionResult> CreatePermissionDetail(PermissionDetailModel model)
        {
            try
            {
                var result = await _iPermissionDetailService.CreateAsync(model);
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
        [Route(WebApiEndpoint.PermissionDetail.UpdatePermissionDetail)]
        public async Task<IActionResult> UpdatePermissionDetail([FromRoute] string IDPermissionDetail, PermissionDetailModel model)
        {
            try
            {
                await _iPermissionDetailService.UpdateAsync(IDPermissionDetail, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPermissionDetail.UPDATE_PERMISSIONDETAIL_SUCCESS));
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
        [Route(WebApiEndpoint.PermissionDetail.DeletePermissionDetail)]
        public async Task<IActionResult> DeletePermissionDetail([FromRoute] string IDPermissionDetail)
        {
            try
            {
                await _iPermissionDetailService.DeleteAsync(IDPermissionDetail, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPermissionDetail.DELETE_PERMISSIONDETAIL_SUCCESS));
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
        [Route(WebApiEndpoint.PermissionDetail.CountPermissionDetail)]
        public async Task<IActionResult> CountPermissionDetail()
        {
            try
            {
                var result = await _iPermissionDetailService.CountAsync();
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
    }
}


