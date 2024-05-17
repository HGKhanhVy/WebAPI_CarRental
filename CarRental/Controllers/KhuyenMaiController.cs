using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.KhuyenMai;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class KhuyenMaiController : ControllerBase
    {
        private readonly IKhuyenMaiService _iKhuyenMaiService;

        public KhuyenMaiController(IKhuyenMaiService iKhuyenMaiService)
        {
            _iKhuyenMaiService = iKhuyenMaiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhuyenMai.GetAllKhuyenMai)]
        public IActionResult GetAll()
        {
            var result = _iKhuyenMaiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<KhuyenMaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.KhuyenMai.GetKhuyenMai)]
        public IActionResult GetKhuyenMaiById([FromRoute] string IDKhuyenMai)
        {
            var data = _iKhuyenMaiService.GetByKeyIdAsync(IDKhuyenMai);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsKhuyenMai.KHUYENMAI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<KhuyenMaiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }
        [HttpGet]
        [Route(WebApiEndpoint.KhuyenMai.PrintAllKhuyenMaiChuaHetHan)]
        public IActionResult GetKhuyenMaiChuaHetHan()
        {
            var result = _iKhuyenMaiService.GetAllAnotherAsync();
            return Ok(new BaseResponseModel<ICollection<KhuyenMaiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpPost]
        [Route(WebApiEndpoint.KhuyenMai.AddKhuyenMai)]
        public async Task<IActionResult> CreateKhuyenMai(KhuyenMaiModel model)
        {
            try
            {
                var result = await _iKhuyenMaiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.KhuyenMai.UpdateKhuyenMai)]
        public async Task<IActionResult> UpdateKhuyenMai([FromRoute] string IDKhuyenMai, KhuyenMaiModel model)
        {
            try
            {
                await _iKhuyenMaiService.UpdateAsync(IDKhuyenMai, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhuyenMai.UPDATE_KHUYENMAI_SUCCESS));
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
        [Route(WebApiEndpoint.KhuyenMai.DeleteKhuyenMai)]
        public async Task<IActionResult> DeleteKhuyenMai([FromRoute] string IDKhuyenMai)
        {
            try
            {
                await _iKhuyenMaiService.DeleteAsync(IDKhuyenMai, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsKhuyenMai.DELETE_KHUYENMAI_SUCCESS));
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
        [Route(WebApiEndpoint.KhuyenMai.CountKhuyenMai)]
        public async Task<IActionResult> CountKhuyenMai()
        {
            try
            {
                var result = await _iKhuyenMaiService.CountAsync();
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


