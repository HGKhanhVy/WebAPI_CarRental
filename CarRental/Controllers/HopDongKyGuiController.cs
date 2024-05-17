using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HopDongKyGui;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class HopDongKyGuiController : ControllerBase
    {
        private readonly IHopDongKyGuiService _iHopDongKyGuiService;

        public HopDongKyGuiController(IHopDongKyGuiService iHopDongKyGuiService)
        {
            _iHopDongKyGuiService = iHopDongKyGuiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDongKyGui.GetAllHopDongKyGui)]
        public IActionResult GetAll()
        {
            var result = _iHopDongKyGuiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<HopDongKyGuiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDongKyGui.GetHopDongKyGui)]
        public IActionResult GetHopDongKyGuiById([FromRoute] string IDHopDongKyGui)
        {
            var data = _iHopDongKyGuiService.GetByKeyIdAsync(IDHopDongKyGui);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<HopDongKyGuiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.HopDongKyGui.AddHopDongKyGui)]
        public async Task<IActionResult> CreateHopDongKyGui(HopDongKyGuiModel model)
        {
            try
            {
                var result = await _iHopDongKyGuiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.HopDongKyGui.UpdateHopDongKyGui)]
        public async Task<IActionResult> UpdateHopDongKyGui([FromRoute] string IDHopDongKyGui, HopDongKyGuiModel model)
        {
            try
            {
                await _iHopDongKyGuiService.UpdateAsync(IDHopDongKyGui, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHopDongKyGui.UPDATE_HOPDONGKYGUI_SUCCESS));
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
        [Route(WebApiEndpoint.HopDongKyGui.DeleteHopDongKyGui)]
        public async Task<IActionResult> DeleteHopDongKyGui([FromRoute] string IDHopDongKyGui)
        {
            try
            {
                await _iHopDongKyGuiService.DeleteAsync(IDHopDongKyGui, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsHopDongKyGui.DELETE_HOPDONGKYGUI_SUCCESS));
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
        [Route(WebApiEndpoint.HopDongKyGui.CountHopDongKyGui)]
        public async Task<IActionResult> CountHopDongKyGui()
        {
            try
            {
                var result = await _iHopDongKyGuiService.CountAsync();
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


