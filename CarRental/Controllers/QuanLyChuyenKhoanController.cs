using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.QuanLyChuyenKhoan;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class QuanLyChuyenKhoanController : ControllerBase
    {
        private readonly IQuanLyChuyenKhoanService _iQuanLyChuyenKhoanService;

        public QuanLyChuyenKhoanController(IQuanLyChuyenKhoanService iQuanLyChuyenKhoanService)
        {
            _iQuanLyChuyenKhoanService = iQuanLyChuyenKhoanService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.QuanLyChuyenKhoan.GetAllQuanLyChuyenKhoan)]
        public IActionResult GetAll()
        {
            var result = _iQuanLyChuyenKhoanService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<QuanLyChuyenKhoanEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.QuanLyChuyenKhoan.GetQuanLyChuyenKhoan)]
        public IActionResult GetQuanLyChuyenKhoanById([FromRoute] string IDQuanLyCK)
        {
            var data = _iQuanLyChuyenKhoanService.GetByKeyIdAsync(IDQuanLyCK);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsQuanLyChuyenKhoan.QLCHUYENKHOAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<QuanLyChuyenKhoanEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.QuanLyChuyenKhoan.AddQuanLyChuyenKhoan)]
        public async Task<IActionResult> CreateQuanLyChuyenKhoan(QuanLyChuyenKhoanModel model)
        {
            try
            {
                var result = await _iQuanLyChuyenKhoanService.CreateAsync(model);
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
        [Route(WebApiEndpoint.QuanLyChuyenKhoan.UpdateQuanLyChuyenKhoan)]
        public async Task<IActionResult> UpdateQuanLyChuyenKhoan([FromRoute] string IDQuanLyCK, QuanLyChuyenKhoanModel model)
        {
            try
            {
                await _iQuanLyChuyenKhoanService.UpdateAsync(IDQuanLyCK, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsQuanLyChuyenKhoan.UPDATE_QLCHUYENKHOAN_SUCCESS));
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
        [Route(WebApiEndpoint.QuanLyChuyenKhoan.DeleteQuanLyChuyenKhoan)]
        public async Task<IActionResult> DeleteQuanLyChuyenKhoan([FromRoute] string IDQuanLyCK)
        {
            try
            {
                await _iQuanLyChuyenKhoanService.DeleteAsync(IDQuanLyCK, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsQuanLyChuyenKhoan.DELETE_QLCHUYENKHOAN_SUCCESS));
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
        [Route(WebApiEndpoint.QuanLyChuyenKhoan.CountQuanLyChuyenKhoan)]
        public async Task<IActionResult> CountQuanLyChuyenKhoan()
        {
            try
            {
                var result = await _iQuanLyChuyenKhoanService.CountAsync();
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




