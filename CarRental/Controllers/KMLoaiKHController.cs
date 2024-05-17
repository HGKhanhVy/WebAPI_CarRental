using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KMLoaiKH;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class KMLoaiKHController : ControllerBase
    {
        private readonly IKMLoaiKHService _iKMLoaiKHService;

        public KMLoaiKHController(IKMLoaiKHService iKMLoaiKHService)
        {
            _iKMLoaiKHService = iKMLoaiKHService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMLoaiKH.GetAllKMLoaiKH)]
        public IActionResult GetAll()
        {
            var result = _iKMLoaiKHService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KMLoaiKHEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMLoaiKH.GetKMLoaiKH)]
        public IActionResult GetKMLoaiKHById([FromRoute] string IDKhuyenMai)
        {
            var data = _iKMLoaiKHService.GetByKeyIdAsync(IDKhuyenMai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMLoaiKH.KMLOAIKH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KMLoaiKHEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMLoaiKH.PrintAllKMLoaiKHByIDLoaiKH)]
        public IActionResult GetAllKMLoaiKHByIDLoaiKH([FromRoute] string IDLoaiKH)
        {
            var data = _iKMLoaiKHService.GetAllByAnotherKeyAsync(IDLoaiKH);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMLoaiKH.KMLOAIKH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<KMLoaiKHEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KMLoaiKH.AddKMLoaiKH)]
        public async Task<IActionResult> CreateKMLoaiKH(KMLoaiKHModel model)
        {
            try
            {
                var result = await _iKMLoaiKHService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KMLoaiKH.UpdateKMLoaiKH)]
        public async Task<IActionResult> UpdateKMLoaiKH([FromRoute] string IDKhuyenMai, KMLoaiKHModel model)
        {
            try
            {
                await _iKMLoaiKHService.UpdateAsync(IDKhuyenMai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMLoaiKH.UPDATE_KMLOAIKH_SUCCESS));
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
        [Route(WebApiEndpoint.KMLoaiKH.DeleteKMLoaiKH)]
        public async Task<IActionResult> DeleteKMLoaiKH([FromRoute] string IDKhuyenMai)
        {
            try
            {
                await _iKMLoaiKHService.DeleteAsync(IDKhuyenMai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMLoaiKH.DELETE_KMLOAIKH_SUCCESS));
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
        [Route(WebApiEndpoint.KMLoaiKH.DeleteKMLoaiKHByIDLoaiKH)]
        public async Task<IActionResult> DeleteKMLoaiKHByIDLoaiKH([FromRoute] string IDLoaiKH)
        {
            try
            {
                await _iKMLoaiKHService.DeleteByAnotherKeyAsync(IDLoaiKH, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMLoaiKH.DELETE_KMLOAIKH_SUCCESS));
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
        [Route(WebApiEndpoint.KMLoaiKH.CountKMLoaiKH)]
        public async Task<IActionResult> CountKMLoaiKH()
        {
            try
            {
                var result = await _iKMLoaiKHService.CountAsync();
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


