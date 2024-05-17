using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models;
using CarRental.Core.Models.KhachHang;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        private readonly IKhachHangService _iKhachHangService;

        public KhachHangController(IKhachHangService iKhachHangService)
        {
            _iKhachHangService = iKhachHangService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetAllKhachHang)]
        public IActionResult GetAll()
        {
            var result = _iKhachHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhachHangEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetKhachHangBySDT)]
        public IActionResult GetKhachHangBySDT([FromRoute] string SoDienThoai)
        {
            var data = _iKhachHangService.GetByStrAsync(SoDienThoai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhachHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhachHang.GetKhachHang)]
        public IActionResult GetKhachHangById([FromRoute] string IDKhachHang)
        {
            var data = _iKhachHangService.GetByKeyIdAsync(IDKhachHang);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhachHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KhachHang.AddKhachHang)]
        public async Task<IActionResult> CreateKhachHang(KhachHangModel model)
        {
            try
            {
                var result = await _iKhachHangService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KhachHang.UpdateKhachHang)]
        public async Task<IActionResult> UpdateKhachHang([FromRoute] string IDKhachHang, KhachHangModel model)
        {
            try
            {
                await _iKhachHangService.UpdateAsync(IDKhachHang, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhachHang.UPDATE_KHACHHANG_SUCCESS));
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
        [Route(WebApiEndpoint.KhachHang.DeleteKhachHang)]
        public async Task<IActionResult> DeleteKhachHang([FromRoute] string IDKhachHang)
        {
            try
            {
                await _iKhachHangService.DeleteAsync(IDKhachHang, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhachHang.DELETE_KHACHHANG_SUCCESS));
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
        [Route(WebApiEndpoint.KhachHang.CountKhachHang)]
        public async Task<IActionResult> CountKhachHang()
        {
            try
            {
                var result = await _iKhachHangService.CountAsync();
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
        [Route(WebApiEndpoint.KhachHang.KhachHangLogin)]
        public IActionResult KhachHangLogin([FromRoute] string Email, [FromRoute] string PassWord)
        {
            var data = _iKhachHangService.KhachHangLogin(Email, PassWord);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKhachHang.KHACHHANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhachHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
