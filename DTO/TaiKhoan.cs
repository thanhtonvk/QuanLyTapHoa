﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTapHoa.DTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class TaiKhoan
    {
        [DisplayName("Tên đăng nhập")]
        public string TenDangNhap { get; set; }
        [DisplayName("Mật khẩu")]
        public string MatKhau { get; set; }
        [DisplayName("Loại tải khoản")]
        public string LoaiTK { get; set; }
    }
}
