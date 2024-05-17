﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.HoaDonKyGui
{
    public class HoaDonKyGuiModel
    {
        public string IDHoaDonKyGui { get; set; }
        public string IDHopDongKyGui { get; set; }
        public string SoHoaDon { get; set; } // tự tăng theo cấu trúc

        // Truy vấn từ bảng HopDongThueXe
        public string IDKhachHang { get; set; }
        public string IDNhanVien { get; set; }

        // Tự binding khi có hóa đơn thuê được lập (lấy khóa chính)
        public string SoHoaDonThue { get; set; }

        public DateTime NgayLap { get; set; }
        public double TongThanhToan { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
