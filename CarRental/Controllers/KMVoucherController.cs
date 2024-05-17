using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KMVoucher;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class KMVoucherController : ControllerBase
    {
        private readonly IKMVoucherService _iKMVoucherService;

        public KMVoucherController(IKMVoucherService iKMVoucherService)
        {
            _iKMVoucherService = iKMVoucherService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMVoucher.GetAllKMVoucher)]
        public IActionResult GetAll()
        {
            var result = _iKMVoucherService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KMVoucherEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMVoucher.GetKMVoucher)]
        public IActionResult GetKMVoucherById([FromRoute] string IDKhuyenMai)
        {
            var data = _iKMVoucherService.GetByKeyIdAsync(IDKhuyenMai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMVoucher.KMVOUCHER_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KMVoucherEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KMVoucher.PrintAllKMVoucherByIDCode)]
        public IActionResult GetAllKMVoucherByIDCode([FromRoute] string IDCode)
        {
            var data = _iKMVoucherService.GetByStrAsync(IDCode);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKMVoucher.KMVOUCHER_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KMVoucherEntity>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KMVoucher.AddKMVoucher)]
        public async Task<IActionResult> CreateKMVoucher(KMVoucherModel model)
        {
            try
            {
                var result = await _iKMVoucherService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KMVoucher.UpdateKMVoucher)]
        public async Task<IActionResult> UpdateKMVoucher([FromRoute] string IDKhuyenMai, KMVoucherModel model)
        {
            try
            {
                await _iKMVoucherService.UpdateAsync(IDKhuyenMai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMVoucher.UPDATE_KMVOUCHER_SUCCESS));
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
        [Route(WebApiEndpoint.KMVoucher.DeleteKMVoucher)]
        public async Task<IActionResult> DeleteKMVoucher([FromRoute] string IDKhuyenMai)
        {
            try
            {
                await _iKMVoucherService.DeleteAsync(IDKhuyenMai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKMVoucher.DELETE_KMVOUCHER_SUCCESS));
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
        [Route(WebApiEndpoint.KMVoucher.CountKMVoucher)]
        public async Task<IActionResult> CountKMVoucher()
        {
            try
            {
                var result = await _iKMVoucherService.CountAsync();
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


