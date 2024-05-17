﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("LichXe")]
    public class LichXeEntity : Entity
    {
        // Khóa chính
        public string IDLichXe { get; set; }

        // Khóa ngoại Xe
        public string IDXe { get; set; }
        public virtual XeEntity Xes { get; set; }

        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
