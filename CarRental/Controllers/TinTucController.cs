using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.TinTuc;
using CarRental.Core.Models;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class TinTucController : ControllerBase
    {
        private readonly ITinTucService _iTinTucService;

        public TinTucController(ITinTucService iTinTucService)
        {
            _iTinTucService = iTinTucService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.TinTuc.GetAllTinTuc)]
        public IActionResult GetAll()
        {
            var result = _iTinTucService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TinTucEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TinTuc.GetTinTuc)]
        public IActionResult GetTinTucById([FromRoute] string IDTinTuc)
        {
            var data = _iTinTucService.GetByKeyIdAsync(IDTinTuc);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsTinTuc.TINTUC_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TinTucEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.TinTuc.AddTinTuc)]
        public async Task<IActionResult> CreateTinTuc(TinTucModel model)
        {
            try
            {
                var result = await _iTinTucService.CreateAsync(model);
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
        [Route(WebApiEndpoint.TinTuc.UpdateTinTuc)]
        public async Task<IActionResult> UpdateTinTuc([FromRoute] string IDTinTuc, TinTucModel model)
        {
            try
            {
                await _iTinTucService.UpdateAsync(IDTinTuc, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTinTuc.UPDATE_TINTUC_SUCCESS));
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
        [Route(WebApiEndpoint.TinTuc.DeleteTinTuc)]
        public async Task<IActionResult> DeleteTinTuc([FromRoute] string IDTinTuc)
        {
            try
            {
                await _iTinTucService.DeleteAsync(IDTinTuc, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTinTuc.DELETE_TINTUC_SUCCESS));
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
