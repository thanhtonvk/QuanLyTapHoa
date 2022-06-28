using QuanLyTapHoa;
using QuanLyTapHoa.BLL;
using QuanLyTapHoa.BLL.InterfaceService;
using QuanLyTapHoa.DAL;
using QuanLyTapHoa.DTO;
using QuanLyTapHoa.Presentation;
using QuanLyTapHoa.Utils;
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
    public partial class frm_HoaDon : Form
    {
        public frm_HoaDon()
        {
            InitializeComponent();
            loadHoaDonBan();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            DangNhapFrm dangNhap = new DangNhapFrm();
            dangNhap.Show();
        }
        IHoaDonBanBLL hoaDonBanBLL = new HoaDonBanBLL();
       
        INhanVienBLL nhanVienBLL = new NhanVienBLL();
        //hóa đơn bán
        string manv = "-1";
        private void loadHoaDonBan()
        {
            dataGridView5.DataSource = hoaDonBanBLL.GetAll("");
            dataGridView5.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox3.DataSource = nhanVienBLL.GetAll("");
            comboBox3.DisplayMember = "TenNV";
            comboBox3.ValueMember = "MaNV";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            var nhanVien = comboBox3.SelectedItem as NhanVien;
            if (nhanVien != null)
            {
                HoaDonBan hoaDonBan = new HoaDonBan()
                {
                    NgayBan = dateTimePicker3.Value.ToString(),
                    TenKhach = textBox13.Text,
                    SDT = textBox14.Text,
                    DiaChi = textBox15.Text,
                    MaNV = nhanVien.MaNV
                };
                string rs = hoaDonBanBLL.Add(hoaDonBan);
                MessageBox.Show(rs);
                dataGridView5.DataSource = hoaDonBanBLL.GetAll("");

                int lastIndex = new HoaDonBanDAL().HoaDonBans().Count - 1;
              
                Common.MaHDB = new HoaDonBanDAL().HoaDonBans()[lastIndex];
                ChiTietHDBFrm frm = new ChiTietHDBFrm();
                this.Hide();
                frm.ShowDialog();
                this.Show();
                loadHoaDonBan();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            var nhanVien = comboBox3.SelectedItem as NhanVien;
            if (nhanVien != null)
            {
                HoaDonBan hoaDonBan = new HoaDonBan()
                {
                    MaHD = int.Parse(label27.Text),
                    NgayBan = dateTimePicker3.Value.ToString(),
                    TenKhach = textBox13.Text,
                    SDT = textBox14.Text,
                    DiaChi = textBox15.Text,
                    MaNV = nhanVien.MaNV
                };
                string rs = hoaDonBanBLL.Update(hoaDonBan);
                MessageBox.Show(rs);
                dataGridView5.DataSource = hoaDonBanBLL.GetAll("");

            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int MaHD = int.Parse(label27.Text);
            hoaDonBanBLL.Delete(MaHD);
            dataGridView5.DataSource = hoaDonBanBLL.GetAll("");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = hoaDonBanBLL.GetAll(textBox12.Text);
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                label27.Text = row.Cells[0].Value.ToString();
                dateTimePicker3.Text = row.Cells[1].Value.ToString();
                textBox13.Text = row.Cells[2].Value.ToString();
                textBox14.Text = row.Cells[3].Value.ToString();
                textBox15.Text = row.Cells[4].Value.ToString();
                comboBox3.Text = row.Cells[5].Value.ToString();
            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                Common.MaHDB = int.Parse(row.Cells[0].Value.ToString());

            }
            ChiTietHDBFrm frm = new ChiTietHDBFrm();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_SanPham sp = new frm_SanPham();
            sp.Show();
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_HoaDon sp = new frm_HoaDon();
            sp.Show();
        }

        private void quảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_LoaiSanPham sp = new frm_LoaiSanPham();
            sp.Show();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_ThongKe sp = new frm_ThongKe();
            sp.Show();
        }
    }
}
