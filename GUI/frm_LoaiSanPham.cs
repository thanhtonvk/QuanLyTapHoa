using QuanLyTapHoa;
using QuanLyTapHoa.BLL;
using QuanLyTapHoa.BLL.InterfaceService;
using QuanLyTapHoa.DTO;
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
    public partial class frm_LoaiSanPham : Form
    {
        public frm_LoaiSanPham()
        {
            InitializeComponent();
            loadLoaiSP();
        }
        ILoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();
        //loại sản phẩm
        private void loadLoaiSP()
        {
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            LoaiSanPham loaiSanPham = new LoaiSanPham()
            {
                TenLoai = textBox4.Text
            };
            string rs = loaiSanPhamBLL.Add(loaiSanPham);
            MessageBox.Show(rs);
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoaiSanPham loaiSanPham = new LoaiSanPham()
            {
                MaLoai = int.Parse(label12.Text),
                TenLoai = textBox4.Text
            };
            string rs = loaiSanPhamBLL.Update(loaiSanPham);
            MessageBox.Show(rs);
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
        }

        private void button6_Click(object sender, EventArgs e)
        {

            int maloai = int.Parse(label12.Text);
            string rs = loaiSanPhamBLL.Delete(maloai);

            dataGridView2.DataSource = loaiSanPhamBLL.GetAll("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = loaiSanPhamBLL.GetAll(textBox1.Text);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                label12.Text = row.Cells[0].Value.ToString();
                textBox4.Text = row.Cells[1].Value.ToString();

            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhapFrm dangNhap = new DangNhapFrm();
            dangNhap.Show();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_SanPham frm = new frm_SanPham();
            frm.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_HoaDon frm = new frm_HoaDon();
            frm.Show();
        }

        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_HoaDon().Show();
          
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            new frm_ThongKe().Show();
        }
    }
}
