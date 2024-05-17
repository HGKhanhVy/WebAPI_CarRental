﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.KhuyenMai
{
    public class KhuyenMaiModel
    {
        // Khóa chính
        public string IDKhuyenMai { get; set; }
        public string TenCTKM { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
