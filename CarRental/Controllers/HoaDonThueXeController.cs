using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HoaDonThueXe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class HoaDonThueXeController : ControllerBase
    {
        private readonly IHoaDonThueXeService _iHoaDonThueXeService;

        public HoaDonThueXeController(IHoaDonThueXeService iHoaDonThueXeService)
        {
            _iHoaDonThueXeService = iHoaDonThueXeService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonThueXe.GetAllHoaDonThueXe)]
        public IActionResult GetAll()
        {
            var result = _iHoaDonThueXeService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HoaDonThueXeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonThueXe.GetHoaDonThueXe)]
        public IActionResult GetHoaDonThueXeById([FromRoute] string IDHoaDonThueXe)
        {
            var data = _iHoaDonThueXeService.GetByKeyIdAsync(IDHoaDonThueXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHoaDonThueXe.HOADONTHUEXE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HoaDonThueXeEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HoaDonThueXe.AddHoaDonThueXe)]
        public async Task<IActionResult> CreateHoaDonThueXe(HoaDonThueXeModel model)
        {
            try
            {
                var result = await _iHoaDonThueXeService.CreateAsync(model);
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
        [Route(WebApiEndpoint.HoaDonThueXe.UpdateHoaDonThueXe)]
        public async Task<IActionResult> UpdateHoaDonThueXe([FromRoute] string IDHoaDonThueXe, HoaDonThueXeModel model)
        {
            try
            {
                await _iHoaDonThueXeService.UpdateAsync(IDHoaDonThueXe, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHoaDonThueXe.UPDATE_HOADONTHUEXE_SUCCESS));
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
        [Route(WebApiEndpoint.HoaDonThueXe.DeleteHoaDonThueXe)]
        public async Task<IActionResult> DeleteHoaDonThueXe([FromRoute] string IDHoaDonThueXe)
        {
            try
            {
                await _iHoaDonThueXeService.DeleteAsync(IDHoaDonThueXe, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHoaDonThueXe.DELETE_HOADONTHUEXE_SUCCESS));
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
        [Route(WebApiEndpoint.HoaDonThueXe.CountHoaDonThueXe)]
        public async Task<IActionResult> CountHoaDonThueXe()
        {
            try
            {
                var result = await _iHoaDonThueXeService.CountAsync();
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


