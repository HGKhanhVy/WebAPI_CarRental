using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.ThanhLyHopDong;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class ThanhLyHopDongController : ControllerBase
    {
        private readonly IThanhLyHopDongService _iThanhLyHopDongService;

        public ThanhLyHopDongController(IThanhLyHopDongService iThanhLyHopDongService)
        {
            _iThanhLyHopDongService = iThanhLyHopDongService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThanhLyHopDong.GetAllThanhLyHopDong)]
        public IActionResult GetAll()
        {
            var result = _iThanhLyHopDongService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ThanhLyHopDongEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThanhLyHopDong.GetThanhLyHopDong)]
        public IActionResult GetThanhLyHopDongById([FromRoute] string IDThanhLy)
        {
            var data = _iThanhLyHopDongService.GetByKeyIdAsync(IDThanhLy);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsThanhLyHopDong.THANHLYHOPDONG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ThanhLyHopDongEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ThanhLyHopDong.AddThanhLyHopDong)]
        public async Task<IActionResult> CreateThanhLyHopDong(ThanhLyHopDongModel model)
        {
            try
            {
                var result = await _iThanhLyHopDongService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ThanhLyHopDong.UpdateThanhLyHopDong)]
        public async Task<IActionResult> UpdateThanhLyHopDong([FromRoute] string IDThanhLy, ThanhLyHopDongModel model)
        {
            try
            {
                await _iThanhLyHopDongService.UpdateAsync(IDThanhLy, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThanhLyHopDong.UPDATE_THANHLYHOPDONG_SUCCESS));
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
        [Route(WebApiEndpoint.ThanhLyHopDong.DeleteThanhLyHopDong)]
        public async Task<IActionResult> DeleteThanhLyHopDong([FromRoute] string IDThanhLy)
        {
            try
            {
                await _iThanhLyHopDongService.DeleteAsync(IDThanhLy, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThanhLyHopDong.DELETE_THANHLYHOPDONG_SUCCESS));
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
        [Route(WebApiEndpoint.ThanhLyHopDong.CountThanhLyHopDong)]
        public async Task<IActionResult> CountThanhLyHopDong()
        {
            try
            {
                var result = await _iThanhLyHopDongService.CountAsync();
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





