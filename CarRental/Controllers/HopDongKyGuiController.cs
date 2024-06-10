using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CarRental.Contract.Repository.Models;
using CarRental.Contract.Service;
using CarRental.Core.Constants;
using CarRental.Core.Exceptions;
using CarRental.Core.Models.HopDongKyGui;
using CarRental.Core.Models.Xe;
using CarRental.Core.Models;
using static CarRental.Core.Constants.WebApiEndpoint;
using CarRental.Core.Models.ThanhLyHopDong;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    public class HopDongKyGuiController : ControllerBase
    {
        private readonly IHopDongKyGuiService _iHopDongKyGuiService;
        private readonly IXeTienNghiService _xeTienNghiService;
        private readonly IXeService _xeService;
        private readonly IThanhLyHopDongService _tlhdService;

        public HopDongKyGuiController(IHopDongKyGuiService iHopDongKyGuiService, IXeService xeService, IXeTienNghiService xeTienNghiService,
            IThanhLyHopDongService tlhdService)
        {
            _iHopDongKyGuiService = iHopDongKyGuiService;
            _xeService = xeService;
            _xeTienNghiService = xeTienNghiService;
            _tlhdService = tlhdService;
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

        [HttpGet]
        [Route(WebApiEndpoint.HopDongKyGui.ShowDetail)]
        public IActionResult ShowDetailHopDong([FromRoute] string IDHopDongKyGui)
        {
            var data = _iHopDongKyGuiService.ShowDetailHopDong(IDHopDongKyGui);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route(WebApiEndpoint.HopDongKyGui.InhHopDong)]
        public IActionResult InHopDong([FromRoute] string IDHopDongKyGui)
        {
            var fileContentResult = _iHopDongKyGuiService.PrintHopDong(IDHopDongKyGui);
            if (fileContentResult == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsHopDongKyGui.HOPDONGKYGUI_NOT_FOUND);
                return BadRequest(result);
            }

            return fileContentResult;
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

        [HttpPost]
        [Route(WebApiEndpoint.HopDongKyGui.CreateHopDongKyGui)]
        public async Task<IActionResult> AddHopDongKyGui(HopDongKyGuiCreate model)
        {
            try
            {
                int getidhopdong = _iHopDongKyGuiService.getIDHopDongKyGui(); // Retrieve the current maximum ID
                getidhopdong++; // Increment the ID to get the new ID
                string idHopdongKyGui = "HDKG00" + getidhopdong.ToString();
                string soHopDong = "0000" + getidhopdong.ToString();

                int getidxe = _xeService.getIDXe();  // Retrieve the current maximum ID
                getidxe++;  // Increment the ID to get the new ID
                string idXe = "X00" + getidxe.ToString();
                HopDongKyGuiModel hdkg = new HopDongKyGuiModel
                {
                    IDHopDongKyGui = idHopdongKyGui,
                    SoHopDong = soHopDong,
                    IDKhachHang = model.IDKhachHang,
                    IDNhanVien = model.IDNhanVien,
                    IDXe = idXe,
                    NgayLap = model.NgayLap,
                    PhanTramHoaHong = model.PhanTramHoaHong,
                    PhuongThucThanhToan = model.PhuongThucThanhToan,
                    DinhKyThanhToan = model.DinhKyThanhToan,
                    ThoiDiemThanhToan = model.ThoiDiemThanhToan,
                    NgayHieuLuc = model.NgayHieuLuc,
                    NgayHetHan = model.NgayHetHan,
                    XacNhan = model.XacNhan,
                    HinhAnhHopDong = model.HinhAnhHopDong,
                    UpdateAt = DateTime.Now,
                    UpdateBy = model.IDNhanVien,
                };
                XeModel x = new XeModel
                {
                    IDXe = idXe,
                    IDLoaiXe = model.IDLoaiXe,
                    TruyenDong = model.TruyenDong,
                    NhienLieu = model.NhienLieu,
                    NguyenLieuTieuHao = model.NguyenLieuTieuHao,
                    TenXe = model.TenXe,
                    BienSoXe = model.BienSoXe,
                    HangXe = model.HangXe,
                    NamSanXuat = model.NamSanXuat,
                    SoChoNgoi = model.SoChoNgoi,
                    GiaThue = model.GiaThue,
                    MoTa = model.MoTa,
                    HinhAnh1 = model.HinhAnh1,
                    HinhAnh2 = model.HinhAnh2,
                    HinhAnh3 = model.HinhAnh3,
                    HinhAnh4 = model.HinhAnh4,
                };
                var resultXe = await _xeService.CreateAsync(x);
                var resultHopDong = await _iHopDongKyGuiService.CreateAsync(hdkg);             
                var resultXeTienNghi = _xeTienNghiService.CreateableList(idXe, model.IDTienNghi);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: resultHopDong));
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

        [HttpPost("ThanhLyHopDong")]
        public async Task<IActionResult> ThanhLyHopDong([FromQuery] string idHopDongKyGui, [FromQuery] string idNhanVien)
        {
            try
            {
                // Gọi hàm ThanhLyHopDong trong service
                await _iHopDongKyGuiService.ThanhLyHopDong(idHopDongKyGui);

                // Tạo đối tượng ThanhLyHopDongModel để thêm vào bảng thanh lý
                ThanhLyHopDongModel thanhLyModel = new ThanhLyHopDongModel
                {
                    IDThanhLy = Guid.NewGuid().ToString(),
                    IDNhanVien = idNhanVien,
                    TenThanhLy = idHopDongKyGui,
                    NgayThanhLy = DateTime.Now,
                    XacNhanCuaAdmin = true, // Thay thế với giá trị thích hợp
                    XacNhanThamDinh = true  // Thay thế với giá trị thích hợp
                };

                // Gọi hàm CreateThanhLyHopDong trong service để thêm thanh lý mới
                var idThanhLy = await _tlhdService.CreateAsync(thanhLyModel);

                return Ok(new { idThanhLy });
            }
            catch (CoreException ex)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: ex.StatusCode,
                    code: ex.Code,
                    message: ex.Message
                );
                return StatusCode(ex.StatusCode, result);
            }
            catch (Exception ex)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: ex.Message
                );
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpGet("DuyetHopDong")]
        public async Task<IActionResult> DuyetHopDong(string idHopDongKyGui)
        {
            try
            {
                // Gọi hàm ThanhLyHopDong trong service
                await _iHopDongKyGuiService.DuyetHopDong(idHopDongKyGui);
                return Ok("Thanh cong");
            }
            catch (CoreException ex)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: ex.StatusCode,
                    code: ex.Code,
                    message: ex.Message
                );
                return StatusCode(ex.StatusCode, result);
            }
            catch (Exception ex)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: ex.Message
                );
                return StatusCode(StatusCodes.Status500InternalServerError, result);
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


