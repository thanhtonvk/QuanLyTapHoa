using QuanLyTapHoa;
using QuanLyTapHoa.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTapHoa.GUI
{
    public partial class frm_ThongKe : Form
    {
        public frm_ThongKe()
        {
            InitializeComponent();
            thongKe();
        }
        ThongKeDAL thongKeDAL = new ThongKeDAL();
        private void thongKe()
        {
          
            dg_theongay.DataSource = thongKeDAL.thongKeTheoNgay();
           
            dg_theongay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
         
            dg_theongay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_SanPham().Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_HoaDon().Show();
        }

        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_LoaiSanPham().Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_ThongKe().Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new DangNhapFrm().Show();
        }
    }
}
