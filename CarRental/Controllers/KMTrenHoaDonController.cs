using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KMTrenHoaDon;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class KMTrenHoaDonController : ControllerBase
    {
        private readonly IKMTrenHoaDonService _iKMTrenHoaDonService;

        public KMTrenHoaDonController(IKMTrenHoaDonService iKMTrenHoaDonService)
        {
            _iKMTrenHoaDonService = iKMTrenHoaDonService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMTrenHoaDon.GetAllKMTrenHoaDon)]
        public IActionResult GetAll()
        {
            var result = _iKMTrenHoaDonService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KMTrenHoaDonEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMTrenHoaDon.GetKMTrenHoaDon)]
        public IActionResult GetKMTrenHoaDonById([FromRoute] string IDKhuyenMai)
        {
            var data = _iKMTrenHoaDonService.GetByKeyIdAsync(IDKhuyenMai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMTrenHoaDon.KMTRENHOADON_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KMTrenHoaDonEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KMTrenHoaDon.AddKMTrenHoaDon)]
        public async Task<IActionResult> CreateKMTrenHoaDon(KMTrenHoaDonModel model)
        {
            try
            {
                var result = await _iKMTrenHoaDonService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KMTrenHoaDon.UpdateKMTrenHoaDon)]
        public async Task<IActionResult> UpdateKMTrenHoaDon([FromRoute] string IDKhuyenMai, KMTrenHoaDonModel model)
        {
            try
            {
                await _iKMTrenHoaDonService.UpdateAsync(IDKhuyenMai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMTrenHoaDon.UPDATE_KMTRENHOADON_SUCCESS));
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
        [Route(WebApiEndpoint.KMTrenHoaDon.DeleteKMTrenHoaDon)]
        public async Task<IActionResult> DeleteKMTrenHoaDon([FromRoute] string IDKhuyenMai)
        {
            try
            {
                await _iKMTrenHoaDonService.DeleteAsync(IDKhuyenMai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMTrenHoaDon.DELETE_KMTRENHOADON_SUCCESS));
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
        [Route(WebApiEndpoint.KMTrenHoaDon.CountKMTrenHoaDon)]
        public async Task<IActionResult> CountKMTrenHoaDon()
        {
            try
            {
                var result = await _iKMTrenHoaDonService.CountAsync();
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



