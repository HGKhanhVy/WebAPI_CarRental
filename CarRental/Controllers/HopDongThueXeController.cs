using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HopDongThueXe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class HopDongThueXeController : ControllerBase
    {
        private readonly IHopDongThueXeService _iHopDongThueXeService;

        public HopDongThueXeController(IHopDongThueXeService iHopDongThueXeService)
        {
            _iHopDongThueXeService = iHopDongThueXeService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDongThueXe.GetAllHopDongThueXe)]
        public IActionResult GetAll()
        {
            var result = _iHopDongThueXeService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HopDongThueXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDongThueXe.GetHopDongThueXe)]
        public IActionResult GetHopDongThueXeById([FromRoute] string IDHopDongThueXe)
        {
            var data = _iHopDongThueXeService.GetByKeyIdAsync(IDHopDongThueXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHopDongThueXe.HOPDONGTHUEXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HopDongThueXeEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HopDongThueXe.AddHopDongThueXe)]
        public async Task<IActionResult> CreateHopDongThueXe(HopDongThueXeModel model)
        {
            try
            {
                var result = await _iHopDongThueXeService.CreateAsync(model);
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
        [Route(WebApiEndpoint.HopDongThueXe.UpdateHopDongThueXe)]
        public async Task<IActionResult> UpdateHopDongThueXe([FromRoute] string IDHopDongThueXe, HopDongThueXeModel model)
        {
            try
            {
                await _iHopDongThueXeService.UpdateAsync(IDHopDongThueXe, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHopDongThueXe.UPDATE_HOPDONGTHUEXE_SUCCESS));
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
        [Route(WebApiEndpoint.HopDongThueXe.DeleteHopDongThueXe)]
        public async Task<IActionResult> DeleteHopDongThueXe([FromRoute] string IDHopDongThueXe)
        {
            try
            {
                await _iHopDongThueXeService.DeleteAsync(IDHopDongThueXe, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHopDongThueXe.DELETE_HOPDONGTHUEXE_SUCCESS));
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
        [Route(WebApiEndpoint.HopDongThueXe.CountHopDongThueXe)]
        public async Task<IActionResult> CountHopDongThueXe()
        {
            try
            {
                var result = await _iHopDongThueXeService.CountAsync();
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


