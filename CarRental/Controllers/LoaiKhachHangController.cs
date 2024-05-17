using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.LoaiKhachHang;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class LoaiKhachHangController : ControllerBase
    {
        private readonly ILoaiKhachHangService _iLoaiKhachHangService;

        public LoaiKhachHangController(ILoaiKhachHangService iLoaiKhachHangService)
        {
            _iLoaiKhachHangService = iLoaiKhachHangService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiKhachHang.GetAllLoaiKhachHang)]
        public IActionResult GetAll()
        {
            var result = _iLoaiKhachHangService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LoaiKhachHangEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LoaiKhachHang.GetLoaiKhachHang)]
        public IActionResult GetLoaiKhachHangById([FromRoute] string IDLoaiKH)
        {
            var data = _iLoaiKhachHangService.GetByKeyIdAsync(IDLoaiKH);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLoaiKhachHang.LOAIKHACHHANG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LoaiKhachHangEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LoaiKhachHang.AddLoaiKhachHang)]
        public async Task<IActionResult> CreateLoaiKhachHang(LoaiKhachHangModel model)
        {
            try
            {
                var result = await _iLoaiKhachHangService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LoaiKhachHang.UpdateLoaiKhachHang)]
        public async Task<IActionResult> UpdateLoaiKhachHang([FromRoute] string IDLoaiKH, LoaiKhachHangModel model)
        {
            try
            {
                await _iLoaiKhachHangService.UpdateAsync(IDLoaiKH, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiKhachHang.UPDATE_LOAIKHACHHANG_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiKhachHang.DeleteLoaiKhachHang)]
        public async Task<IActionResult> DeleteLoaiKhachHang([FromRoute] string IDLoaiKH)
        {
            try
            {
                await _iLoaiKhachHangService.DeleteAsync(IDLoaiKH, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLoaiKhachHang.DELETE_LOAIKHACHHANG_SUCCESS));
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
        [Route(WebApiEndpoint.LoaiKhachHang.CountLoaiKhachHang)]
        public async Task<IActionResult> CountLoaiKhachHang()
        {
            try
            {
                var result = await _iLoaiKhachHangService.CountAsync();
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



