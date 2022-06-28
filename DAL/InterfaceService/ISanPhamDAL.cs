﻿using QuanLyTapHoa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAL.InterfaceService
{
    internal interface ISanPhamDAL
    {
        int Add(SanPham sanPham);
        int Update(SanPham sanPham);
        int Delete(int id);
        List<SanPham> GetAll();
        SanPham GetSanPham(int id);
    }
}
