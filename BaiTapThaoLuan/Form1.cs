using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiTapThaoLuan.BLL;//thư viện lớp logic;
using BaiTapThaoLuan.DTO;//thư viện lớp đối tượng;

namespace BaiTapThaoLuan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NhanSuBLL nvBLL = new NhanSuBLL();
        NhanSuDTO nvDTO = new NhanSuDTO();
        public void Form1_Load(object sender, EventArgs e)
        {
            nvBLL.HienThi(dgv);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nvDTO.manv = txtMaNV.Text.ToLower();
                nvDTO.tennv = txtTenNV.Text;
                nvDTO.namsinh = int.Parse(txtNamSinh.Text);
                nvDTO.diachi = txtDiaChi.Text;
                nvDTO.sdt = int.Parse(txtSDT.Text);
                nvDTO.phongban = txtPhongBan.Text;
                nvDTO.chucvu = txtChucVu.Text;
                nvDTO.luong = double.Parse(txtLuong.Text);
                //gọi BLL thực hiện
                nvBLL.Them(nvDTO);
                //hiên lên dgv
                nvBLL.HienThi(dgv);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nvDTO.manv = txtMaNV.Text.ToLower();
                nvDTO.tennv = txtTenNV.Text;
                nvDTO.namsinh = int.Parse(txtNamSinh.Text);
                nvDTO.diachi = txtDiaChi.Text;
                nvDTO.sdt = int.Parse(txtSDT.Text);
                nvDTO.phongban = txtPhongBan.Text;
                nvDTO.chucvu = txtChucVu.Text;
                nvDTO.luong = double.Parse(txtLuong.Text);
                //gọi BLL thực hiện
                nvBLL.Sua(nvDTO);
                //hiện lên dgv
                nvBLL.HienThi(dgv);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nvDTO.manv = txtMaNV.Text.ToLower();
                //gọi BLL thực hiện
                nvBLL.Xoa(nvDTO);
                //hiện lên dgv
                nvBLL.HienThi(dgv);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nvDTO.manv = txtMaNV.Text.ToLower();
                //gọi BLL thực hiện
                nvBLL.TimKiem(nvDTO,dgv);
            }
        }
    }
}
