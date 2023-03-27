using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapThaoLuan.DTO
{
    //public class để truy cập được
    public class NhanSuDTO
    {
        //thuộc tính
        private string _MaNV;
        private string _TenNV;
        private int _NamSinh;
        private string _DiaChi;
        private int _SDT;
        private string _PhongBan;
        private string _ChucVu;
        private double _Luong;

        public string manv { get => _MaNV; set => _MaNV = value; }
        public string tennv { get => _TenNV; set => _TenNV = value; }
        public int namsinh { get => _NamSinh; set => _NamSinh = value; }
        public string diachi { get => _DiaChi; set => _DiaChi = value; }
        public int sdt { get => _SDT; set => _SDT = value; }
        public string phongban { get => _PhongBan; set => _PhongBan = value; }
        public string chucvu { get => _ChucVu; set => _ChucVu = value; }
        public double luong { get => _Luong; set => _Luong = value; }
    }
}
