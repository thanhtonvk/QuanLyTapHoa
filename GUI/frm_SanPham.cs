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
    public partial class frm_SanPham : Form
    {
        public frm_SanPham()
        {
            InitializeComponent();
            loadSanPham();
        }
        ISanPhamBLL sanPhamBLL = new SanPhamBLL();
        ILoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();

     
        private void loadSanPham()
        {
            dataGridView1.DataSource = sanPhamBLL.GetAll("");
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox1.DataSource = loaiSanPhamBLL.GetAll("");
            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var loaiSP = comboBox1.SelectedItem as LoaiSanPham;

            if (loaiSP != null)
            {
                string tensp = textBox2.Text;
                string ngaysx = dateTimePicker1.Value.ToString();
                string hansd = dateTimePicker2.Value.ToString();
                int solo = int.Parse(textBox5.Text.Trim());
                int dongia = int.Parse(textBox6.Text);
                SanPham sanPham = new SanPham()
                {
                    TenSP = tensp,
                    NgaySX = ngaysx,
                    HanSD = hansd,
                    SoLo = solo,
                    DonGia = dongia,
                    MaLoai = loaiSP.MaLoai
                };
                string rs = sanPhamBLL.Add(sanPham);
                MessageBox.Show(rs);

                dataGridView1.DataSource = sanPhamBLL.GetAll("");
               
                loadSanPham();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var loaiSP = comboBox1.SelectedItem as LoaiSanPham;
            if (loaiSP != null)
            {
                string masp = label2.Text.Trim();
                string tensp = textBox2.Text;
                string ngaysx = dateTimePicker1.Value.ToString();
                string hansd = dateTimePicker2.Value.ToString();
                int solo = int.Parse(textBox5.Text.Trim());
                int dongia = int.Parse(textBox6.Text);
                SanPham sanPham = new SanPham()
                {
                    MaSP = int.Parse(masp),
                    TenSP = tensp,
                    NgaySX = ngaysx,
                    HanSD = hansd,
                    SoLo = solo,
                    DonGia = dongia,
                    MaLoai = loaiSP.MaLoai
                };
                string rs = sanPhamBLL.Update(sanPham);
                MessageBox.Show(rs);

                dataGridView1.DataSource = sanPhamBLL.GetAll("");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string masp = label2.Text.Trim();
            string rs = sanPhamBLL.Delete(int.Parse(masp));


            dataGridView1.DataSource = sanPhamBLL.GetAll("");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sanPhamBLL.GetAll(textBox7.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                label2.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();


                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                dateTimePicker2.Text = row.Cells[4].Value.ToString();
                textBox5.Text = row.Cells[5].Value.ToString();
                textBox6.Text = row.Cells[6].Value.ToString();
            }
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
