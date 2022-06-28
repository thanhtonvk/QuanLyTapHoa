using QuanLyTapHoa.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTapHoa.DAL.InterfaceService
{
    internal interface IHoaDonBanDAL
    {
        int Add(HoaDonBan hoaDonBan);
        int Update(HoaDonBan hoaDonBan);
        int Delete(int id);
        List<GetHoaDonBan_Result> GetAll();
        HoaDonBan GetHoaDonBan(int id);
    }
}
