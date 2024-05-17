using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.SoDienThoai;
using CarRental.Core.Models;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class SoDienThoaiController : ControllerBase
    {
        private readonly ISoDienThoaiService _iSoDienThoaiService;

        public SoDienThoaiController(ISoDienThoaiService iSoDienThoaiService)
        {
            _iSoDienThoaiService = iSoDienThoaiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.SoDienThoai.GetAllDauSo)]
        public IActionResult GetAll()
        {
            var result = _iSoDienThoaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<SoDienThoaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.SoDienThoai.GetDauSo)]
        public IActionResult GetSoDienThoaiById([FromRoute] string DauSo)
        {
            var data = _iSoDienThoaiService.GetByKeyIdAsync(DauSo);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsSoDienThoai.DAUSO_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<SoDienThoaiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.SoDienThoai.AddDauSo)]
        public async Task<IActionResult> CreateSoDienThoai(SoDienThoaiModel model)
        {
            try
            {
                var result = await _iSoDienThoaiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.SoDienThoai.UpdateDauSo)]
        public async Task<IActionResult> UpdateSoDienThoai([FromRoute] string DauSo, SoDienThoaiModel model)
        {
            try
            {
                await _iSoDienThoaiService.UpdateAsync(DauSo, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSoDienThoai.UPDATE_DAUSO_SUCCESS));
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
        [Route(WebApiEndpoint.SoDienThoai.DeleteDauSo)]
        public async Task<IActionResult> DeleteSoDienThoai([FromRoute] string DauSo)
        {
            try
            {
                await _iSoDienThoaiService.DeleteAsync(DauSo, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsSoDienThoai.DELETE_DAUSO_SUCCESS));
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
