using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.TrangThaiBaoDuong;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class TrangThaiBaoDuongController : ControllerBase
    {
        private readonly ITrangThaiBaoDuongService _iTrangThaiBaoDuongService;

        public TrangThaiBaoDuongController(ITrangThaiBaoDuongService iTrangThaiBaoDuongService)
        {
            _iTrangThaiBaoDuongService = iTrangThaiBaoDuongService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.TrangThaiBaoDuong.GetAllTrangThaiBaoDuong)]
        public IActionResult GetAll()
        {
            var result = _iTrangThaiBaoDuongService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TrangThaiBaoDuongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TrangThaiBaoDuong.GetTrangThaiBaoDuong)]
        public IActionResult GetTrangThaiBaoDuongById([FromRoute] string IDTrangThaiBD)
        {
            var data = _iTrangThaiBaoDuongService.GetByKeyIdAsync(IDTrangThaiBD);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsTrangThaiBaoDuong.TRANGTHAIBAODUONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TrangThaiBaoDuongEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.TrangThaiBaoDuong.AddTrangThaiBaoDuong)]
        public async Task<IActionResult> CreateTrangThaiBaoDuong(TrangThaiBaoDuongModel model)
        {
            try
            {
                var result = await _iTrangThaiBaoDuongService.CreateAsync(model);
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
        [Route(WebApiEndpoint.TrangThaiBaoDuong.UpdateTrangThaiBaoDuong)]
        public async Task<IActionResult> UpdateTrangThaiBaoDuong([FromRoute] string IDTrangThaiBD, TrangThaiBaoDuongModel model)
        {
            try
            {
                await _iTrangThaiBaoDuongService.UpdateAsync(IDTrangThaiBD, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTrangThaiBaoDuong.UPDATE_TRANGTHAIBAODUONG_SUCCESS));
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
        [Route(WebApiEndpoint.TrangThaiBaoDuong.DeleteTrangThaiBaoDuong)]
        public async Task<IActionResult> DeleteTrangThaiBaoDuong([FromRoute] string IDTrangThaiBD)
        {
            try
            {
                await _iTrangThaiBaoDuongService.DeleteAsync(IDTrangThaiBD, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTrangThaiBaoDuong.DELETE_TRANGTHAIBAODUONG_SUCCESS));
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
        [Route(WebApiEndpoint.TrangThaiBaoDuong.CountTrangThaiBaoDuong)]
        public async Task<IActionResult> CountTrangThaiBaoDuong()
        {
            try
            {
                var result = await _iTrangThaiBaoDuongService.CountAsync();
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





