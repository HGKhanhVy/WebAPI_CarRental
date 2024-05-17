using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.ChucVu;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuService _iChucVuService;

        public ChucVuController(IChucVuService iChucVuService)
        {
            _iChucVuService = iChucVuService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChucVu.GetAllChucVu)]
        public IActionResult GetAll()
        {
            var result = _iChucVuService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<ChucVuEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.ChucVu.GetChucVu)]
        public IActionResult GetChucVuById([FromRoute] string IDChucVu)
        {
            var data = _iChucVuService.GetByKeyIdAsync(IDChucVu);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsChucVu.CHUCVU_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ChucVuEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.ChucVu.AddChucVu)]
        public async Task<IActionResult> CreateChucVu(ChucVuModel model)
        {
            try
            {
                var result = await _iChucVuService.CreateAsync(model);
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
        [Route(WebApiEndpoint.ChucVu.UpdateChucVu)]
        public async Task<IActionResult> UpdateChucVu([FromRoute] string IDChucVu, ChucVuModel model)
        {
            try
            {
                await _iChucVuService.UpdateAsync(IDChucVu, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChucVu.UPDATE_CHUCVU_SUCCESS));
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
        [Route(WebApiEndpoint.ChucVu.DeleteChucVu)]
        public async Task<IActionResult> DeleteChucVu([FromRoute] string IDChucVu)
        {
            try
            {
                await _iChucVuService.DeleteAsync(IDChucVu, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsChucVu.DELETE_CHUCVU_SUCCESS));
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
        [Route(WebApiEndpoint.ChucVu.CountChucVu)]
        public async Task<IActionResult> CountChucVu()
        {
            try
            {
                var result = await _iChucVuService.CountAsync();
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

