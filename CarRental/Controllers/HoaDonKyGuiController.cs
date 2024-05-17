using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HoaDonKyGui;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Core.Models;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class HoaDonKyGuiController : ControllerBase
    {
        private readonly IHoaDonKyGuiService _iHoaDonKyGuiService;

        public HoaDonKyGuiController(IHoaDonKyGuiService iHoaDonKyGuiService)
        {
            _iHoaDonKyGuiService = iHoaDonKyGuiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonKyGui.GetAllHoaDonKyGui)]
        public IActionResult GetAll()
        {
            var result = _iHoaDonKyGuiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HoaDonKyGuiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HoaDonKyGui.GetHoaDonKyGui)]
        public IActionResult GetHoaDonKyGuiById([FromRoute] string IDHoaDonKyGui)
        {
            var data = _iHoaDonKyGuiService.GetByKeyIdAsync(IDHoaDonKyGui);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHoaDonKyGui.HOADONKYGUI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HoaDonKyGuiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HoaDonKyGui.AddHoaDonKyGui)]
        public async Task<IActionResult> CreateHoaDonKyGui(HoaDonKyGuiModel model)
        {
            try
            {
                var result = await _iHoaDonKyGuiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.HoaDonKyGui.UpdateHoaDonKyGui)]
        public async Task<IActionResult> UpdateHoaDonKyGui([FromRoute] string IDHoaDonKyGui, HoaDonKyGuiModel model)
        {
            try
            {
                await _iHoaDonKyGuiService.UpdateAsync(IDHoaDonKyGui, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHoaDonKyGui.UPDATE_HOADONKYGUI_SUCCESS));
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
        [Route(WebApiEndpoint.HoaDonKyGui.DeleteHoaDonKyGui)]
        public async Task<IActionResult> DeleteHoaDonKyGui([FromRoute] string IDHoaDonKyGui)
        {
            try
            {
                await _iHoaDonKyGuiService.DeleteAsync(IDHoaDonKyGui, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHoaDonKyGui.DELETE_HOADONKYGUI_SUCCESS));
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
        [Route(WebApiEndpoint.HoaDonKyGui.CountHoaDonKyGui)]
        public async Task<IActionResult> CountHoaDonKyGui()
        {
            try
            {
                var result = await _iHoaDonKyGuiService.CountAsync();
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


