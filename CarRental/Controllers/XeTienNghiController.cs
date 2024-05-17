using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.XeTienNghi;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models;
using System.Security;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class XeTienNghiController : ControllerBase
    {
        private readonly IXeTienNghiService _iXeTienNghiService;

        public XeTienNghiController(IXeTienNghiService iXeTienNghiService)
        {
            _iXeTienNghiService = iXeTienNghiService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.XeTienNghi.GetAllXeTienNghi)]
        public IActionResult GetAll()
        {
            var result = _iXeTienNghiService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<XeTienNghiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.XeTienNghi.GetXeTienNghi)]
        public IActionResult GetXeTienNghiById([FromRoute] string IDXe, [FromRoute] string IDTienNghi)
        {
            var data = _iXeTienNghiService.GetByKeyIdAsync(IDXe, IDTienNghi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<XeTienNghiEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.XeTienNghi.AddXeTienNghi)]
        public async Task<IActionResult> CreateXeTienNghi(XeTienNghiModel model)
        {
            try
            {
                var result = await _iXeTienNghiService.CreateAsync(model);
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
        [Route(WebApiEndpoint.XeTienNghi.UpdateXeTienNghi)]
        public async Task<IActionResult> UpdateXeTienNghi([FromRoute] string IDXe, [FromRoute] string IDTienNghi, XeTienNghiModel model)
        {
            try
            {
                await _iXeTienNghiService.UpdateAsync(IDXe, IDTienNghi, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsXeTienNghi.UPDATE_XETIENNGHI_SUCCESS));
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
        [Route(WebApiEndpoint.XeTienNghi.DeleteXeTienNghi)]
        public async Task<IActionResult> DeleteXeTienNghi([FromRoute] string IDXe, [FromRoute] string IDTienNghi)
        {
            try
            {
                await _iXeTienNghiService.DeleteAsync(IDXe, IDTienNghi, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsXeTienNghi.DELETE_XETIENNGHI_SUCCESS));
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
        [Route(WebApiEndpoint.XeTienNghi.CountXeTienNghi)]
        public async Task<IActionResult> CountXeTienNghi()
        {
            try
            {
                var result = await _iXeTienNghiService.CountAsync();
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

        [HttpGet]
        [Route(WebApiEndpoint.XeTienNghi.PrintAllXeTienNghiByIDXe)]
        public IActionResult GetXeTienNghiByIdUser([FromRoute] string IDXe)
        {
            var data = _iXeTienNghiService.GetAllByKey1Async(IDXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<XeTienNghiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.XeTienNghi.PrintAllXeTienNghiByIDTienNghi)]
        public IActionResult GetXeTienNghiByIdPer([FromRoute] string IDTienNghi)
        {
            var data = _iXeTienNghiService.GetAllByKey2Async(IDTienNghi);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsXeTienNghi.XETIENNGHI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<XeTienNghiEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }
    }
}
