using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.PhongBan;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class PhongBanController : ControllerBase
    {
        private readonly IPhongBanService _iPhongBanService;

        public PhongBanController(IPhongBanService iPhongBanService)
        {
            _iPhongBanService = iPhongBanService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhongBan.GetAllPhongBan)]
        public IActionResult GetAll()
        {
            var result = _iPhongBanService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhongBanEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhongBan.GetPhongBan)]
        public IActionResult GetPhongBanById([FromRoute] string IDPhongBan)
        {
            var data = _iPhongBanService.GetByKeyIdAsync(IDPhongBan);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsPhongBan.PHONGBAN_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PhongBanEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PhongBan.AddPhongBan)]
        public async Task<IActionResult> CreatePhongBan(PhongBanModel model)
        {
            try
            {
                var result = await _iPhongBanService.CreateAsync(model);
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
        [Route(WebApiEndpoint.PhongBan.UpdatePhongBan)]
        public async Task<IActionResult> UpdatePhongBan([FromRoute] string IDPhongBan, PhongBanModel model)
        {
            try
            {
                await _iPhongBanService.UpdateAsync(IDPhongBan, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhongBan.UPDATE_PHONGBAN_SUCCESS));
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
        [Route(WebApiEndpoint.PhongBan.DeletePhongBan)]
        public async Task<IActionResult> DeletePhongBan([FromRoute] string IDPhongBan)
        {
            try
            {
                await _iPhongBanService.DeleteAsync(IDPhongBan, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhongBan.DELETE_PHONGBAN_SUCCESS));
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
        [Route(WebApiEndpoint.PhongBan.CountPhongBan)]
        public async Task<IActionResult> CountPhongBan()
        {
            try
            {
                var result = await _iPhongBanService.CountAsync();
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



