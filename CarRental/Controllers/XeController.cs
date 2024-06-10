using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.Xe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Service;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class XeController : ControllerBase
    {
        private readonly IXeService _iXeService;

        public XeController(IXeService iXeService)
        {
            _iXeService = iXeService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.Xe.GetAllXe)]
        public IActionResult GetAll()
        {
            var result = _iXeService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<XeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.Xe.GetXe)]
        public IActionResult GetXeById([FromRoute] string IDXe)
        {
            var data = _iXeService.GetByKeyIdAsync(IDXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsXe.XE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<XeEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpGet]
        [Route(WebApiEndpoint.Xe.PrintAllXeByIDLoaiXe)]
        public IActionResult GetAllXeByIDXe([FromRoute] string IDLoaiXe)
        {
            var data = _iXeService.GetAllByAnotherKeyAsync(IDLoaiXe);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsXe.XE_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<ICollection<XeEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.Xe.AddXe)]
        public async Task<IActionResult> CreateXe(XeModel model)
        {
            try
            {
                var result = await _iXeService.CreateAsync(model);
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
        [Route(WebApiEndpoint.Xe.UpdateXe)]
        public async Task<IActionResult> UpdateXe([FromRoute] string IDXe, XeModel model)
        {
            try
            {
                await _iXeService.UpdateAsync(IDXe, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsXe.UPDATE_XE_SUCCESS));
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
        [Route(WebApiEndpoint.Xe.DeleteXe)]
        public async Task<IActionResult> DeleteXe([FromRoute] string IDXe)
        {
            try
            {
                await _iXeService.DeleteAsync(IDXe, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsXe.DELETE_XE_SUCCESS));
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
        [Route(WebApiEndpoint.Xe.CountXe)]
        public async Task<IActionResult> CountXe()
        {
            try
            {
                var result = await _iXeService.CountAsync();
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
        [HttpPost("uploads-xe")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            try
            {
                if (files == null || files.Count == 0)
                {
                    return BadRequest(new { message = "No files uploaded." });
                }

                var currentDirectory = Directory.GetCurrentDirectory();
                var parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                if (parentDirectory == null)
                {
                    return BadRequest(new { message = "Failed to get parent directory." });
                }

                var uploadsFolder = Path.Combine(parentDirectory, "CarRental", "img");
                Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists

                var uploadedFiles = new List<string>();
                var duplicateFiles = new List<string>();

                foreach (var file in files)
                {
                    var filePath = Path.Combine(uploadsFolder, file.FileName);
                    if (System.IO.File.Exists(filePath))
                    {
                        duplicateFiles.Add(file.FileName);
                        continue;
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    uploadedFiles.Add(file.FileName);
                }

                return Ok(new
                {
                    uploadedFiles = uploadedFiles,
                    duplicateFiles = duplicateFiles
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while uploading the files.", details = ex.Message });
            }
        }

    }
}


