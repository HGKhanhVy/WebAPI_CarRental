using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KMLoaiXe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class KMLoaiXeController : ControllerBase
    {
        private readonly IKMLoaiXeService _iKMLoaiXeService;

        public KMLoaiXeController(IKMLoaiXeService iKMLoaiXeService)
        {
            _iKMLoaiXeService = iKMLoaiXeService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMLoaiXe.GetAllKMLoaiXe)]
        public IActionResult GetAll()
        {
            var result = _iKMLoaiXeService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KMLoaiXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMLoaiXe.GetKMLoaiXe)]
        public IActionResult GetKMLoaiXeById([FromRoute] string IDKhuyenMai)
        {
            var data = _iKMLoaiXeService.GetByKeyIdAsync(IDKhuyenMai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMLoaiXe.KMLOAIXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KMLoaiXeEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMLoaiXe.PrintAllKMLoaiXeByIDLoaiXe)]
        public IActionResult GetAllKMLoaiXeByIDLoaiXe([FromRoute] string IDLoaiXe)
        {
            var data = _iKMLoaiXeService.GetAllByAnotherKeyAsync(IDLoaiXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMLoaiXe.KMLOAIXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<KMLoaiXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KMLoaiXe.AddKMLoaiXe)]
        public async Task<IActionResult> CreateKMLoaiXe(KMLoaiXeModel model)
        {
            try
            {
                var result = await _iKMLoaiXeService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KMLoaiXe.UpdateKMLoaiXe)]
        public async Task<IActionResult> UpdateKMLoaiXe([FromRoute] string IDKhuyenMai, KMLoaiXeModel model)
        {
            try
            {
                await _iKMLoaiXeService.UpdateAsync(IDKhuyenMai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMLoaiXe.UPDATE_KMLOAIXE_SUCCESS));
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
        [Route(WebApiEndpoint.KMLoaiXe.DeleteKMLoaiXe)]
        public async Task<IActionResult> DeleteKMLoaiXe([FromRoute] string IDKhuyenMai)
        {
            try
            {
                await _iKMLoaiXeService.DeleteAsync(IDKhuyenMai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMLoaiXe.DELETE_KMLOAIXE_SUCCESS));
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
        [Route(WebApiEndpoint.KMLoaiXe.DeleteKMLoaiXeByIDLoaiXe)]
        public async Task<IActionResult> DeleteKMLoaiXeByIDLoaiXe([FromRoute] string IDLoaiXe)
        {
            try
            {
                await _iKMLoaiXeService.DeleteByAnotherKeyAsync(IDLoaiXe, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMLoaiXe.DELETE_KMLOAIXE_SUCCESS));
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
        [Route(WebApiEndpoint.KMLoaiXe.CountKMLoaiXe)]
        public async Task<IActionResult> CountKMLoaiXe()
        {
            try
            {
                var result = await _iKMLoaiXeService.CountAsync();
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


