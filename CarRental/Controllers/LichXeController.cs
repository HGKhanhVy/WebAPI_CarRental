using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.LichXe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class LichXeController : ControllerBase
    {
        private readonly ILichXeService _iLichXeService;

        public LichXeController(ILichXeService iLichXeService)
        {
            _iLichXeService = iLichXeService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichXe.GetAllLichXe)]
        public IActionResult GetAll()
        {
            var result = _iLichXeService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<LichXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichXe.GetLichXe)]
        public IActionResult GetLichXeById([FromRoute] string IDLichXe)
        {
            var data = _iLichXeService.GetByKeyIdAsync(IDLichXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLichXe.LICHXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<LichXeEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.LichXe.PrintAllLichXeByIDXe)]
        public IActionResult GetAllLichXeByIDXe([FromRoute] string IDXe)
        {
            var data = _iLichXeService.GetAllByAnotherKeyAsync(IDXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsLichXe.LICHXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<LichXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.LichXe.AddLichXe)]
        public async Task<IActionResult> CreateLichXe(LichXeModel model)
        {
            try
            {
                var result = await _iLichXeService.CreateAsync(model);
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
        [Route(WebApiEndpoint.LichXe.UpdateLichXe)]
        public async Task<IActionResult> UpdateLichXe([FromRoute] string IDLichXe, LichXeModel model)
        {
            try
            {
                await _iLichXeService.UpdateAsync(IDLichXe, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLichXe.UPDATE_LICHXE_SUCCESS));
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
        [Route(WebApiEndpoint.LichXe.DeleteLichXe)]
        public async Task<IActionResult> DeleteLichXe([FromRoute] string IDLichXe)
        {
            try
            {
                await _iLichXeService.DeleteAsync(IDLichXe, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsLichXe.DELETE_LICHXE_SUCCESS));
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
        [Route(WebApiEndpoint.LichXe.CountLichXe)]
        public async Task<IActionResult> CountLichXe()
        {
            try
            {
                var result = await _iLichXeService.CountAsync();
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


