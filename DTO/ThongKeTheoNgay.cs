﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyMyPham.Models
{
    internal class ThongKeTheoNgay
    {
        [DisplayName("Ngày bán")]
        public string NgayBan { get; set; }
        [DisplayName("Tổng tiền")]
        public int TongTien { get; set; }
    }
}
