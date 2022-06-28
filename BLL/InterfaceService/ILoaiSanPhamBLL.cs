using System.Collections.Generic;
using QuanLyTapHoa.DTO;

namespace QuanLyTapHoa.BLL.InterfaceService
{
    public interface ILoaiSanPhamBLL
    {
        string Add(LoaiSanPham loaiSanPham);
        string Update(LoaiSanPham loaiSanPham);
        string Delete(int id);
        List<LoaiSanPham> GetAll(string TimKiem);
        LoaiSanPham GetLoaiSanPham(int id);
    }
}