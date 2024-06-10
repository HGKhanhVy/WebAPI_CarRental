using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.TinTuc;
using CarRental.Core.Models;
using FirebaseAdmin.Messaging;

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
        [Route("subscribe")]
        public async Task<IActionResult> SubscribeToTopic([FromBody] SubscribeModel model)
        {
            try
            {
                var registrationTokens = new List<string> { model.Token };
                var response = await FirebaseMessaging.DefaultInstance.SubscribeToTopicAsync(registrationTokens, model.Topic);

                return Ok(new { success = true, response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }

        public class SubscribeModel
        {
            public string Token { get; set; }
            public string Topic { get; set; }
        }


        [HttpPost]
        [Route(WebApiEndpoint.TinTuc.AddTinTuc)]
        public async Task<IActionResult> CreateTinTuc(TinTucModel model)
        {
            try
            {
                var result = await _iTinTucService.CreateAsync(model);

                var message = new FirebaseAdmin.Messaging.Message()
                {
                    Notification = new FirebaseAdmin.Messaging.Notification()
                    {
                        Title = model.TieuDe,
                        Body = model.NoiDung,
                        ImageUrl = "https://localhost:7046/uploads/" + model.HinhAnh,
                    },
                    Topic = "news"
                };

                string response = await FirebaseAdmin.Messaging.FirebaseMessaging.DefaultInstance.SendAsync(message);
                Console.WriteLine("Firebase notification response: " + response);
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
        [HttpPost("uploads")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var currentDirectory = Directory.GetCurrentDirectory();
                    var parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                    if (parentDirectory == null)
                    {
                        return BadRequest(new { message = "Failed to get parent directory." });
                    }
                    var uploadsFolder = Path.Combine(parentDirectory, "CarRental", "img");
                    var filePath = Path.Combine(uploadsFolder, file.FileName);

                    if (!System.IO.File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }

                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest(new { message = "No file uploaded." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while uploading the file.", details = ex.Message });
            }
        }


    }
}
