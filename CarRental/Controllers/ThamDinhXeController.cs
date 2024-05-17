using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.ThamDinhXe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class ThamDinhXeController : ControllerBase
    {
        private readonly IThamDinhXeService _iThamDinhXeService;

        public ThamDinhXeController(IThamDinhXeService iThamDinhXeService)
        {
            _iThamDinhXeService = iThamDinhXeService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThamDinhXe.GetAllThamDinhXe)]
        public IActionResult GetAll()
        {
            var result = _iThamDinhXeService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ThamDinhXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ThamDinhXe.GetThamDinhXe)]
        public IActionResult GetThamDinhXeById([FromRoute] string IDThamDinh)
        {
            var data = _iThamDinhXeService.GetByKeyIdAsync(IDThamDinh);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsThamDinhXe.THAMDINHXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ThamDinhXeEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ThamDinhXe.AddThamDinhXe)]
        public async Task<IActionResult> CreateThamDinhXe(ThamDinhXeModel model)
        {
            try
            {
                var result = await _iThamDinhXeService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ThamDinhXe.UpdateThamDinhXe)]
        public async Task<IActionResult> UpdateThamDinhXe([FromRoute] string IDThamDinh, ThamDinhXeModel model)
        {
            try
            {
                await _iThamDinhXeService.UpdateAsync(IDThamDinh, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThamDinhXe.UPDATE_THAMDINHXE_SUCCESS));
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
        [Route(WebApiEndpoint.ThamDinhXe.DeleteThamDinhXe)]
        public async Task<IActionResult> DeleteThamDinhXe([FromRoute] string IDThamDinh)
        {
            try
            {
                await _iThamDinhXeService.DeleteAsync(IDThamDinh, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsThamDinhXe.DELETE_THAMDINHXE_SUCCESS));
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
        [Route(WebApiEndpoint.ThamDinhXe.CountThamDinhXe)]
        public async Task<IActionResult> CountThamDinhXe()
        {
            try
            {
                var result = await _iThamDinhXeService.CountAsync();
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




